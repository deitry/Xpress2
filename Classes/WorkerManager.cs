using System.Collections.Concurrent;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// сделать классы видимыми для Xpress2.Test
[assembly: InternalsVisibleTo("RootBase.Tests")]
namespace Xpress2
{
    // процедура, которую будут выполнять все потоки
    public delegate void Runner();

    // абстрагирует работу с потоками
    // TODO: выделить интерфейс
    // Вынести работу со строкой, чтобы можно было задавать обработчик извне?
    // Или другим способом обеспечить возможность различного поведения.
    // Дело благородное, но выходит за рамки тестового задания
    public class WorkerManager
    {
        // максимальное количество потоков согласно условию
        public const int MaxThreadCnt = 4;

        // ThreadPool?
        private Thread[] Workers { get; set; }

        private bool _running;
        public bool Running
        {
            get => _running;
            set
            {
                if (this._running == value) return;

                if (value)
                {
                    Initialize();
  
                    // выставляем true только когда потоки уже запущены
                    this._running = true;
                }
                else
                {
                    this._running = false;

                    // если false - дождаться окончания работы всех текущих потоков
                    foreach (var thread in this.Workers)
                        thread.Join();
                }
            }
        }

        private readonly ConcurrentQueue<string> _fileQueue;

        // были обработаны новые данные
        public event ProcessDataHandler DataProcessed;

        public WorkerManager()
        {
            _fileQueue = new ConcurrentQueue<string>();
            this.Start();
        }

        public void Start() => this.Running = true;
        public void Stop() => this.Running = false;

        // создаём новые потоки
        protected void Initialize()
        {
            this.Workers = new Thread[MaxThreadCnt];
            for (var i = 0; i < MaxThreadCnt; ++i)
            {
                this.Workers[i] = WorkerManager.CreateWorker(
                    () =>
                    {
                        // FIXME: сходу не придумал, как лучше разделить WorkerManager и Worker.
                        // Оставляю так. По-хорошему, Worker должен инкапсулировать и Thread, и способ обработки,
                        // но при этом быть независимым от Queue и WorkerManager'а в целом

                        var pattern = new Regex("[a-z]",
                            RegexOptions.Compiled | RegexOptions.IgnoreCase);

                        while (this.Running)
                        {
                            if (_fileQueue.Count <= 0) Thread.Sleep(1000);
                            if (!_fileQueue.TryDequeue(out var fileName)) continue;
                            
                            try
                            {
                                var sum = 0;
                                // https://social.msdn.microsoft.com/Forums/vstudio/en-US/d87c1085-cacb-4d82-826f-4151bf967f86/parallelfor-with-sum?forum=parallelextensions
                                // технически это тоже способ как обеспечить условие про четыре потока
                                Parallel.ForEach(
                                    source: File.ReadLines(fileName),
                                    parallelOptions: new ParallelOptions { MaxDegreeOfParallelism = WorkerManager.MaxThreadCnt },
                                    body: (line, _, lineNumber) =>
                                    {
                                        // подсчитываем число букв в документе.
                                        // Более простой вариант для подсчёта просто букв:
                                        // line.Count(char.IsLetter);
                                        var total = pattern.Matches(line).Count;
                                        Interlocked.Add(ref sum, total);
                                    });
                                DataProcessed?.Invoke(new OutputData { FileName = fileName, Value = sum });
                            }
                            catch (IOException)
                            {
                                // если удалили файл пока он обрабатывается, ничего не делаем
                            }
                        }
                    }
                );
            }

            // запускаем в отдельном цикле - для наглядности
            foreach (var thread in this.Workers)
                thread.Start();
        }

        // TODO: убедиться, что потоки успешно завершаются в любом случае
        ~WorkerManager()
        {
            this.Stop();
        }

        // создаёт новый поток
        private static Thread CreateWorker(Runner runner)
        {
            // каждый поток должен заниматься обработкой одного документа
            return new Thread(new ThreadStart(runner));
        }

        public void AddDataToQueue(InputData data)
        {
            this._fileQueue.Enqueue(data.FileName);
        }
    }
}

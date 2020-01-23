using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// альтернативный способ сделать классы видимыми для Xpress2.Test
//[assembly: InternalsVisibleTo("RootBase.Tests")]
namespace Xpress2
{
    // процедура, которую будут выполнять все потоки
    public delegate void Runner();

    // абстрагирует работу с потоками
    public class WorkerManager
    {
        // максимальное количество потоков согласно условию
        private const int MaxThreadCnt = 4;
        readonly Regex Pattern = new Regex("[a-z]",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private Thread[] Workers { get; set; }
        public bool Running { get; private set; }

        private readonly ConcurrentQueue<string> _fileQueue;

        //private Queue<InputData> queue;

        // были обработаны новые данные
        public event ProcessDataHandler DataProcessed;

        public WorkerManager()
        {
            _fileQueue = new ConcurrentQueue<string>();
            this.SetRunning(true);
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

        // TODO: разделить WorkerManager и Processor?
        private void ProcessFile(string fileName)
        {
            // технически это тоже способ как обеспечить условие про четыре потока
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = MaxThreadCnt
            };

            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/d87c1085-cacb-4d82-826f-4151bf967f86/parallelfor-with-sum?forum=parallelextensions
            // берём самый простой вариант с использованием lock
            var sum = 0;
            var sync = new object();

            Parallel.ForEach(
                source: File.ReadLines(fileName), 
                parallelOptions: options, 
                body: (line, _, lineNumber) =>
            {
                // подсчитываем число букв в документе.
                // Более простой вариант для подсчёта просто букв:
                // line.Count(char.IsLetter);
                var total = this.Pattern.Matches(line).Count;
                lock (sync) {
                    sum += total;
                }
            });

            this.DataProcessed?.Invoke(new OutputData{FileName = fileName, Value = sum});
        }

        public void SetRunning(bool running)
        {
            if (this.Running == running) return;

            if (running)
            {
                // создаём новые потоки
                this.Workers = new Thread[MaxThreadCnt];
                for (var i = 0; i < MaxThreadCnt; ++i)
                {
                    this.Workers[i] = WorkerManager.CreateWorker(
                        () =>
                        {
                            while (this.Running)
                            {
                                if (_fileQueue.Count <= 0) Thread.Sleep(1000);
                                if (_fileQueue.TryDequeue(out var fileName))
                                    this.ProcessFile(fileName);
                            }
                        }
                    );
                }

                // запускаем в отдельном цикле - для наглядности
                foreach (var thread in this.Workers)
                    thread.Start();
            }

            // выставляем true только когда потоки уже запущены
            this.Running = running;
            if (running) return;

            // если false - дождаться окончания работы всех текущих потоков
            foreach (var thread in this.Workers)
                thread.Join();
        }
    }
}
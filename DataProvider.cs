using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Xpress2
{
    // Интерфейс, предоставляющий событие появления новых данных, которые подлежат обработке
    public interface IDataProvider
    {
        event NewDataHandler FileAdded;
    }

    // Класс, генерирующий события, которые должны приводить к запуску потоков
    public class FileDataProvider : IDataProvider
    {
        private FileSystemWatcher Watcher;
 
        // in: dirname - имя папки, которую мы будем отслеживать
        public FileDataProvider(string dirpath)
        {
            if (!Directory.Exists(dirpath)) Directory.CreateDirectory(dirpath);

            Watcher = new FileSystemWatcher(dirpath)
            {
                EnableRaisingEvents = true
            };

            Watcher.Created += (sender, args) => 
                FileAdded?.Invoke(new InputData { FileName = args.FullPath });

            // TODO: генерировать события для тех файлов, которые уже там находятся
        }
        
        public event NewDataHandler FileAdded;
    }
}

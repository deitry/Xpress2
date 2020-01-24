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
        string DirPath { get; set; }
        event NewDataHandler FileAdded;
    }

    // Выдаёт новые данные по событию Created
    public class CreatedFileDataProvider : IDataProvider
    {
        private readonly FileSystemWatcher _watcher;

        private string _dirPath;
        public string DirPath
        {
            get => _dirPath;
            set
            {
                if (value == _dirPath) return;

                this._dirPath = value;
                this._watcher.Path = value;
            }
        }

        // in: dirname - имя папки, которую мы будем отслеживать
        public CreatedFileDataProvider(string dirpath)
        {
            if (!Directory.Exists(dirpath)) Directory.CreateDirectory(dirpath);

            _watcher = new FileSystemWatcher(dirpath)
            {
                EnableRaisingEvents = true
            };

            this.DirPath = dirpath;
            _watcher.Created += (sender, args) =>
            {
                // согласно условию, мониторить нужно только .txt
                if (args.Name.EndsWith(".txt"))
                    FileAdded?.Invoke(new InputData {FileName = args.FullPath});
            };

            // TODO: генерировать события для тех файлов, которые уже там находятся
            // - этого в задании нет, посему оставляем на устную проработку.
        }

        public event NewDataHandler FileAdded;
    }
}

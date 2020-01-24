using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Xpress2.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFileProviderInvokingEvents()
        {
            // проверяем, что провайдер файлов работает и создаёт события
            var dirPath = $@"{Directory.GetCurrentDirectory()}\unittest\in";
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
            // очищаем
            Directory.Delete(dirPath, true);

            Xpress2.IDataProvider dataProvider = new CreatedFileDataProvider(dirPath);
            
            var origFiles = new List<string>
            {
                // набор случайных названий
                "1.txt", "2.txt", "test1.txt", "dddsddfsdfsd.txt"
            };
            var filesProcessed = new List<string>();
            dataProvider.FileAdded += (InputData data) => { filesProcessed.Add(data.FileName); };

            foreach (var name in origFiles)
            {
                // создаём новый файл
                File.Create($@"{dirPath}\{name}");
            }

            // даём немного времени
            Thread.Sleep(1000);

            foreach (var file in origFiles)
            {
                // убеждаемся, что файл был обработан
                Assert.IsTrue(filesProcessed.Contains($@"{dirPath}\{file}"));
            }
        }

        [TestMethod]
        public void TestFileProcessedCorrectly()
        {
            // TODO: убедиться, что воркер ДЕЙСТВИТЕЛЬНО подсчитывает количество букв
            // - Сначала надо вынести Worker отдельно, инкапсулируя ProcessFile
        }

        [TestMethod]
        public void TestFileConsumerHandlesData()
        {
            // TODO: убеждаемся, что файл с выходным значением действительно пишется
        }

        [TestMethod]
        public void TestWorkerManagerStopping()
        {
            // TODO: убеждаемся, что после остановки менеджера потоков нет
        }

        [TestMethod]
        public void TestWorkerManagerStateSwitch()
        {
            // TODO: убеждаемся, что при смене состояний у нас не создаётся лишних потоков
        }
    }
}

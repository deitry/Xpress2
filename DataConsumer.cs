using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpress2
{
    public interface IDataConsumer
    {
        void ProcessData(OutputData data); 
        string OutputDir { get; set; }
    }

    // пишет выходные данные в файл
    public class FileConsumer : IDataConsumer
    {
        public string OutputDir { get; set; }

        public FileConsumer(string outputDir)
        {
            this.OutputDir = outputDir;
        }

        public void ProcessData(OutputData data)
        {
            // создаём выходную папку, если её ещё не было.
            // Откладываем созданиие папки до этого момента, чтобы
            // не создавать почём зря, если нет необходимости.
            // NB: если указанную папку создать нельзя, сами виноваты
            if (!Directory.Exists(this.OutputDir))
                Directory.CreateDirectory(this.OutputDir);

            var outputPath = $@"{OutputDir}\{Path.GetFileName(data.FileName)}";
            using (var output = new StreamWriter(outputPath))
            {
                output.WriteLine(data.Value);
            }
        }
    }
}

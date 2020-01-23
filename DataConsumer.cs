using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpress2
{
    interface IDataConsumer
    {
        void ProcessData(OutputData data);
    }

    // пишет выходные данные в файл
    class FileConsumer : IDataConsumer
    {
        private readonly string OutputDir;

        // создаём выходную папку, если её ещё не было
        // NB: если указанную папку создать нельзя, сами виноваты
        public FileConsumer(string outputDir)
        {
            this.OutputDir = outputDir;
            Directory.CreateDirectory(this.OutputDir);
        }

        public void ProcessData(OutputData data)
        {
            var outputPath = $@"{OutputDir}\{Path.GetFileName(data.FileName)}";
            using (var output = new StreamWriter(outputPath))
            {
                output.WriteLine(data.Value);
            }
        }
    }
}

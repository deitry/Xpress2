using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpress2
{ 
    // входные данные
    public struct InputData
    {
        // поскольку оперируем отдельными файлами, передаём имя в качестве входных данных
        public string FileName;
    }

    // выходные данные
    public struct OutputData
    {
        public string FileName;
        public int Value;
    }

    public delegate void NewDataHandler(InputData data);
    public delegate void ProcessDataHandler(OutputData data);
}

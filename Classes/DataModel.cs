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
        // для всеобщего удобства подразумеваем полное имя
        public string FileName;
    }

    // выходные данные
    public struct OutputData
    {
        // для всеобщего удобства подразумеваем полное имя
        public string FileName;
        public int Value;
    }

    public delegate void NewDataHandler(InputData data);
    public delegate void ProcessDataHandler(OutputData data);
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xpress2
{
    static class Program
    {
        // трюк для работы вывода в консоль - если передаём параметры через аргументы командной строки
        // https://social.msdn.microsoft.com/Forums/vstudio/en-US/2ddb37db-9e85-4065-af97-8035af17ff22/will-consolewriteline-work-in-windows-application?forum=csharpgeneral
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        internal static void AttachConsoleForCommandLineMode()
        {
            //must call before any calls to Console.WriteLine()
            AttachConsole(ATTACH_PARENT_PROCESS);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argv)
        {
            var inputDirName = $@"{Directory.GetCurrentDirectory()}\test\in";
            var outputDirName = $@"{Directory.GetCurrentDirectory()}\test\out";

            if (argv.Length == 2)
            {
                // TODO: проверять, являются ли пути относительными
                inputDirName = argv[0];
                outputDirName = argv[1];
            }
            else if (argv.Length > 0)
            {
                AttachConsoleForCommandLineMode();
                Console.WriteLine("Expected zero or two parameters!");
                Console.WriteLine("usage: Xpress2.exe [<inputDir> <outputDir>]");
                throw new ArgumentException($"Got {argv.Length} params, expected 2");
            }

            // View configuration
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FileProcessingForm(inputDirName, outputDirName));
        }
    }
}

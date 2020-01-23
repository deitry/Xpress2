using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xpress2
{
    public partial class FileProcessingForm : Form
    {
        private void SetState(bool started)
        {
            this.Manager.SetRunning(started);

            // FIXME: проконтролировать, что UI поток согласуется с логикой
            this.StartButton.Enabled = !started;
            this.StopButton.Enabled = started;
        }

        private IDataProvider DataProvider;
        private WorkerManager Manager;
        private IDataConsumer Consumer;

        public FileProcessingForm()
        {
            DataProvider = new FileDataProvider(Directory.GetCurrentDirectory() + @"\test\in");
            Manager = new WorkerManager();
            Consumer = new FileConsumer(Directory.GetCurrentDirectory() + @"\test\out");

            // data pipeline
            DataProvider.FileAdded += Manager.AddDataToQueue;
            Manager.DataProcessed += Consumer.ProcessData;

            InitializeComponent();
            // по умолчанию запускаем
            this.SetState(true);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.SetState(true);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            this.SetState(false);
        }
    }
}

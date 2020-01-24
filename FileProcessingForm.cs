using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace Xpress2
{
    public partial class FileProcessingForm : Form
    {
        private void SetState(bool started)
        {
            this._manager.Running = started;

            // FIXME: проконтролировать, что UI поток согласуется с логикой
            this.StartButton.Enabled = !started;
            this.StopButton.Enabled = started;
        }

        private readonly IDataProvider _dataProvider;
        private readonly WorkerManager _manager;
        private readonly IDataConsumer _consumer;

        public FileProcessingForm(string initialInDir, string initialOutDir)
        {
            _dataProvider = new CreatedFileDataProvider(initialInDir);
            _manager = new WorkerManager();
            _consumer = new FileConsumer(initialOutDir);
            
            // data pipeline
            _dataProvider.FileAdded += _manager.AddDataToQueue;
            _manager.DataProcessed += _consumer.ProcessData;
            _manager.DataProcessed += (OutputData data) =>
                Invoke(new Action(
                    () =>
                    {
                        // выводим на ListView
                        // TODO: выводить имя конечного файла было бы практичнее
                        processedFilesListView.Items.Add(data.FileName);
                    }));

            InitializeComponent();

            inputFolderTextBox.Text = initialInDir;
            outputFolderTextBox.Text = initialOutDir;

            // согласовываем состояние с WorkerManager
            this.SetState(_manager.Running);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.SetState(true);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            this.SetState(false);
        }

        private void browseInputDirButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = inputFolderTextBox.Text;
            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                inputFolderTextBox.Text = folderBrowserDialog.SelectedPath;
                _dataProvider.DirPath = folderBrowserDialog.SelectedPath;
            }
        }

        private void browseOutputDirButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = outputFolderTextBox.Text;
            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputFolderTextBox.Text = folderBrowserDialog.SelectedPath;
                _consumer.OutputDir = folderBrowserDialog.SelectedPath;
            }
        }

        private void FileProcessingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _manager.Stop();
        }
    }
}

namespace Xpress2
{
    partial class FileProcessingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.browseOutputDirButton = new System.Windows.Forms.Button();
            this.browseInputDirButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.inputFolderTextBox = new System.Windows.Forms.TextBox();
            this.outputFolderTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.processedFilesListView = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(3, 3);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(84, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.browseOutputDirButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.browseInputDirButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.inputFolderTextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.outputFolderTextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.processedFilesListView, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.73631F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.048511F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.21518F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 328);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // browseOutputDirButton
            // 
            this.browseOutputDirButton.Location = new System.Drawing.Point(663, 286);
            this.browseOutputDirButton.Name = "browseOutputDirButton";
            this.browseOutputDirButton.Size = new System.Drawing.Size(87, 23);
            this.browseOutputDirButton.TabIndex = 3;
            this.browseOutputDirButton.Text = "Browse";
            this.browseOutputDirButton.UseVisualStyleBackColor = true;
            this.browseOutputDirButton.Click += new System.EventHandler(this.browseOutputDirButton_Click);
            // 
            // browseInputDirButton
            // 
            this.browseInputDirButton.Location = new System.Drawing.Point(275, 286);
            this.browseInputDirButton.Name = "browseInputDirButton";
            this.browseInputDirButton.Size = new System.Drawing.Size(85, 23);
            this.browseInputDirButton.TabIndex = 2;
            this.browseInputDirButton.Text = "Browse";
            this.browseInputDirButton.UseVisualStyleBackColor = true;
            this.browseInputDirButton.Click += new System.EventHandler(this.browseInputDirButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.StartButton);
            this.flowLayoutPanel1.Controls.Add(this.StopButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(266, 248);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // inputFolderTextBox
            // 
            this.inputFolderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputFolderTextBox.Location = new System.Drawing.Point(3, 286);
            this.inputFolderTextBox.Name = "inputFolderTextBox";
            this.inputFolderTextBox.ReadOnly = true;
            this.inputFolderTextBox.Size = new System.Drawing.Size(266, 22);
            this.inputFolderTextBox.TabIndex = 7;
            // 
            // outputFolderTextBox
            // 
            this.outputFolderTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputFolderTextBox.Location = new System.Drawing.Point(391, 286);
            this.outputFolderTextBox.Name = "outputFolderTextBox";
            this.outputFolderTextBox.ReadOnly = true;
            this.outputFolderTextBox.Size = new System.Drawing.Size(266, 22);
            this.outputFolderTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output folder";
            // 
            // processedFilesListView
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.processedFilesListView, 2);
            this.processedFilesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processedFilesListView.GridLines = true;
            this.processedFilesListView.HideSelection = false;
            this.processedFilesListView.Location = new System.Drawing.Point(391, 3);
            this.processedFilesListView.Name = "processedFilesListView";
            this.processedFilesListView.Size = new System.Drawing.Size(384, 248);
            this.processedFilesListView.TabIndex = 9;
            this.processedFilesListView.UseCompatibleStateImageBehavior = false;
            this.processedFilesListView.View = System.Windows.Forms.View.List;
            // 
            // FileProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 328);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FileProcessingForm";
            this.Text = "FileProcessingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileProcessingForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button browseOutputDirButton;
        private System.Windows.Forms.Button browseInputDirButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox inputFolderTextBox;
        private System.Windows.Forms.TextBox outputFolderTextBox;
        private System.Windows.Forms.ListView processedFilesListView;
    }
}


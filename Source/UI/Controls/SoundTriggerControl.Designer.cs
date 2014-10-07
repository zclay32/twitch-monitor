namespace TwitchMonitor.UI.Controls
{
    partial class SoundTriggerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uiGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiVolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.uiVolumeValueLabel = new System.Windows.Forms.Label();
            this.uiSoundDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.uiVolumeLabel = new System.Windows.Forms.Label();
            this.uiNoSoundRadioButton = new System.Windows.Forms.RadioButton();
            this.uiSoundFileTextBox = new System.Windows.Forms.TextBox();
            this.uiPlaySoundFileRadioButton = new System.Windows.Forms.RadioButton();
            this.uiSoundDirectorySearchButton = new System.Windows.Forms.Button();
            this.uiPlaySoundDirectoryRadioButton = new System.Windows.Forms.RadioButton();
            this.uiSoundFileSearchButton = new System.Windows.Forms.Button();
            this.uiTestSoundFileButton = new System.Windows.Forms.Button();
            this.uiTestSoundDirButton = new System.Windows.Forms.Button();
            this.uiGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiVolumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Browse to the folder that contains the sound files you want to play.";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "WAV files|*.wav";
            this.openFileDialog.Title = "Search for a WAV file to play.";
            // 
            // uiGroupBox
            // 
            this.uiGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.uiGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox.Name = "uiGroupBox";
            this.uiGroupBox.Size = new System.Drawing.Size(393, 140);
            this.uiGroupBox.TabIndex = 34;
            this.uiGroupBox.TabStop = false;
            this.uiGroupBox.Text = "Sound Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.uiVolumeTrackBar, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiVolumeValueLabel, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiSoundDirectoryTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiVolumeLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiNoSoundRadioButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiSoundFileTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiPlaySoundFileRadioButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiSoundDirectorySearchButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiPlaySoundDirectoryRadioButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiSoundFileSearchButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiTestSoundFileButton, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiTestSoundDirButton, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 121);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // uiVolumeTrackBar
            // 
            this.uiVolumeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiVolumeTrackBar.Location = new System.Drawing.Point(123, 78);
            this.uiVolumeTrackBar.Name = "uiVolumeTrackBar";
            this.uiVolumeTrackBar.Size = new System.Drawing.Size(117, 40);
            this.uiVolumeTrackBar.TabIndex = 33;
            this.uiVolumeTrackBar.Scroll += new System.EventHandler(this.uiVolumeTrackBar_Scroll);
            this.uiVolumeTrackBar.ValueChanged += new System.EventHandler(this.uiVolumeTrackBar_ValueChanged);
            // 
            // uiVolumeValueLabel
            // 
            this.uiVolumeValueLabel.AutoSize = true;
            this.uiVolumeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiVolumeValueLabel.Location = new System.Drawing.Point(246, 75);
            this.uiVolumeValueLabel.Name = "uiVolumeValueLabel";
            this.uiVolumeValueLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.uiVolumeValueLabel.Size = new System.Drawing.Size(66, 46);
            this.uiVolumeValueLabel.TabIndex = 34;
            this.uiVolumeValueLabel.Text = "[VolumeInfo]";
            // 
            // uiSoundDirectoryTextBox
            // 
            this.uiSoundDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiSoundDirectoryTextBox, 2);
            this.uiSoundDirectoryTextBox.Location = new System.Drawing.Point(123, 52);
            this.uiSoundDirectoryTextBox.Name = "uiSoundDirectoryTextBox";
            this.uiSoundDirectoryTextBox.Size = new System.Drawing.Size(189, 20);
            this.uiSoundDirectoryTextBox.TabIndex = 15;
            // 
            // uiVolumeLabel
            // 
            this.uiVolumeLabel.AutoSize = true;
            this.uiVolumeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiVolumeLabel.Location = new System.Drawing.Point(3, 75);
            this.uiVolumeLabel.Name = "uiVolumeLabel";
            this.uiVolumeLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.uiVolumeLabel.Size = new System.Drawing.Size(114, 46);
            this.uiVolumeLabel.TabIndex = 32;
            this.uiVolumeLabel.Text = "Volume:";
            this.uiVolumeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiNoSoundRadioButton
            // 
            this.uiNoSoundRadioButton.AutoSize = true;
            this.uiNoSoundRadioButton.Checked = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiNoSoundRadioButton, 2);
            this.uiNoSoundRadioButton.Location = new System.Drawing.Point(3, 3);
            this.uiNoSoundRadioButton.Name = "uiNoSoundRadioButton";
            this.uiNoSoundRadioButton.Size = new System.Drawing.Size(120, 17);
            this.uiNoSoundRadioButton.TabIndex = 31;
            this.uiNoSoundRadioButton.TabStop = true;
            this.uiNoSoundRadioButton.Text = "Do not play a sound";
            this.uiNoSoundRadioButton.UseVisualStyleBackColor = true;
            // 
            // uiSoundFileTextBox
            // 
            this.uiSoundFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiSoundFileTextBox, 2);
            this.uiSoundFileTextBox.Location = new System.Drawing.Point(123, 26);
            this.uiSoundFileTextBox.Name = "uiSoundFileTextBox";
            this.uiSoundFileTextBox.Size = new System.Drawing.Size(189, 20);
            this.uiSoundFileTextBox.TabIndex = 28;
            // 
            // uiPlaySoundFileRadioButton
            // 
            this.uiPlaySoundFileRadioButton.AutoSize = true;
            this.uiPlaySoundFileRadioButton.Location = new System.Drawing.Point(3, 26);
            this.uiPlaySoundFileRadioButton.Name = "uiPlaySoundFileRadioButton";
            this.uiPlaySoundFileRadioButton.Size = new System.Drawing.Size(114, 17);
            this.uiPlaySoundFileRadioButton.TabIndex = 27;
            this.uiPlaySoundFileRadioButton.Text = "Sound File (*.wav):";
            this.uiPlaySoundFileRadioButton.UseVisualStyleBackColor = true;
            // 
            // uiSoundDirectorySearchButton
            // 
            this.uiSoundDirectorySearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSoundDirectorySearchButton.Location = new System.Drawing.Point(318, 52);
            this.uiSoundDirectorySearchButton.Name = "uiSoundDirectorySearchButton";
            this.uiSoundDirectorySearchButton.Size = new System.Drawing.Size(30, 20);
            this.uiSoundDirectorySearchButton.TabIndex = 16;
            this.uiSoundDirectorySearchButton.Text = "...";
            this.uiSoundDirectorySearchButton.UseVisualStyleBackColor = true;
            this.uiSoundDirectorySearchButton.Click += new System.EventHandler(this.uiSoundDirectorySearchButton_Click);
            // 
            // uiPlaySoundDirectoryRadioButton
            // 
            this.uiPlaySoundDirectoryRadioButton.AutoSize = true;
            this.uiPlaySoundDirectoryRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiPlaySoundDirectoryRadioButton.Location = new System.Drawing.Point(3, 52);
            this.uiPlaySoundDirectoryRadioButton.Name = "uiPlaySoundDirectoryRadioButton";
            this.uiPlaySoundDirectoryRadioButton.Size = new System.Drawing.Size(114, 20);
            this.uiPlaySoundDirectoryRadioButton.TabIndex = 26;
            this.uiPlaySoundDirectoryRadioButton.Text = "Sound Directory:";
            this.uiPlaySoundDirectoryRadioButton.UseVisualStyleBackColor = true;
            // 
            // uiSoundFileSearchButton
            // 
            this.uiSoundFileSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSoundFileSearchButton.Location = new System.Drawing.Point(318, 26);
            this.uiSoundFileSearchButton.Name = "uiSoundFileSearchButton";
            this.uiSoundFileSearchButton.Size = new System.Drawing.Size(30, 20);
            this.uiSoundFileSearchButton.TabIndex = 29;
            this.uiSoundFileSearchButton.Text = "...";
            this.uiSoundFileSearchButton.UseVisualStyleBackColor = true;
            this.uiSoundFileSearchButton.Click += new System.EventHandler(this.uiSoundFileSearchButton_Click);
            // 
            // uiTestSoundFileButton
            // 
            this.uiTestSoundFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTestSoundFileButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.uiTestSoundFileButton.ForeColor = System.Drawing.Color.Green;
            this.uiTestSoundFileButton.Location = new System.Drawing.Point(354, 26);
            this.uiTestSoundFileButton.Name = "uiTestSoundFileButton";
            this.uiTestSoundFileButton.Size = new System.Drawing.Size(30, 20);
            this.uiTestSoundFileButton.TabIndex = 35;
            this.uiTestSoundFileButton.Text = "";
            this.uiTestSoundFileButton.UseVisualStyleBackColor = true;
            this.uiTestSoundFileButton.Click += new System.EventHandler(this.uiTestSoundFileButton_Click);
            // 
            // uiTestSoundDirButton
            // 
            this.uiTestSoundDirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTestSoundDirButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.uiTestSoundDirButton.ForeColor = System.Drawing.Color.Green;
            this.uiTestSoundDirButton.Location = new System.Drawing.Point(354, 52);
            this.uiTestSoundDirButton.Name = "uiTestSoundDirButton";
            this.uiTestSoundDirButton.Size = new System.Drawing.Size(30, 20);
            this.uiTestSoundDirButton.TabIndex = 36;
            this.uiTestSoundDirButton.Text = "";
            this.uiTestSoundDirButton.UseVisualStyleBackColor = true;
            this.uiTestSoundDirButton.Click += new System.EventHandler(this.uiTestSoundDirButton_Click);
            // 
            // SoundTriggerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiGroupBox);
            this.MinimumSize = new System.Drawing.Size(361, 140);
            this.Name = "SoundTriggerControl";
            this.Size = new System.Drawing.Size(393, 140);
            this.uiGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiVolumeTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox uiGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TrackBar uiVolumeTrackBar;
        private System.Windows.Forms.Label uiVolumeValueLabel;
        private System.Windows.Forms.TextBox uiSoundDirectoryTextBox;
        private System.Windows.Forms.Label uiVolumeLabel;
        private System.Windows.Forms.RadioButton uiNoSoundRadioButton;
        private System.Windows.Forms.TextBox uiSoundFileTextBox;
        private System.Windows.Forms.RadioButton uiPlaySoundFileRadioButton;
        private System.Windows.Forms.Button uiSoundDirectorySearchButton;
        private System.Windows.Forms.RadioButton uiPlaySoundDirectoryRadioButton;
        private System.Windows.Forms.Button uiSoundFileSearchButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button uiTestSoundFileButton;
        private System.Windows.Forms.Button uiTestSoundDirButton;
    }
}

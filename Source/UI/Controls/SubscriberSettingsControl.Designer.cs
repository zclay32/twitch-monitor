namespace TwitchMonitor.Controls
{
    partial class SubscriberSettingsControl
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
            this.adSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiEnableAdsCheckBox = new System.Windows.Forms.CheckBox();
            this.uiAdLengthLabel = new System.Windows.Forms.Label();
            this.uiAdTypeLabel = new System.Windows.Forms.Label();
            this.uiAdWarningLabel = new System.Windows.Forms.Label();
            this.uiBreakLengthComboBox = new System.Windows.Forms.ComboBox();
            this.uiWarningTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiBreakTypeComboBox = new System.Windows.Forms.ComboBox();
            this.uiAdWarningSecondsLabel = new System.Windows.Forms.Label();
            this.uiAutoComboBox = new System.Windows.Forms.ComboBox();
            this.adSettingsGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiWarningTimeNumericUpDown)).BeginInit();
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
            // adSettingsGroupBox
            // 
            this.adSettingsGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.adSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.adSettingsGroupBox.Location = new System.Drawing.Point(10, 10);
            this.adSettingsGroupBox.Name = "adSettingsGroupBox";
            this.adSettingsGroupBox.Size = new System.Drawing.Size(423, 135);
            this.adSettingsGroupBox.TabIndex = 34;
            this.adSettingsGroupBox.TabStop = false;
            this.adSettingsGroupBox.Text = "Ad Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.uiEnableAdsCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiAdLengthLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiAdTypeLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiAdWarningLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiBreakLengthComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiWarningTimeNumericUpDown, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiBreakTypeComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiAdWarningSecondsLabel, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiAutoComboBox, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 116);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // uiEnableAdsCheckBox
            // 
            this.uiEnableAdsCheckBox.AutoSize = true;
            this.uiEnableAdsCheckBox.Location = new System.Drawing.Point(6, 6);
            this.uiEnableAdsCheckBox.Name = "uiEnableAdsCheckBox";
            this.uiEnableAdsCheckBox.Size = new System.Drawing.Size(109, 17);
            this.uiEnableAdsCheckBox.TabIndex = 0;
            this.uiEnableAdsCheckBox.Text = "Enable ad breaks";
            this.uiEnableAdsCheckBox.UseVisualStyleBackColor = true;
            this.uiEnableAdsCheckBox.CheckedChanged += new System.EventHandler(this.uiEnableAdsCheckBox_CheckedChanged);
            // 
            // uiAdLengthLabel
            // 
            this.uiAdLengthLabel.AutoSize = true;
            this.uiAdLengthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAdLengthLabel.Location = new System.Drawing.Point(6, 26);
            this.uiAdLengthLabel.Name = "uiAdLengthLabel";
            this.uiAdLengthLabel.Size = new System.Drawing.Size(174, 27);
            this.uiAdLengthLabel.TabIndex = 3;
            this.uiAdLengthLabel.Text = "Ad break length:";
            this.uiAdLengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiAdTypeLabel
            // 
            this.uiAdTypeLabel.AutoSize = true;
            this.uiAdTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAdTypeLabel.Location = new System.Drawing.Point(6, 53);
            this.uiAdTypeLabel.Name = "uiAdTypeLabel";
            this.uiAdTypeLabel.Size = new System.Drawing.Size(174, 27);
            this.uiAdTypeLabel.TabIndex = 4;
            this.uiAdTypeLabel.Text = "How to perform ad break:";
            this.uiAdTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiAdWarningLabel
            // 
            this.uiAdWarningLabel.AutoSize = true;
            this.uiAdWarningLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAdWarningLabel.Location = new System.Drawing.Point(6, 80);
            this.uiAdWarningLabel.Name = "uiAdWarningLabel";
            this.uiAdWarningLabel.Size = new System.Drawing.Size(174, 26);
            this.uiAdWarningLabel.TabIndex = 6;
            this.uiAdWarningLabel.Text = "Heads up warning before ad break:";
            this.uiAdWarningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiBreakLengthComboBox
            // 
            this.uiBreakLengthComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBreakLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiBreakLengthComboBox.FormattingEnabled = true;
            this.uiBreakLengthComboBox.Items.AddRange(new object[] {
            "30 sec",
            "1 min",
            "1 min 30 sec",
            "2 min",
            "2 min 30 sec",
            "3 min"});
            this.uiBreakLengthComboBox.Location = new System.Drawing.Point(186, 29);
            this.uiBreakLengthComboBox.Name = "uiBreakLengthComboBox";
            this.uiBreakLengthComboBox.Size = new System.Drawing.Size(109, 21);
            this.uiBreakLengthComboBox.TabIndex = 2;
            // 
            // uiWarningTimeNumericUpDown
            // 
            this.uiWarningTimeNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiWarningTimeNumericUpDown.Location = new System.Drawing.Point(186, 83);
            this.uiWarningTimeNumericUpDown.Name = "uiWarningTimeNumericUpDown";
            this.uiWarningTimeNumericUpDown.Size = new System.Drawing.Size(109, 20);
            this.uiWarningTimeNumericUpDown.TabIndex = 5;
            // 
            // uiBreakTypeComboBox
            // 
            this.uiBreakTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiBreakTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiBreakTypeComboBox.FormattingEnabled = true;
            this.uiBreakTypeComboBox.Items.AddRange(new object[] {
            "Manually",
            "Automatically"});
            this.uiBreakTypeComboBox.Location = new System.Drawing.Point(186, 56);
            this.uiBreakTypeComboBox.Name = "uiBreakTypeComboBox";
            this.uiBreakTypeComboBox.Size = new System.Drawing.Size(109, 21);
            this.uiBreakTypeComboBox.TabIndex = 1;
            // 
            // uiAdWarningSecondsLabel
            // 
            this.uiAdWarningSecondsLabel.AutoSize = true;
            this.uiAdWarningSecondsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAdWarningSecondsLabel.Location = new System.Drawing.Point(301, 80);
            this.uiAdWarningSecondsLabel.Name = "uiAdWarningSecondsLabel";
            this.uiAdWarningSecondsLabel.Size = new System.Drawing.Size(110, 26);
            this.uiAdWarningSecondsLabel.TabIndex = 7;
            this.uiAdWarningSecondsLabel.Text = "seconds";
            this.uiAdWarningSecondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiAutoComboBox
            // 
            this.uiAutoComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAutoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiAutoComboBox.FormattingEnabled = true;
            this.uiAutoComboBox.Items.AddRange(new object[] {
            "Every 10 min",
            "Every 15 min",
            "Every 20 min",
            "Every 25 min",
            "Every 30 min",
            "Every 35 min",
            "Every 40 min",
            "Every 45 min",
            "Every 50 min",
            "Every 55 min",
            "Every hour"});
            this.uiAutoComboBox.Location = new System.Drawing.Point(301, 56);
            this.uiAutoComboBox.Name = "uiAutoComboBox";
            this.uiAutoComboBox.Size = new System.Drawing.Size(110, 21);
            this.uiAutoComboBox.TabIndex = 8;
            // 
            // SubscriberSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.adSettingsGroupBox);
            this.Name = "SubscriberSettingsControl";
            this.Size = new System.Drawing.Size(443, 361);
            this.adSettingsGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiWarningTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox adSettingsGroupBox;
        private System.Windows.Forms.CheckBox uiEnableAdsCheckBox;
        private System.Windows.Forms.ComboBox uiBreakTypeComboBox;
        private System.Windows.Forms.ComboBox uiBreakLengthComboBox;
        private System.Windows.Forms.Label uiAdLengthLabel;
        private System.Windows.Forms.Label uiAdTypeLabel;
        private System.Windows.Forms.NumericUpDown uiWarningTimeNumericUpDown;
        private System.Windows.Forms.Label uiAdWarningLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label uiAdWarningSecondsLabel;
        private System.Windows.Forms.ComboBox uiAutoComboBox;
    }
}

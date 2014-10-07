namespace TwitchMonitor.UI.Controls
{
    partial class TimerUserControl
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
            this.uiCountdownDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uiOutputFormatTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uiOutputFileTextBox = new System.Windows.Forms.TextBox();
            this.uiFileBrowseButton = new System.Windows.Forms.Button();
            this.uiRunButton = new System.Windows.Forms.Button();
            this.uiOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uiSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.uiModeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uiOutputLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.uiResetButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiCountdownDateTimePicker
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.uiCountdownDateTimePicker, 3);
            this.uiCountdownDateTimePicker.CustomFormat = "MM/dd/yy h:mm:ss tt";
            this.uiCountdownDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCountdownDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.uiCountdownDateTimePicker.Location = new System.Drawing.Point(198, 3);
            this.uiCountdownDateTimePicker.Name = "uiCountdownDateTimePicker";
            this.uiCountdownDateTimePicker.Size = new System.Drawing.Size(201, 26);
            this.uiCountdownDateTimePicker.TabIndex = 0;
            // 
            // uiOutputFormatTextBox
            // 
            this.uiOutputFormatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOutputFormatTextBox.Location = new System.Drawing.Point(86, 63);
            this.uiOutputFormatTextBox.Name = "uiOutputFormatTextBox";
            this.uiOutputFormatTextBox.Size = new System.Drawing.Size(106, 20);
            this.uiOutputFormatTextBox.TabIndex = 1;
            this.uiOutputFormatTextBox.Text = "d.\\hh\\:mm\\:ss\\.fff";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Format:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label3, 3);
            this.label3.Location = new System.Drawing.Point(198, 60);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label3.Size = new System.Drawing.Size(305, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Example: d\\.hh\\:mm\\:ss\\.fff -> 0.16:23:05.532";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "Output File:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiOutputFileTextBox
            // 
            this.uiOutputFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.uiOutputFileTextBox, 3);
            this.uiOutputFileTextBox.Location = new System.Drawing.Point(86, 35);
            this.uiOutputFileTextBox.Name = "uiOutputFileTextBox";
            this.uiOutputFileTextBox.Size = new System.Drawing.Size(387, 20);
            this.uiOutputFileTextBox.TabIndex = 6;
            // 
            // uiFileBrowseButton
            // 
            this.uiFileBrowseButton.Location = new System.Drawing.Point(479, 35);
            this.uiFileBrowseButton.Name = "uiFileBrowseButton";
            this.uiFileBrowseButton.Size = new System.Drawing.Size(24, 22);
            this.uiFileBrowseButton.TabIndex = 8;
            this.uiFileBrowseButton.Text = "...";
            this.uiFileBrowseButton.UseVisualStyleBackColor = true;
            this.uiFileBrowseButton.Click += new System.EventHandler(this.uiFileBrowseButton_Click);
            // 
            // uiRunButton
            // 
            this.uiRunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.uiRunButton, 2);
            this.uiRunButton.Location = new System.Drawing.Point(428, 89);
            this.uiRunButton.MaximumSize = new System.Drawing.Size(75, 25);
            this.uiRunButton.MinimumSize = new System.Drawing.Size(75, 25);
            this.uiRunButton.Name = "uiRunButton";
            this.uiRunButton.Size = new System.Drawing.Size(75, 25);
            this.uiRunButton.TabIndex = 7;
            this.uiRunButton.Text = "Start";
            this.uiRunButton.UseVisualStyleBackColor = true;
            this.uiRunButton.Click += new System.EventHandler(this.uiRunButton_Click);
            // 
            // uiOpenFileDialog
            // 
            this.uiOpenFileDialog.Filter = "Text files|*.txt";
            // 
            // uiSaveFileDialog
            // 
            this.uiSaveFileDialog.Filter = "Text files|*.txt";
            // 
            // uiModeComboBox
            // 
            this.uiModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiModeComboBox.FormattingEnabled = true;
            this.uiModeComboBox.Items.AddRange(new object[] {
            "Countdown To",
            "Countdown From",
            "Stopwatch"});
            this.uiModeComboBox.Location = new System.Drawing.Point(86, 6);
            this.uiModeComboBox.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.uiModeComboBox.Name = "uiModeComboBox";
            this.uiModeComboBox.Size = new System.Drawing.Size(106, 21);
            this.uiModeComboBox.TabIndex = 9;
            this.uiModeComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 32);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mode:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiOutputLabel
            // 
            this.uiOutputLabel.AutoSize = true;
            this.uiOutputLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiOutputLabel.Location = new System.Drawing.Point(3, 86);
            this.uiOutputLabel.Name = "uiOutputLabel";
            this.uiOutputLabel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.uiOutputLabel.Size = new System.Drawing.Size(77, 235);
            this.uiOutputLabel.TabIndex = 11;
            this.uiOutputLabel.Text = "[OUTPUT]";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.uiOutputFormatTextBox, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.uiCountdownDateTimePicker, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.uiOutputFileTextBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.uiModeComboBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.uiOutputLabel, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.uiRunButton, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.uiResetButton, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.uiFileBrowseButton, 4, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(506, 321);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // uiResetButton
            // 
            this.uiResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiResetButton.Location = new System.Drawing.Point(347, 89);
            this.uiResetButton.MaximumSize = new System.Drawing.Size(75, 24);
            this.uiResetButton.MinimumSize = new System.Drawing.Size(75, 24);
            this.uiResetButton.Name = "uiResetButton";
            this.uiResetButton.Size = new System.Drawing.Size(75, 24);
            this.uiResetButton.TabIndex = 14;
            this.uiResetButton.Text = "Reset";
            this.uiResetButton.UseVisualStyleBackColor = true;
            this.uiResetButton.Click += new System.EventHandler(this.uiResetButton_Click);
            // 
            // TimerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "TimerUserControl";
            this.Size = new System.Drawing.Size(506, 321);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker uiCountdownDateTimePicker;
        private System.Windows.Forms.TextBox uiOutputFormatTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uiOutputFileTextBox;
        private System.Windows.Forms.Button uiFileBrowseButton;
        private System.Windows.Forms.OpenFileDialog uiOpenFileDialog;
        private System.Windows.Forms.Button uiRunButton;
        private System.Windows.Forms.SaveFileDialog uiSaveFileDialog;
        private System.Windows.Forms.ComboBox uiModeComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label uiOutputLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button uiResetButton;
    }
}

namespace TwitchMonitor.UI.Controls
{
    partial class FileOutputSettingsControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiAdWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.uiViewersCheckBox = new System.Windows.Forms.CheckBox();
            this.uiFollowersCheckBox = new System.Windows.Forms.CheckBox();
            this.uiSubscribersCheckBox = new System.Windows.Forms.CheckBox();
            this.uiSubscribersFilePathTextBox = new System.Windows.Forms.TextBox();
            this.uiFollowersFilePathTextBox = new System.Windows.Forms.TextBox();
            this.uiFollowersFileBrowseButton = new System.Windows.Forms.Button();
            this.uiSubscribersFileBrowseButton = new System.Windows.Forms.Button();
            this.uiViewerCountFileBrowseButton = new System.Windows.Forms.Button();
            this.uiViewerCountFilePathTextBox = new System.Windows.Forms.TextBox();
            this.uiFollowersCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiSubscribersCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiDiceRollTextBox = new System.Windows.Forms.TextBox();
            this.uiDiceRollButton = new System.Windows.Forms.Button();
            this.uiAdWarningTextBox = new System.Windows.Forms.TextBox();
            this.uiAdWarningButton = new System.Windows.Forms.Button();
            this.uiDiceRollLabel = new System.Windows.Forms.Label();
            this.uiSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiClearFollowersOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.uiClearSubscribersOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFollowersCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSubscribersCountNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.uiAdWarningCheckBox, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.uiViewersCheckBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiFollowersCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiSubscribersCheckBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiSubscribersFilePathTextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiFollowersFilePathTextBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiFollowersFileBrowseButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiSubscribersFileBrowseButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiViewerCountFileBrowseButton, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiViewerCountFilePathTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiFollowersCountNumericUpDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiSubscribersCountNumericUpDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiDiceRollTextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.uiDiceRollButton, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.uiAdWarningTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.uiAdWarningButton, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.uiDiceRollLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.uiClearFollowersOnStartupCheckBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiClearSubscribersOnStartupCheckBox, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(519, 232);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // uiAdWarningCheckBox
            // 
            this.uiAdWarningCheckBox.AutoSize = true;
            this.uiAdWarningCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAdWarningCheckBox.Location = new System.Drawing.Point(3, 136);
            this.uiAdWarningCheckBox.Name = "uiAdWarningCheckBox";
            this.uiAdWarningCheckBox.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.uiAdWarningCheckBox.Size = new System.Drawing.Size(128, 23);
            this.uiAdWarningCheckBox.TabIndex = 18;
            this.uiAdWarningCheckBox.Text = "Ad Warning:";
            this.uiAdWarningCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiAdWarningCheckBox.UseVisualStyleBackColor = true;
            // 
            // uiViewersCheckBox
            // 
            this.uiViewersCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiViewersCheckBox.AutoSize = true;
            this.uiViewersCheckBox.Location = new System.Drawing.Point(3, 107);
            this.uiViewersCheckBox.Name = "uiViewersCheckBox";
            this.uiViewersCheckBox.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.uiViewersCheckBox.Size = new System.Drawing.Size(128, 20);
            this.uiViewersCheckBox.TabIndex = 8;
            this.uiViewersCheckBox.Text = "Viewer Count:";
            this.uiViewersCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiViewersCheckBox.UseVisualStyleBackColor = true;
            // 
            // uiFollowersCheckBox
            // 
            this.uiFollowersCheckBox.AutoSize = true;
            this.uiFollowersCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiFollowersCheckBox.Location = new System.Drawing.Point(3, 3);
            this.uiFollowersCheckBox.Name = "uiFollowersCheckBox";
            this.uiFollowersCheckBox.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.uiFollowersCheckBox.Size = new System.Drawing.Size(128, 23);
            this.uiFollowersCheckBox.TabIndex = 0;
            this.uiFollowersCheckBox.Text = "Recent Follower(s):";
            this.uiFollowersCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiFollowersCheckBox.UseVisualStyleBackColor = true;
            // 
            // uiSubscribersCheckBox
            // 
            this.uiSubscribersCheckBox.AutoSize = true;
            this.uiSubscribersCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSubscribersCheckBox.Location = new System.Drawing.Point(3, 55);
            this.uiSubscribersCheckBox.Name = "uiSubscribersCheckBox";
            this.uiSubscribersCheckBox.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.uiSubscribersCheckBox.Size = new System.Drawing.Size(128, 23);
            this.uiSubscribersCheckBox.TabIndex = 4;
            this.uiSubscribersCheckBox.Text = "Recent Subscriber(s):";
            this.uiSubscribersCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiSubscribersCheckBox.UseVisualStyleBackColor = true;
            // 
            // uiSubscribersFilePathTextBox
            // 
            this.uiSubscribersFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSubscribersFilePathTextBox.Location = new System.Drawing.Point(212, 55);
            this.uiSubscribersFilePathTextBox.Name = "uiSubscribersFilePathTextBox";
            this.uiSubscribersFilePathTextBox.Size = new System.Drawing.Size(269, 20);
            this.uiSubscribersFilePathTextBox.TabIndex = 6;
            // 
            // uiFollowersFilePathTextBox
            // 
            this.uiFollowersFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFollowersFilePathTextBox.Location = new System.Drawing.Point(212, 3);
            this.uiFollowersFilePathTextBox.Name = "uiFollowersFilePathTextBox";
            this.uiFollowersFilePathTextBox.Size = new System.Drawing.Size(269, 20);
            this.uiFollowersFilePathTextBox.TabIndex = 1;
            // 
            // uiFollowersFileBrowseButton
            // 
            this.uiFollowersFileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiFollowersFileBrowseButton.AutoSize = true;
            this.uiFollowersFileBrowseButton.Location = new System.Drawing.Point(487, 3);
            this.uiFollowersFileBrowseButton.Name = "uiFollowersFileBrowseButton";
            this.uiFollowersFileBrowseButton.Size = new System.Drawing.Size(29, 23);
            this.uiFollowersFileBrowseButton.TabIndex = 2;
            this.uiFollowersFileBrowseButton.Text = "...";
            this.uiFollowersFileBrowseButton.UseVisualStyleBackColor = true;
            // 
            // uiSubscribersFileBrowseButton
            // 
            this.uiSubscribersFileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSubscribersFileBrowseButton.AutoSize = true;
            this.uiSubscribersFileBrowseButton.Location = new System.Drawing.Point(487, 55);
            this.uiSubscribersFileBrowseButton.Name = "uiSubscribersFileBrowseButton";
            this.uiSubscribersFileBrowseButton.Size = new System.Drawing.Size(29, 23);
            this.uiSubscribersFileBrowseButton.TabIndex = 7;
            this.uiSubscribersFileBrowseButton.Text = "...";
            this.uiSubscribersFileBrowseButton.UseVisualStyleBackColor = true;
            // 
            // uiViewerCountFileBrowseButton
            // 
            this.uiViewerCountFileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiViewerCountFileBrowseButton.AutoSize = true;
            this.uiViewerCountFileBrowseButton.Location = new System.Drawing.Point(487, 107);
            this.uiViewerCountFileBrowseButton.Name = "uiViewerCountFileBrowseButton";
            this.uiViewerCountFileBrowseButton.Size = new System.Drawing.Size(29, 23);
            this.uiViewerCountFileBrowseButton.TabIndex = 11;
            this.uiViewerCountFileBrowseButton.Text = "...";
            this.uiViewerCountFileBrowseButton.UseVisualStyleBackColor = true;
            // 
            // uiViewerCountFilePathTextBox
            // 
            this.uiViewerCountFilePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiViewerCountFilePathTextBox, 2);
            this.uiViewerCountFilePathTextBox.Location = new System.Drawing.Point(137, 107);
            this.uiViewerCountFilePathTextBox.Name = "uiViewerCountFilePathTextBox";
            this.uiViewerCountFilePathTextBox.Size = new System.Drawing.Size(344, 20);
            this.uiViewerCountFilePathTextBox.TabIndex = 10;
            // 
            // uiFollowersCountNumericUpDown
            // 
            this.uiFollowersCountNumericUpDown.Location = new System.Drawing.Point(137, 3);
            this.uiFollowersCountNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.uiFollowersCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uiFollowersCountNumericUpDown.Name = "uiFollowersCountNumericUpDown";
            this.uiFollowersCountNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.uiFollowersCountNumericUpDown.TabIndex = 12;
            this.uiFollowersCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uiSubscribersCountNumericUpDown
            // 
            this.uiSubscribersCountNumericUpDown.Location = new System.Drawing.Point(137, 55);
            this.uiSubscribersCountNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.uiSubscribersCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uiSubscribersCountNumericUpDown.Name = "uiSubscribersCountNumericUpDown";
            this.uiSubscribersCountNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.uiSubscribersCountNumericUpDown.TabIndex = 13;
            this.uiSubscribersCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uiDiceRollTextBox
            // 
            this.uiDiceRollTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiDiceRollTextBox, 2);
            this.uiDiceRollTextBox.Location = new System.Drawing.Point(137, 165);
            this.uiDiceRollTextBox.Name = "uiDiceRollTextBox";
            this.uiDiceRollTextBox.Size = new System.Drawing.Size(344, 20);
            this.uiDiceRollTextBox.TabIndex = 15;
            // 
            // uiDiceRollButton
            // 
            this.uiDiceRollButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDiceRollButton.AutoSize = true;
            this.uiDiceRollButton.Location = new System.Drawing.Point(487, 165);
            this.uiDiceRollButton.Name = "uiDiceRollButton";
            this.uiDiceRollButton.Size = new System.Drawing.Size(29, 23);
            this.uiDiceRollButton.TabIndex = 16;
            this.uiDiceRollButton.Text = "...";
            this.uiDiceRollButton.UseVisualStyleBackColor = true;
            // 
            // uiAdWarningTextBox
            // 
            this.uiAdWarningTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiAdWarningTextBox, 2);
            this.uiAdWarningTextBox.Location = new System.Drawing.Point(137, 136);
            this.uiAdWarningTextBox.Name = "uiAdWarningTextBox";
            this.uiAdWarningTextBox.Size = new System.Drawing.Size(344, 20);
            this.uiAdWarningTextBox.TabIndex = 19;
            // 
            // uiAdWarningButton
            // 
            this.uiAdWarningButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAdWarningButton.AutoSize = true;
            this.uiAdWarningButton.Location = new System.Drawing.Point(487, 136);
            this.uiAdWarningButton.Name = "uiAdWarningButton";
            this.uiAdWarningButton.Size = new System.Drawing.Size(29, 23);
            this.uiAdWarningButton.TabIndex = 20;
            this.uiAdWarningButton.Text = "...";
            this.uiAdWarningButton.UseVisualStyleBackColor = true;
            // 
            // uiDiceRollLabel
            // 
            this.uiDiceRollLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiDiceRollLabel.AutoSize = true;
            this.uiDiceRollLabel.Location = new System.Drawing.Point(3, 162);
            this.uiDiceRollLabel.Name = "uiDiceRollLabel";
            this.uiDiceRollLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.uiDiceRollLabel.Size = new System.Drawing.Size(128, 18);
            this.uiDiceRollLabel.TabIndex = 17;
            this.uiDiceRollLabel.Text = "Dice Roll Output:";
            this.uiDiceRollLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiSaveFileDialog
            // 
            this.uiSaveFileDialog.DefaultExt = "txt";
            this.uiSaveFileDialog.Filter = "Text files|*.txt";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 251);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Output Settings";
            // 
            // uiClearFollowersOnStartupCheckBox
            // 
            this.uiClearFollowersOnStartupCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiClearFollowersOnStartupCheckBox, 2);
            this.uiClearFollowersOnStartupCheckBox.Location = new System.Drawing.Point(137, 32);
            this.uiClearFollowersOnStartupCheckBox.Name = "uiClearFollowersOnStartupCheckBox";
            this.uiClearFollowersOnStartupCheckBox.Size = new System.Drawing.Size(196, 17);
            this.uiClearFollowersOnStartupCheckBox.TabIndex = 21;
            this.uiClearFollowersOnStartupCheckBox.Text = "Clear file when Twitch Monitor starts";
            this.uiClearFollowersOnStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // uiClearSubscribersOnStartupCheckBox
            // 
            this.uiClearSubscribersOnStartupCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiClearSubscribersOnStartupCheckBox, 2);
            this.uiClearSubscribersOnStartupCheckBox.Location = new System.Drawing.Point(137, 84);
            this.uiClearSubscribersOnStartupCheckBox.Name = "uiClearSubscribersOnStartupCheckBox";
            this.uiClearSubscribersOnStartupCheckBox.Size = new System.Drawing.Size(196, 17);
            this.uiClearSubscribersOnStartupCheckBox.TabIndex = 22;
            this.uiClearSubscribersOnStartupCheckBox.Text = "Clear file when Twitch Monitor starts";
            this.uiClearSubscribersOnStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // FileOutputSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FileOutputSettingsControl";
            this.Size = new System.Drawing.Size(545, 358);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFollowersCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiSubscribersCountNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox uiFollowersCheckBox;
        private System.Windows.Forms.Button uiFollowersFileBrowseButton;
        private System.Windows.Forms.TextBox uiFollowersFilePathTextBox;
        private System.Windows.Forms.CheckBox uiSubscribersCheckBox;
        private System.Windows.Forms.CheckBox uiViewersCheckBox;
        private System.Windows.Forms.TextBox uiSubscribersFilePathTextBox;
        private System.Windows.Forms.Button uiSubscribersFileBrowseButton;
        private System.Windows.Forms.Button uiViewerCountFileBrowseButton;
        private System.Windows.Forms.TextBox uiViewerCountFilePathTextBox;
        private System.Windows.Forms.NumericUpDown uiFollowersCountNumericUpDown;
        private System.Windows.Forms.NumericUpDown uiSubscribersCountNumericUpDown;
        private System.Windows.Forms.SaveFileDialog uiSaveFileDialog;
        private System.Windows.Forms.TextBox uiDiceRollTextBox;
        private System.Windows.Forms.Button uiDiceRollButton;
        private System.Windows.Forms.Label uiDiceRollLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox uiAdWarningCheckBox;
        private System.Windows.Forms.TextBox uiAdWarningTextBox;
        private System.Windows.Forms.Button uiAdWarningButton;
        private System.Windows.Forms.CheckBox uiClearFollowersOnStartupCheckBox;
        private System.Windows.Forms.CheckBox uiClearSubscribersOnStartupCheckBox;
    }
}

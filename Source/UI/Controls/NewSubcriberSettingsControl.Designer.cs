namespace TwitchMonitor.UI.Controls
{
    partial class NewSubcriberSettingsControl
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
            this.uiShowNewSubDialogCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiPreviewButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uiImagePathTextBox = new System.Windows.Forms.TextBox();
            this.uiImagePathButton = new System.Windows.Forms.Button();
            this.uiWidthLabel = new System.Windows.Forms.Label();
            this.uiHeightLabel = new System.Windows.Forms.Label();
            this.uiXLabel = new System.Windows.Forms.Label();
            this.uiYLabel = new System.Windows.Forms.Label();
            this.uiWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiXNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiYNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // uiShowNewSubDialogCheckBox
            // 
            this.uiShowNewSubDialogCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiShowNewSubDialogCheckBox, 3);
            this.uiShowNewSubDialogCheckBox.Location = new System.Drawing.Point(3, 3);
            this.uiShowNewSubDialogCheckBox.Name = "uiShowNewSubDialogCheckBox";
            this.uiShowNewSubDialogCheckBox.Size = new System.Drawing.Size(164, 17);
            this.uiShowNewSubDialogCheckBox.TabIndex = 0;
            this.uiShowNewSubDialogCheckBox.Text = "Show New Subscriber Dialog";
            this.uiShowNewSubDialogCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(454, 207);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification Dialog Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.uiPreviewButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiShowNewSubDialogCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiImagePathTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiImagePathButton, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiWidthLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiHeightLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiXLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiYLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.uiWidthNumericUpDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiHeightNumericUpDown, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiXNumericUpDown, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiYNumericUpDown, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 184);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // uiPreviewButton
            // 
            this.uiPreviewButton.AutoSize = true;
            this.uiPreviewButton.Location = new System.Drawing.Point(148, 55);
            this.uiPreviewButton.Name = "uiPreviewButton";
            this.uiPreviewButton.Size = new System.Drawing.Size(115, 23);
            this.uiPreviewButton.TabIndex = 2;
            this.uiPreviewButton.Text = "Set Window Position";
            this.uiPreviewButton.UseVisualStyleBackColor = true;
            this.uiPreviewButton.Click += new System.EventHandler(this.uiPreviewButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image Path:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiImagePathTextBox
            // 
            this.uiImagePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiImagePathTextBox, 2);
            this.uiImagePathTextBox.Location = new System.Drawing.Point(73, 26);
            this.uiImagePathTextBox.Name = "uiImagePathTextBox";
            this.uiImagePathTextBox.Size = new System.Drawing.Size(328, 20);
            this.uiImagePathTextBox.TabIndex = 2;
            // 
            // uiImagePathButton
            // 
            this.uiImagePathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiImagePathButton.Location = new System.Drawing.Point(407, 26);
            this.uiImagePathButton.Name = "uiImagePathButton";
            this.uiImagePathButton.Size = new System.Drawing.Size(34, 23);
            this.uiImagePathButton.TabIndex = 3;
            this.uiImagePathButton.Text = "...";
            this.uiImagePathButton.UseVisualStyleBackColor = true;
            this.uiImagePathButton.Click += new System.EventHandler(this.uiImagePathButton_Click);
            // 
            // uiWidthLabel
            // 
            this.uiWidthLabel.AutoSize = true;
            this.uiWidthLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiWidthLabel.Location = new System.Drawing.Point(3, 52);
            this.uiWidthLabel.Name = "uiWidthLabel";
            this.uiWidthLabel.Size = new System.Drawing.Size(64, 29);
            this.uiWidthLabel.TabIndex = 4;
            this.uiWidthLabel.Text = "Width:";
            this.uiWidthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiHeightLabel
            // 
            this.uiHeightLabel.AutoSize = true;
            this.uiHeightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiHeightLabel.Location = new System.Drawing.Point(3, 81);
            this.uiHeightLabel.Name = "uiHeightLabel";
            this.uiHeightLabel.Size = new System.Drawing.Size(64, 26);
            this.uiHeightLabel.TabIndex = 5;
            this.uiHeightLabel.Text = "Height:";
            this.uiHeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiXLabel
            // 
            this.uiXLabel.AutoSize = true;
            this.uiXLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiXLabel.Location = new System.Drawing.Point(3, 107);
            this.uiXLabel.Name = "uiXLabel";
            this.uiXLabel.Size = new System.Drawing.Size(64, 26);
            this.uiXLabel.TabIndex = 6;
            this.uiXLabel.Text = "X:";
            this.uiXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiYLabel
            // 
            this.uiYLabel.AutoSize = true;
            this.uiYLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiYLabel.Location = new System.Drawing.Point(3, 133);
            this.uiYLabel.Name = "uiYLabel";
            this.uiYLabel.Size = new System.Drawing.Size(64, 26);
            this.uiYLabel.TabIndex = 7;
            this.uiYLabel.Text = "Y:";
            this.uiYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiWidthNumericUpDown
            // 
            this.uiWidthNumericUpDown.Location = new System.Drawing.Point(73, 55);
            this.uiWidthNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uiWidthNumericUpDown.Name = "uiWidthNumericUpDown";
            this.uiWidthNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.uiWidthNumericUpDown.TabIndex = 8;
            // 
            // uiHeightNumericUpDown
            // 
            this.uiHeightNumericUpDown.Location = new System.Drawing.Point(73, 84);
            this.uiHeightNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uiHeightNumericUpDown.Name = "uiHeightNumericUpDown";
            this.uiHeightNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.uiHeightNumericUpDown.TabIndex = 9;
            // 
            // uiXNumericUpDown
            // 
            this.uiXNumericUpDown.Location = new System.Drawing.Point(73, 110);
            this.uiXNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uiXNumericUpDown.Name = "uiXNumericUpDown";
            this.uiXNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.uiXNumericUpDown.TabIndex = 10;
            // 
            // uiYNumericUpDown
            // 
            this.uiYNumericUpDown.Location = new System.Drawing.Point(73, 136);
            this.uiYNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.uiYNumericUpDown.Name = "uiYNumericUpDown";
            this.uiYNumericUpDown.Size = new System.Drawing.Size(69, 20);
            this.uiYNumericUpDown.TabIndex = 11;
            // 
            // uiOpenFileDialog
            // 
            this.uiOpenFileDialog.FileName = "openFileDialog1";
            // 
            // NewSubcriberSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "NewSubcriberSettingsControl";
            this.Size = new System.Drawing.Size(460, 279);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiXNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiYNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox uiShowNewSubDialogCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiImagePathTextBox;
        private System.Windows.Forms.Button uiImagePathButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog uiOpenFileDialog;
        private System.Windows.Forms.Button uiPreviewButton;
        private System.Windows.Forms.Label uiWidthLabel;
        private System.Windows.Forms.Label uiHeightLabel;
        private System.Windows.Forms.Label uiXLabel;
        private System.Windows.Forms.Label uiYLabel;
        private System.Windows.Forms.NumericUpDown uiWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown uiHeightNumericUpDown;
        private System.Windows.Forms.NumericUpDown uiXNumericUpDown;
        private System.Windows.Forms.NumericUpDown uiYNumericUpDown;
    }
}
namespace TwitchMonitor.UI.Controls
{
    partial class IrcFontsAndColorsSettingsControl
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiTextColorLabel = new System.Windows.Forms.Label();
            this.uiShowAllMessagesCheckBox = new System.Windows.Forms.CheckBox();
            this.uiTextColorButton = new System.Windows.Forms.Button();
            this.uiTimestampColorButton = new System.Windows.Forms.Button();
            this.uiShowTimestampCheckBox = new System.Windows.Forms.CheckBox();
            this.uiTimestampColorLabel = new System.Windows.Forms.Label();
            this.uiErrorColorButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.uiStatusColorButton = new System.Windows.Forms.Button();
            this.uiErrorColorLabel = new System.Windows.Forms.Label();
            this.uiBackColorButton = new System.Windows.Forms.Button();
            this.uiModColorLabel = new System.Windows.Forms.Label();
            this.uiModColorButton = new System.Windows.Forms.Button();
            this.uiStatusColorLabel = new System.Windows.Forms.Label();
            this.uiColorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(10, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 142);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fonts and Color Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.uiTextColorLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiShowAllMessagesCheckBox, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiTextColorButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiTimestampColorButton, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiShowTimestampCheckBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiTimestampColorLabel, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiErrorColorButton, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiStatusColorButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiErrorColorLabel, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiBackColorButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiModColorLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiModColorButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiStatusColorLabel, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(467, 123);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // uiTextColorLabel
            // 
            this.uiTextColorLabel.AutoSize = true;
            this.uiTextColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTextColorLabel.Location = new System.Drawing.Point(8, 5);
            this.uiTextColorLabel.Name = "uiTextColorLabel";
            this.uiTextColorLabel.Size = new System.Drawing.Size(95, 29);
            this.uiTextColorLabel.TabIndex = 0;
            this.uiTextColorLabel.Text = "Text Color:";
            this.uiTextColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiShowAllMessagesCheckBox
            // 
            this.uiShowAllMessagesCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiShowAllMessagesCheckBox, 2);
            this.uiShowAllMessagesCheckBox.Location = new System.Drawing.Point(227, 95);
            this.uiShowAllMessagesCheckBox.Name = "uiShowAllMessagesCheckBox";
            this.uiShowAllMessagesCheckBox.Size = new System.Drawing.Size(118, 17);
            this.uiShowAllMessagesCheckBox.TabIndex = 17;
            this.uiShowAllMessagesCheckBox.Text = "Show All Messages";
            this.uiShowAllMessagesCheckBox.UseVisualStyleBackColor = true;
            // 
            // uiTextColorButton
            // 
            this.uiTextColorButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uiTextColorButton.Location = new System.Drawing.Point(109, 8);
            this.uiTextColorButton.Name = "uiTextColorButton";
            this.uiTextColorButton.Size = new System.Drawing.Size(69, 23);
            this.uiTextColorButton.TabIndex = 4;
            this.uiTextColorButton.Text = "...";
            this.uiTextColorButton.UseVisualStyleBackColor = true;
            // 
            // uiTimestampColorButton
            // 
            this.uiTimestampColorButton.Location = new System.Drawing.Point(346, 66);
            this.uiTimestampColorButton.Name = "uiTimestampColorButton";
            this.uiTimestampColorButton.Size = new System.Drawing.Size(70, 23);
            this.uiTimestampColorButton.TabIndex = 15;
            this.uiTimestampColorButton.Text = "...";
            this.uiTimestampColorButton.UseVisualStyleBackColor = true;
            // 
            // uiShowTimestampCheckBox
            // 
            this.uiShowTimestampCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiShowTimestampCheckBox, 2);
            this.uiShowTimestampCheckBox.Location = new System.Drawing.Point(8, 95);
            this.uiShowTimestampCheckBox.Name = "uiShowTimestampCheckBox";
            this.uiShowTimestampCheckBox.Size = new System.Drawing.Size(107, 17);
            this.uiShowTimestampCheckBox.TabIndex = 16;
            this.uiShowTimestampCheckBox.Text = "Show Timestamp";
            this.uiShowTimestampCheckBox.UseVisualStyleBackColor = true;
            // 
            // uiTimestampColorLabel
            // 
            this.uiTimestampColorLabel.AutoSize = true;
            this.uiTimestampColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTimestampColorLabel.Location = new System.Drawing.Point(227, 63);
            this.uiTimestampColorLabel.Name = "uiTimestampColorLabel";
            this.uiTimestampColorLabel.Size = new System.Drawing.Size(113, 29);
            this.uiTimestampColorLabel.TabIndex = 11;
            this.uiTimestampColorLabel.Text = "Timestamp Color:";
            this.uiTimestampColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiErrorColorButton
            // 
            this.uiErrorColorButton.Location = new System.Drawing.Point(346, 37);
            this.uiErrorColorButton.Name = "uiErrorColorButton";
            this.uiErrorColorButton.Size = new System.Drawing.Size(70, 23);
            this.uiErrorColorButton.TabIndex = 14;
            this.uiErrorColorButton.Text = "...";
            this.uiErrorColorButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "Background Color:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiStatusColorButton
            // 
            this.uiStatusColorButton.Location = new System.Drawing.Point(346, 8);
            this.uiStatusColorButton.Name = "uiStatusColorButton";
            this.uiStatusColorButton.Size = new System.Drawing.Size(70, 23);
            this.uiStatusColorButton.TabIndex = 13;
            this.uiStatusColorButton.Text = "...";
            this.uiStatusColorButton.UseVisualStyleBackColor = true;
            // 
            // uiErrorColorLabel
            // 
            this.uiErrorColorLabel.AutoSize = true;
            this.uiErrorColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiErrorColorLabel.Location = new System.Drawing.Point(227, 34);
            this.uiErrorColorLabel.Name = "uiErrorColorLabel";
            this.uiErrorColorLabel.Size = new System.Drawing.Size(113, 29);
            this.uiErrorColorLabel.TabIndex = 10;
            this.uiErrorColorLabel.Text = "Error Message Color:";
            this.uiErrorColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiBackColorButton
            // 
            this.uiBackColorButton.Location = new System.Drawing.Point(109, 37);
            this.uiBackColorButton.Name = "uiBackColorButton";
            this.uiBackColorButton.Size = new System.Drawing.Size(69, 23);
            this.uiBackColorButton.TabIndex = 5;
            this.uiBackColorButton.Text = "...";
            this.uiBackColorButton.UseVisualStyleBackColor = true;
            // 
            // uiModColorLabel
            // 
            this.uiModColorLabel.AutoSize = true;
            this.uiModColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiModColorLabel.Location = new System.Drawing.Point(8, 63);
            this.uiModColorLabel.Name = "uiModColorLabel";
            this.uiModColorLabel.Size = new System.Drawing.Size(95, 29);
            this.uiModColorLabel.TabIndex = 12;
            this.uiModColorLabel.Text = "Moderator Color:";
            this.uiModColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiModColorButton
            // 
            this.uiModColorButton.Location = new System.Drawing.Point(109, 66);
            this.uiModColorButton.Name = "uiModColorButton";
            this.uiModColorButton.Size = new System.Drawing.Size(69, 23);
            this.uiModColorButton.TabIndex = 8;
            this.uiModColorButton.Text = "...";
            this.uiModColorButton.UseVisualStyleBackColor = true;
            // 
            // uiStatusColorLabel
            // 
            this.uiStatusColorLabel.AutoSize = true;
            this.uiStatusColorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiStatusColorLabel.Location = new System.Drawing.Point(227, 5);
            this.uiStatusColorLabel.Name = "uiStatusColorLabel";
            this.uiStatusColorLabel.Size = new System.Drawing.Size(113, 29);
            this.uiStatusColorLabel.TabIndex = 9;
            this.uiStatusColorLabel.Text = "Status Message Color:";
            this.uiStatusColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiColorDialog
            // 
            this.uiColorDialog.AnyColor = true;
            this.uiColorDialog.FullOpen = true;
            // 
            // IrcFontsAndColorsSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "IrcFontsAndColorsSettingsControl";
            this.Size = new System.Drawing.Size(493, 244);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label uiTextColorLabel;
        private System.Windows.Forms.CheckBox uiShowAllMessagesCheckBox;
        private System.Windows.Forms.Button uiTextColorButton;
        private System.Windows.Forms.Button uiTimestampColorButton;
        private System.Windows.Forms.CheckBox uiShowTimestampCheckBox;
        private System.Windows.Forms.Label uiTimestampColorLabel;
        private System.Windows.Forms.Button uiErrorColorButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button uiStatusColorButton;
        private System.Windows.Forms.Label uiErrorColorLabel;
        private System.Windows.Forms.Button uiBackColorButton;
        private System.Windows.Forms.Label uiModColorLabel;
        private System.Windows.Forms.Button uiModColorButton;
        private System.Windows.Forms.Label uiStatusColorLabel;
        private System.Windows.Forms.ColorDialog uiColorDialog;
    }
}

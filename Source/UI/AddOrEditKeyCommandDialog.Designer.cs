namespace TwitchMonitor.UI
{
    partial class AddOrEditKeyCommandDialog
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiCommandTextBox = new System.Windows.Forms.TextBox();
            this.uiChannelNameLabel = new System.Windows.Forms.Label();
            this.uiVerifyingLabel = new System.Windows.Forms.Label();
            this.uiOkButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiMessageTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiKeyCommandComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiIrcCommandTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.uiCommandTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiChannelNameLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiMessageTextBox, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiKeyCommandComboBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiVerifyingLabel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.uiOkButton, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.uiCancelButton, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiIrcCommandTextBox, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(391, 175);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // uiCommandTextBox
            // 
            this.uiCommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiCommandTextBox, 3);
            this.uiCommandTextBox.Location = new System.Drawing.Point(114, 23);
            this.uiCommandTextBox.Name = "uiCommandTextBox";
            this.uiCommandTextBox.Size = new System.Drawing.Size(254, 20);
            this.uiCommandTextBox.TabIndex = 1;
            // 
            // uiChannelNameLabel
            // 
            this.uiChannelNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiChannelNameLabel.AutoSize = true;
            this.uiChannelNameLabel.Location = new System.Drawing.Point(13, 20);
            this.uiChannelNameLabel.Name = "uiChannelNameLabel";
            this.uiChannelNameLabel.Size = new System.Drawing.Size(95, 26);
            this.uiChannelNameLabel.TabIndex = 0;
            this.uiChannelNameLabel.Text = "Name:";
            this.uiChannelNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiVerifyingLabel
            // 
            this.uiVerifyingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiVerifyingLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiVerifyingLabel, 2);
            this.uiVerifyingLabel.Location = new System.Drawing.Point(13, 125);
            this.uiVerifyingLabel.Name = "uiVerifyingLabel";
            this.uiVerifyingLabel.Size = new System.Drawing.Size(193, 30);
            this.uiVerifyingLabel.TabIndex = 4;
            this.uiVerifyingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiOkButton
            // 
            this.uiOkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiOkButton.Location = new System.Drawing.Point(212, 128);
            this.uiOkButton.Name = "uiOkButton";
            this.uiOkButton.Size = new System.Drawing.Size(75, 23);
            this.uiOkButton.TabIndex = 3;
            this.uiOkButton.Text = "OK";
            this.uiOkButton.UseVisualStyleBackColor = true;
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancelButton.Location = new System.Drawing.Point(293, 128);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uiCancelButton.TabIndex = 2;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // uiMessageTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiMessageTextBox, 3);
            this.uiMessageTextBox.Location = new System.Drawing.Point(114, 76);
            this.uiMessageTextBox.Name = "uiMessageTextBox";
            this.uiMessageTextBox.Size = new System.Drawing.Size(254, 20);
            this.uiMessageTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(95, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Custom Command:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Key Command:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiKeyCommandComboBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiKeyCommandComboBox, 3);
            this.uiKeyCommandComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiKeyCommandComboBox.FormattingEnabled = true;
            this.uiKeyCommandComboBox.Items.AddRange(new object[] {
            "Custom",
            "ESC",
            "\'W\' Key",
            "\'A\' Key",
            "\'S\' Key",
            "\'D\' Key",
            "\'E\' Key"});
            this.uiKeyCommandComboBox.Location = new System.Drawing.Point(114, 49);
            this.uiKeyCommandComboBox.Name = "uiKeyCommandComboBox";
            this.uiKeyCommandComboBox.Size = new System.Drawing.Size(173, 21);
            this.uiKeyCommandComboBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(13, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "IRC Command:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiIrcCommandTextBox
            // 
            this.uiIrcCommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiIrcCommandTextBox, 3);
            this.uiIrcCommandTextBox.Location = new System.Drawing.Point(114, 102);
            this.uiIrcCommandTextBox.Name = "uiIrcCommandTextBox";
            this.uiIrcCommandTextBox.Size = new System.Drawing.Size(254, 20);
            this.uiIrcCommandTextBox.TabIndex = 10;
            // 
            // AddOrEditKeyCommandDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 175);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOrEditKeyCommandDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Key Command";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox uiCommandTextBox;
        private System.Windows.Forms.Label uiChannelNameLabel;
        private System.Windows.Forms.Label uiVerifyingLabel;
        private System.Windows.Forms.Button uiOkButton;
        private System.Windows.Forms.Button uiCancelButton;
        private System.Windows.Forms.TextBox uiMessageTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox uiKeyCommandComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox uiIrcCommandTextBox;
    }
}
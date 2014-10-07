namespace TwitchMonitor.UI
{
    partial class EditIrcCommandDialog
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
            this.uiVerifyingLabel = new System.Windows.Forms.Label();
            this.uiOkButton = new System.Windows.Forms.Button();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiCommandTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiChannelNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uiMessageTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiVerifyingLabel
            // 
            this.uiVerifyingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiVerifyingLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiVerifyingLabel, 2);
            this.uiVerifyingLabel.Location = new System.Drawing.Point(13, 140);
            this.uiVerifyingLabel.Name = "uiVerifyingLabel";
            this.uiVerifyingLabel.Size = new System.Drawing.Size(246, 29);
            this.uiVerifyingLabel.TabIndex = 4;
            this.uiVerifyingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiOkButton
            // 
            this.uiOkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiOkButton.Location = new System.Drawing.Point(265, 143);
            this.uiOkButton.Name = "uiOkButton";
            this.uiOkButton.Size = new System.Drawing.Size(75, 23);
            this.uiOkButton.TabIndex = 3;
            this.uiOkButton.Text = "OK";
            this.uiOkButton.UseVisualStyleBackColor = true;
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancelButton.Location = new System.Drawing.Point(346, 143);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uiCancelButton.TabIndex = 2;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // uiCommandTextBox
            // 
            this.uiCommandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiCommandTextBox, 3);
            this.uiCommandTextBox.Location = new System.Drawing.Point(76, 23);
            this.uiCommandTextBox.Name = "uiCommandTextBox";
            this.uiCommandTextBox.Size = new System.Drawing.Size(345, 20);
            this.uiCommandTextBox.TabIndex = 1;
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
            this.tableLayoutPanel1.Controls.Add(this.uiOkButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiCancelButton, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiVerifyingLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiMessageTextBox, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 189);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // uiChannelNameLabel
            // 
            this.uiChannelNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiChannelNameLabel.AutoSize = true;
            this.uiChannelNameLabel.Location = new System.Drawing.Point(13, 20);
            this.uiChannelNameLabel.Name = "uiChannelNameLabel";
            this.uiChannelNameLabel.Size = new System.Drawing.Size(57, 26);
            this.uiChannelNameLabel.TabIndex = 0;
            this.uiChannelNameLabel.Text = "Command:";
            this.uiChannelNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(57, 94);
            this.label1.TabIndex = 5;
            this.label1.Text = "Text:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiMessageTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiMessageTextBox, 3);
            this.uiMessageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiMessageTextBox.Location = new System.Drawing.Point(76, 49);
            this.uiMessageTextBox.Multiline = true;
            this.uiMessageTextBox.Name = "uiMessageTextBox";
            this.uiMessageTextBox.Size = new System.Drawing.Size(345, 88);
            this.uiMessageTextBox.TabIndex = 6;
            // 
            // EditIrcCommandDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 189);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditIrcCommandDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add or Edit IRC Command";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label uiVerifyingLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button uiOkButton;
        private System.Windows.Forms.Button uiCancelButton;
        private System.Windows.Forms.TextBox uiCommandTextBox;
        private System.Windows.Forms.Label uiChannelNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiMessageTextBox;
    }
}
namespace TwitchMonitor.UI
{
    partial class AddChannelProfileDialog
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
            this.uiChannelNameLabel = new System.Windows.Forms.Label();
            this.uiChannelNameTextBox = new System.Windows.Forms.TextBox();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiOkButton = new System.Windows.Forms.Button();
            this.uiVerifyingLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiChannelNameLabel
            // 
            this.uiChannelNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiChannelNameLabel.AutoSize = true;
            this.uiChannelNameLabel.Location = new System.Drawing.Point(13, 18);
            this.uiChannelNameLabel.Name = "uiChannelNameLabel";
            this.uiChannelNameLabel.Size = new System.Drawing.Size(80, 26);
            this.uiChannelNameLabel.TabIndex = 0;
            this.uiChannelNameLabel.Text = "Channel Name:";
            this.uiChannelNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiChannelNameTextBox
            // 
            this.uiChannelNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiChannelNameTextBox, 3);
            this.uiChannelNameTextBox.Location = new System.Drawing.Point(99, 21);
            this.uiChannelNameTextBox.Name = "uiChannelNameTextBox";
            this.uiChannelNameTextBox.Size = new System.Drawing.Size(288, 20);
            this.uiChannelNameTextBox.TabIndex = 1;
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancelButton.Location = new System.Drawing.Point(312, 47);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uiCancelButton.TabIndex = 2;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // uiOkButton
            // 
            this.uiOkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiOkButton.Location = new System.Drawing.Point(231, 47);
            this.uiOkButton.Name = "uiOkButton";
            this.uiOkButton.Size = new System.Drawing.Size(75, 23);
            this.uiOkButton.TabIndex = 3;
            this.uiOkButton.Text = "OK";
            this.uiOkButton.UseVisualStyleBackColor = true;
            this.uiOkButton.Click += new System.EventHandler(this.uiOkButton_Click);
            // 
            // uiVerifyingLabel
            // 
            this.uiVerifyingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiVerifyingLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiVerifyingLabel, 2);
            this.uiVerifyingLabel.Location = new System.Drawing.Point(13, 44);
            this.uiVerifyingLabel.Name = "uiVerifyingLabel";
            this.uiVerifyingLabel.Size = new System.Drawing.Size(212, 29);
            this.uiVerifyingLabel.TabIndex = 4;
            this.uiVerifyingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.tableLayoutPanel1.Controls.Add(this.uiVerifyingLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiOkButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiCancelButton, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiChannelNameTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiChannelNameLabel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 91);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // AddChannelProfileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 91);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddChannelProfileDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Channel";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label uiChannelNameLabel;
        private System.Windows.Forms.TextBox uiChannelNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label uiVerifyingLabel;
        private System.Windows.Forms.Button uiOkButton;
        private System.Windows.Forms.Button uiCancelButton;
    }
}
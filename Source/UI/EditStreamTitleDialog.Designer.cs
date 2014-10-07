namespace TwitchMonitor.UI
{
    partial class EditStreamTitleDialog
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
            this.uiStreamTitleTextBox = new System.Windows.Forms.TextBox();
            this.uiCancelButton = new System.Windows.Forms.Button();
            this.uiOkButton = new System.Windows.Forms.Button();
            this.uiCharacterCountLabel = new System.Windows.Forms.Label();
            this.uiCurrentGameTextBox = new System.Windows.Forms.TextBox();
            this.uiStreamTitleLabel = new System.Windows.Forms.Label();
            this.uiCurrentGameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.uiStreamTitleTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiCancelButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiOkButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiCharacterCountLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiCurrentGameTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiStreamTitleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiCurrentGameLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 252);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // uiStreamTitleTextBox
            // 
            this.uiStreamTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiStreamTitleTextBox, 3);
            this.uiStreamTitleTextBox.Location = new System.Drawing.Point(90, 5);
            this.uiStreamTitleTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.uiStreamTitleTextBox.Multiline = true;
            this.uiStreamTitleTextBox.Name = "uiStreamTitleTextBox";
            this.uiStreamTitleTextBox.Size = new System.Drawing.Size(414, 183);
            this.uiStreamTitleTextBox.TabIndex = 3;
            this.uiStreamTitleTextBox.TextChanged += new System.EventHandler(this.uiStreamTitleTextBox_TextChanged);
            // 
            // uiCancelButton
            // 
            this.uiCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uiCancelButton.Location = new System.Drawing.Point(431, 226);
            this.uiCancelButton.Name = "uiCancelButton";
            this.uiCancelButton.Size = new System.Drawing.Size(75, 23);
            this.uiCancelButton.TabIndex = 1;
            this.uiCancelButton.Text = "Cancel";
            this.uiCancelButton.UseVisualStyleBackColor = true;
            // 
            // uiOkButton
            // 
            this.uiOkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uiOkButton.Location = new System.Drawing.Point(350, 226);
            this.uiOkButton.Name = "uiOkButton";
            this.uiOkButton.Size = new System.Drawing.Size(75, 23);
            this.uiOkButton.TabIndex = 2;
            this.uiOkButton.Text = "OK";
            this.uiOkButton.UseVisualStyleBackColor = true;
            // 
            // uiCharacterCountLabel
            // 
            this.uiCharacterCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCharacterCountLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiCharacterCountLabel, 2);
            this.uiCharacterCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiCharacterCountLabel.Location = new System.Drawing.Point(3, 223);
            this.uiCharacterCountLabel.Name = "uiCharacterCountLabel";
            this.uiCharacterCountLabel.Size = new System.Drawing.Size(341, 29);
            this.uiCharacterCountLabel.TabIndex = 4;
            this.uiCharacterCountLabel.Text = "[Charater Count]";
            this.uiCharacterCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiCurrentGameTextBox
            // 
            this.uiCurrentGameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiCurrentGameTextBox, 3);
            this.uiCurrentGameTextBox.Location = new System.Drawing.Point(90, 198);
            this.uiCurrentGameTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.uiCurrentGameTextBox.Name = "uiCurrentGameTextBox";
            this.uiCurrentGameTextBox.Size = new System.Drawing.Size(414, 20);
            this.uiCurrentGameTextBox.TabIndex = 5;
            // 
            // uiStreamTitleLabel
            // 
            this.uiStreamTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiStreamTitleLabel.AutoSize = true;
            this.uiStreamTitleLabel.Location = new System.Drawing.Point(5, 5);
            this.uiStreamTitleLabel.Margin = new System.Windows.Forms.Padding(5);
            this.uiStreamTitleLabel.Name = "uiStreamTitleLabel";
            this.uiStreamTitleLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.uiStreamTitleLabel.Size = new System.Drawing.Size(75, 183);
            this.uiStreamTitleLabel.TabIndex = 6;
            this.uiStreamTitleLabel.Text = "Stream Title:";
            this.uiStreamTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiCurrentGameLabel
            // 
            this.uiCurrentGameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCurrentGameLabel.AutoSize = true;
            this.uiCurrentGameLabel.Location = new System.Drawing.Point(5, 198);
            this.uiCurrentGameLabel.Margin = new System.Windows.Forms.Padding(5);
            this.uiCurrentGameLabel.Name = "uiCurrentGameLabel";
            this.uiCurrentGameLabel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.uiCurrentGameLabel.Size = new System.Drawing.Size(75, 20);
            this.uiCurrentGameLabel.TabIndex = 7;
            this.uiCurrentGameLabel.Text = "Current Game:";
            this.uiCurrentGameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // EditStreamTitleDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 252);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "EditStreamTitleDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Twitch Monitor - Edit Stream Title";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox uiStreamTitleTextBox;
        private System.Windows.Forms.Label uiCharacterCountLabel;
        private System.Windows.Forms.Button uiOkButton;
        private System.Windows.Forms.Button uiCancelButton;
        private System.Windows.Forms.TextBox uiCurrentGameTextBox;
        private System.Windows.Forms.Label uiStreamTitleLabel;
        private System.Windows.Forms.Label uiCurrentGameLabel;
    }
}
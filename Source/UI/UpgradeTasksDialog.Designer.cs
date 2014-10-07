namespace TwitchMonitor.UI
{
    partial class UpgradeTasksDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpgradeTasksDialog));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiStatusProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiStatusLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.uiStatusProgressBar, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiStatusLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(323, 91);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // uiStatusProgressBar
            // 
            this.uiStatusProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiStatusProgressBar.Location = new System.Drawing.Point(13, 48);
            this.uiStatusProgressBar.Name = "uiStatusProgressBar";
            this.uiStatusProgressBar.Size = new System.Drawing.Size(297, 15);
            this.uiStatusProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.uiStatusProgressBar.TabIndex = 0;
            // 
            // uiStatusLabel
            // 
            this.uiStatusLabel.AutoSize = true;
            this.uiStatusLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiStatusLabel.Location = new System.Drawing.Point(13, 27);
            this.uiStatusLabel.Name = "uiStatusLabel";
            this.uiStatusLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.uiStatusLabel.Size = new System.Drawing.Size(297, 18);
            this.uiStatusLabel.TabIndex = 1;
            this.uiStatusLabel.Text = "[STATUS]";
            this.uiStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpgradeTasksDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 91);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpgradeTasksDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Twitch Monitor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar uiStatusProgressBar;
        private System.Windows.Forms.Label uiStatusLabel;
    }
}
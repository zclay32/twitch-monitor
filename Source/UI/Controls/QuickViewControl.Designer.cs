namespace TwitchMonitor.Controls
{
    partial class QuickViewControl
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
            this.uiSubscriberCountMiniViewTextLabel = new TwitchMonitor.Controls.MiniViewTextLabel();
            this.uiFollowersMiniViewCaptionLabel = new TwitchMonitor.Controls.MiniViewCaptionLabel();
            this.uiFollowersCountMiniViewTextLabel = new TwitchMonitor.Controls.MiniViewTextLabel();
            this.uiViewerCountMiniViewTextLabel = new TwitchMonitor.Controls.MiniViewTextLabel();
            this.uiRecentActivityListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiViewersMiniViewCaptionLabel = new TwitchMonitor.Controls.MiniViewCaptionLabel();
            this.uiSubscribersMiniViewCaptionLabel = new TwitchMonitor.Controls.MiniViewCaptionLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiSubscriberCountMiniViewTextLabel
            // 
            this.uiSubscriberCountMiniViewTextLabel.AutoSize = true;
            this.uiSubscriberCountMiniViewTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSubscriberCountMiniViewTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSubscriberCountMiniViewTextLabel.Location = new System.Drawing.Point(96, 0);
            this.uiSubscriberCountMiniViewTextLabel.Name = "uiSubscriberCountMiniViewTextLabel";
            this.uiSubscriberCountMiniViewTextLabel.Size = new System.Drawing.Size(65, 17);
            this.uiSubscriberCountMiniViewTextLabel.TabIndex = 1;
            this.uiSubscriberCountMiniViewTextLabel.Text = "[COUNT]";
            this.uiSubscriberCountMiniViewTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiFollowersMiniViewCaptionLabel
            // 
            this.uiFollowersMiniViewCaptionLabel.AutoSize = true;
            this.uiFollowersMiniViewCaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiFollowersMiniViewCaptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFollowersMiniViewCaptionLabel.Location = new System.Drawing.Point(3, 17);
            this.uiFollowersMiniViewCaptionLabel.Name = "uiFollowersMiniViewCaptionLabel";
            this.uiFollowersMiniViewCaptionLabel.Size = new System.Drawing.Size(87, 17);
            this.uiFollowersMiniViewCaptionLabel.TabIndex = 2;
            this.uiFollowersMiniViewCaptionLabel.Text = "Followers:";
            this.uiFollowersMiniViewCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiFollowersCountMiniViewTextLabel
            // 
            this.uiFollowersCountMiniViewTextLabel.AutoSize = true;
            this.uiFollowersCountMiniViewTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiFollowersCountMiniViewTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFollowersCountMiniViewTextLabel.Location = new System.Drawing.Point(96, 17);
            this.uiFollowersCountMiniViewTextLabel.Name = "uiFollowersCountMiniViewTextLabel";
            this.uiFollowersCountMiniViewTextLabel.Size = new System.Drawing.Size(65, 17);
            this.uiFollowersCountMiniViewTextLabel.TabIndex = 3;
            this.uiFollowersCountMiniViewTextLabel.Text = "[COUNT]";
            this.uiFollowersCountMiniViewTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiViewerCountMiniViewTextLabel
            // 
            this.uiViewerCountMiniViewTextLabel.AutoSize = true;
            this.uiViewerCountMiniViewTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiViewerCountMiniViewTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiViewerCountMiniViewTextLabel.Location = new System.Drawing.Point(96, 34);
            this.uiViewerCountMiniViewTextLabel.Name = "uiViewerCountMiniViewTextLabel";
            this.uiViewerCountMiniViewTextLabel.Size = new System.Drawing.Size(65, 17);
            this.uiViewerCountMiniViewTextLabel.TabIndex = 5;
            this.uiViewerCountMiniViewTextLabel.Text = "[COUNT]";
            this.uiViewerCountMiniViewTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiRecentActivityListBox
            // 
            this.uiRecentActivityListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiRecentActivityListBox.FormattingEnabled = true;
            this.uiRecentActivityListBox.Location = new System.Drawing.Point(167, 3);
            this.uiRecentActivityListBox.Name = "uiRecentActivityListBox";
            this.tableLayoutPanel1.SetRowSpan(this.uiRecentActivityListBox, 4);
            this.uiRecentActivityListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.uiRecentActivityListBox.Size = new System.Drawing.Size(183, 77);
            this.uiRecentActivityListBox.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.uiSubscriberCountMiniViewTextLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiFollowersMiniViewCaptionLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiFollowersCountMiniViewTextLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiViewersMiniViewCaptionLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiViewerCountMiniViewTextLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiRecentActivityListBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiSubscribersMiniViewCaptionLabel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(353, 83);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // uiViewersMiniViewCaptionLabel
            // 
            this.uiViewersMiniViewCaptionLabel.AutoSize = true;
            this.uiViewersMiniViewCaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiViewersMiniViewCaptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiViewersMiniViewCaptionLabel.Location = new System.Drawing.Point(3, 34);
            this.uiViewersMiniViewCaptionLabel.Name = "uiViewersMiniViewCaptionLabel";
            this.uiViewersMiniViewCaptionLabel.Size = new System.Drawing.Size(87, 17);
            this.uiViewersMiniViewCaptionLabel.TabIndex = 4;
            this.uiViewersMiniViewCaptionLabel.Text = "Viewers:";
            this.uiViewersMiniViewCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiSubscribersMiniViewCaptionLabel
            // 
            this.uiSubscribersMiniViewCaptionLabel.AutoSize = true;
            this.uiSubscribersMiniViewCaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSubscribersMiniViewCaptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSubscribersMiniViewCaptionLabel.Location = new System.Drawing.Point(3, 0);
            this.uiSubscribersMiniViewCaptionLabel.Name = "uiSubscribersMiniViewCaptionLabel";
            this.uiSubscribersMiniViewCaptionLabel.Size = new System.Drawing.Size(87, 17);
            this.uiSubscribersMiniViewCaptionLabel.TabIndex = 7;
            this.uiSubscribersMiniViewCaptionLabel.Text = "Subscribers:";
            this.uiSubscribersMiniViewCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // QuickViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QuickViewControl";
            this.Size = new System.Drawing.Size(353, 83);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MiniViewTextLabel uiSubscriberCountMiniViewTextLabel;
        private MiniViewCaptionLabel uiFollowersMiniViewCaptionLabel;
        private MiniViewTextLabel uiFollowersCountMiniViewTextLabel;
        private MiniViewTextLabel uiViewerCountMiniViewTextLabel;
        private System.Windows.Forms.ListBox uiRecentActivityListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MiniViewCaptionLabel uiViewersMiniViewCaptionLabel;
        private MiniViewCaptionLabel uiSubscribersMiniViewCaptionLabel;
    }
}

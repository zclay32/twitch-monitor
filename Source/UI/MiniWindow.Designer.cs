namespace TwitchMonitor
{
    partial class MiniWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.uiRecentActivityListBox = new System.Windows.Forms.ListBox();
            this.uiStartButton = new System.Windows.Forms.Button();
            this.uiStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.uiAdTimeProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiRunAdButton = new System.Windows.Forms.Button();
            this.uiAdTimeLabel = new TwitchMonitor.Controls.MiniViewCaptionLabel();
            this.uiSubscriberCountMiniViewTextLabel = new TwitchMonitor.Controls.MiniViewTextLabel();
            this.uiFollowersMiniViewCaptionLabel = new TwitchMonitor.Controls.MiniViewCaptionLabel();
            this.uiFollowersCountMiniViewTextLabel = new TwitchMonitor.Controls.MiniViewTextLabel();
            this.uiViewersMiniViewCaptionLabel = new TwitchMonitor.Controls.MiniViewCaptionLabel();
            this.uiViewerCountMiniViewTextLabel = new TwitchMonitor.Controls.MiniViewTextLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiStatusPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.uiAdTimeLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiSubscriberCountMiniViewTextLabel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiFollowersMiniViewCaptionLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiFollowersCountMiniViewTextLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiViewersMiniViewCaptionLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiViewerCountMiniViewTextLabel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiRecentActivityListBox, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiStartButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiStatusPictureBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiAdTimeProgressBar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiRunAdButton, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(413, 96);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subscribers:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiRecentActivityListBox
            // 
            this.uiRecentActivityListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiRecentActivityListBox.FormattingEnabled = true;
            this.uiRecentActivityListBox.Location = new System.Drawing.Point(207, 3);
            this.uiRecentActivityListBox.Name = "uiRecentActivityListBox";
            this.tableLayoutPanel1.SetRowSpan(this.uiRecentActivityListBox, 5);
            this.uiRecentActivityListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.uiRecentActivityListBox.Size = new System.Drawing.Size(203, 90);
            this.uiRecentActivityListBox.TabIndex = 6;
            // 
            // uiStartButton
            // 
            this.uiStartButton.BackgroundImage = global::TwitchMonitor.Properties.Resources.play;
            this.uiStartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiStartButton.Location = new System.Drawing.Point(0, 0);
            this.uiStartButton.Margin = new System.Windows.Forms.Padding(0);
            this.uiStartButton.Name = "uiStartButton";
            this.uiStartButton.Size = new System.Drawing.Size(20, 20);
            this.uiStartButton.TabIndex = 7;
            this.uiStartButton.UseVisualStyleBackColor = true;
            this.uiStartButton.Click += new System.EventHandler(this.uiStartButton_Click);
            // 
            // uiStatusPictureBox
            // 
            this.uiStatusPictureBox.BackgroundImage = global::TwitchMonitor.Properties.Resources.off;
            this.uiStatusPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiStatusPictureBox.Location = new System.Drawing.Point(0, 20);
            this.uiStatusPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.uiStatusPictureBox.Name = "uiStatusPictureBox";
            this.uiStatusPictureBox.Size = new System.Drawing.Size(20, 20);
            this.uiStatusPictureBox.TabIndex = 9;
            this.uiStatusPictureBox.TabStop = false;
            // 
            // uiAdTimeProgressBar
            // 
            this.uiAdTimeProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAdTimeProgressBar.Location = new System.Drawing.Point(116, 60);
            this.uiAdTimeProgressBar.Name = "uiAdTimeProgressBar";
            this.uiAdTimeProgressBar.Size = new System.Drawing.Size(65, 20);
            this.uiAdTimeProgressBar.TabIndex = 11;
            // 
            // uiRunAdButton
            // 
            this.uiRunAdButton.ForeColor = System.Drawing.Color.Green;
            this.uiRunAdButton.Location = new System.Drawing.Point(187, 60);
            this.uiRunAdButton.Name = "uiRunAdButton";
            this.uiRunAdButton.Size = new System.Drawing.Size(20, 20);
            this.uiRunAdButton.TabIndex = 12;
            this.uiRunAdButton.Text = "$";
            this.uiRunAdButton.UseVisualStyleBackColor = true;
            this.uiRunAdButton.Click += new System.EventHandler(this.uiRunAdButton_Click);
            // 
            // uiAdTimeLabel
            // 
            this.uiAdTimeLabel.AutoSize = true;
            this.uiAdTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAdTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiAdTimeLabel.Location = new System.Drawing.Point(23, 57);
            this.uiAdTimeLabel.Name = "uiAdTimeLabel";
            this.uiAdTimeLabel.Size = new System.Drawing.Size(87, 20);
            this.uiAdTimeLabel.TabIndex = 10;
            this.uiAdTimeLabel.Text = "[AD_TIME]";
            this.uiAdTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiSubscriberCountMiniViewTextLabel
            // 
            this.uiSubscriberCountMiniViewTextLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiSubscriberCountMiniViewTextLabel, 2);
            this.uiSubscriberCountMiniViewTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSubscriberCountMiniViewTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSubscriberCountMiniViewTextLabel.Location = new System.Drawing.Point(116, 0);
            this.uiSubscriberCountMiniViewTextLabel.Name = "uiSubscriberCountMiniViewTextLabel";
            this.uiSubscriberCountMiniViewTextLabel.Size = new System.Drawing.Size(85, 20);
            this.uiSubscriberCountMiniViewTextLabel.TabIndex = 1;
            this.uiSubscriberCountMiniViewTextLabel.Text = "[COUNT]";
            this.uiSubscriberCountMiniViewTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiFollowersMiniViewCaptionLabel
            // 
            this.uiFollowersMiniViewCaptionLabel.AutoSize = true;
            this.uiFollowersMiniViewCaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiFollowersMiniViewCaptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFollowersMiniViewCaptionLabel.Location = new System.Drawing.Point(23, 20);
            this.uiFollowersMiniViewCaptionLabel.Name = "uiFollowersMiniViewCaptionLabel";
            this.uiFollowersMiniViewCaptionLabel.Size = new System.Drawing.Size(87, 20);
            this.uiFollowersMiniViewCaptionLabel.TabIndex = 2;
            this.uiFollowersMiniViewCaptionLabel.Text = "Followers:";
            this.uiFollowersMiniViewCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiFollowersCountMiniViewTextLabel
            // 
            this.uiFollowersCountMiniViewTextLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiFollowersCountMiniViewTextLabel, 2);
            this.uiFollowersCountMiniViewTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiFollowersCountMiniViewTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFollowersCountMiniViewTextLabel.Location = new System.Drawing.Point(116, 20);
            this.uiFollowersCountMiniViewTextLabel.Name = "uiFollowersCountMiniViewTextLabel";
            this.uiFollowersCountMiniViewTextLabel.Size = new System.Drawing.Size(85, 20);
            this.uiFollowersCountMiniViewTextLabel.TabIndex = 3;
            this.uiFollowersCountMiniViewTextLabel.Text = "[COUNT]";
            this.uiFollowersCountMiniViewTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiViewersMiniViewCaptionLabel
            // 
            this.uiViewersMiniViewCaptionLabel.AutoSize = true;
            this.uiViewersMiniViewCaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiViewersMiniViewCaptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiViewersMiniViewCaptionLabel.Location = new System.Drawing.Point(23, 40);
            this.uiViewersMiniViewCaptionLabel.Name = "uiViewersMiniViewCaptionLabel";
            this.uiViewersMiniViewCaptionLabel.Size = new System.Drawing.Size(87, 17);
            this.uiViewersMiniViewCaptionLabel.TabIndex = 4;
            this.uiViewersMiniViewCaptionLabel.Text = "Viewers:";
            this.uiViewersMiniViewCaptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiViewerCountMiniViewTextLabel
            // 
            this.uiViewerCountMiniViewTextLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiViewerCountMiniViewTextLabel, 2);
            this.uiViewerCountMiniViewTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiViewerCountMiniViewTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiViewerCountMiniViewTextLabel.Location = new System.Drawing.Point(116, 40);
            this.uiViewerCountMiniViewTextLabel.Name = "uiViewerCountMiniViewTextLabel";
            this.uiViewerCountMiniViewTextLabel.Size = new System.Drawing.Size(85, 17);
            this.uiViewerCountMiniViewTextLabel.TabIndex = 5;
            this.uiViewerCountMiniViewTextLabel.Text = "[COUNT]";
            this.uiViewerCountMiniViewTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MiniWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(413, 96);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 130);
            this.Name = "MiniWindow";
            this.Text = "Minicast Monitor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiStatusPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private Controls.MiniViewTextLabel uiSubscriberCountMiniViewTextLabel;
        private Controls.MiniViewCaptionLabel uiFollowersMiniViewCaptionLabel;
        private Controls.MiniViewTextLabel uiFollowersCountMiniViewTextLabel;
        private Controls.MiniViewCaptionLabel uiViewersMiniViewCaptionLabel;
        private Controls.MiniViewTextLabel uiViewerCountMiniViewTextLabel;
        private System.Windows.Forms.ListBox uiRecentActivityListBox;
        private System.Windows.Forms.Button uiStartButton;
        private System.Windows.Forms.PictureBox uiStatusPictureBox;
        private Controls.MiniViewCaptionLabel uiAdTimeLabel;
        private System.Windows.Forms.ProgressBar uiAdTimeProgressBar;
        private System.Windows.Forms.Button uiRunAdButton;
    }
}
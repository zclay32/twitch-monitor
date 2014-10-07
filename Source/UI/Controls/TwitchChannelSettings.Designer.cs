namespace TwitchMonitor.Controls
{
    partial class TwitchChannelSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.uiAuthenticationStatusLabel = new System.Windows.Forms.Label();
            this.uiChannelsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiPollWaitTimeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.uiChannelNameLabel = new System.Windows.Forms.Label();
            this.uiAuthenticationKeyTextBox = new System.Windows.Forms.TextBox();
            this.uiAuthenticationKeyLabel = new System.Windows.Forms.Label();
            this.uiChannelNameTextBox = new System.Windows.Forms.TextBox();
            this.uiAddProfileButton = new System.Windows.Forms.Button();
            this.uiRemoveProfileButton = new System.Windows.Forms.Button();
            this.uiDefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.uiAuthenticateButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPollWaitTimeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(495, 359);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Twitch.tv Channel Settings";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.uiAuthenticationStatusLabel, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.uiChannelsListView, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.label3, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.uiPollWaitTimeNumericUpDown, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.uiChannelNameLabel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.uiAuthenticationKeyTextBox, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.uiAuthenticationKeyLabel, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.uiChannelNameTextBox, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.uiAddProfileButton, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.uiRemoveProfileButton, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.uiDefaultCheckBox, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.uiAuthenticateButton, 5, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(485, 336);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // uiAuthenticationStatusLabel
            // 
            this.uiAuthenticationStatusLabel.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.uiAuthenticationStatusLabel, 3);
            this.uiAuthenticationStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAuthenticationStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiAuthenticationStatusLabel.Location = new System.Drawing.Point(251, 55);
            this.uiAuthenticationStatusLabel.Name = "uiAuthenticationStatusLabel";
            this.uiAuthenticationStatusLabel.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.uiAuthenticationStatusLabel.Size = new System.Drawing.Size(231, 25);
            this.uiAuthenticationStatusLabel.TabIndex = 24;
            this.uiAuthenticationStatusLabel.Text = "[Authentication Status]";
            // 
            // uiChannelsListView
            // 
            this.uiChannelsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiChannelsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.tableLayoutPanel2.SetColumnSpan(this.uiChannelsListView, 2);
            this.uiChannelsListView.FullRowSelect = true;
            this.uiChannelsListView.HideSelection = false;
            this.uiChannelsListView.Location = new System.Drawing.Point(3, 3);
            this.uiChannelsListView.MultiSelect = false;
            this.uiChannelsListView.Name = "uiChannelsListView";
            this.tableLayoutPanel2.SetRowSpan(this.uiChannelsListView, 5);
            this.uiChannelsListView.Size = new System.Drawing.Size(156, 301);
            this.uiChannelsListView.TabIndex = 31;
            this.uiChannelsListView.UseCompatibleStateImageBehavior = false;
            this.uiChannelsListView.View = System.Windows.Forms.View.Details;
            this.uiChannelsListView.SelectedIndexChanged += new System.EventHandler(this.uiChannelsListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Profile Name";
            this.columnHeader1.Width = 152;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(165, 80);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label2.Size = new System.Drawing.Size(80, 227);
            this.label2.TabIndex = 22;
            this.label2.Text = "Poll Rate:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(322, 80);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label3.Size = new System.Drawing.Size(160, 227);
            this.label3.TabIndex = 23;
            this.label3.Text = "milliseconds.";
            // 
            // uiPollWaitTimeNumericUpDown
            // 
            this.uiPollWaitTimeNumericUpDown.Location = new System.Drawing.Point(251, 83);
            this.uiPollWaitTimeNumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.uiPollWaitTimeNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.uiPollWaitTimeNumericUpDown.Name = "uiPollWaitTimeNumericUpDown";
            this.uiPollWaitTimeNumericUpDown.Size = new System.Drawing.Size(65, 20);
            this.uiPollWaitTimeNumericUpDown.TabIndex = 18;
            this.uiPollWaitTimeNumericUpDown.Value = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.uiPollWaitTimeNumericUpDown.ValueChanged += new System.EventHandler(this.uiPollWaitTimeNumericUpDown_ValueChanged);
            // 
            // uiChannelNameLabel
            // 
            this.uiChannelNameLabel.AutoSize = true;
            this.uiChannelNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiChannelNameLabel.Location = new System.Drawing.Point(165, 0);
            this.uiChannelNameLabel.Name = "uiChannelNameLabel";
            this.uiChannelNameLabel.Size = new System.Drawing.Size(80, 26);
            this.uiChannelNameLabel.TabIndex = 21;
            this.uiChannelNameLabel.Text = "Channel Name:";
            this.uiChannelNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiAuthenticationKeyTextBox
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.uiAuthenticationKeyTextBox, 2);
            this.uiAuthenticationKeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAuthenticationKeyTextBox.Location = new System.Drawing.Point(251, 29);
            this.uiAuthenticationKeyTextBox.Name = "uiAuthenticationKeyTextBox";
            this.uiAuthenticationKeyTextBox.Size = new System.Drawing.Size(150, 20);
            this.uiAuthenticationKeyTextBox.TabIndex = 26;
            this.uiAuthenticationKeyTextBox.TextChanged += new System.EventHandler(this.uiAuthenticationKeyTextBox_TextChanged);
            // 
            // uiAuthenticationKeyLabel
            // 
            this.uiAuthenticationKeyLabel.AutoSize = true;
            this.uiAuthenticationKeyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAuthenticationKeyLabel.Location = new System.Drawing.Point(165, 26);
            this.uiAuthenticationKeyLabel.Name = "uiAuthenticationKeyLabel";
            this.uiAuthenticationKeyLabel.Size = new System.Drawing.Size(80, 29);
            this.uiAuthenticationKeyLabel.TabIndex = 25;
            this.uiAuthenticationKeyLabel.Text = "Access Token:";
            this.uiAuthenticationKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiChannelNameTextBox
            // 
            this.uiChannelNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.uiChannelNameTextBox, 2);
            this.uiChannelNameTextBox.Enabled = false;
            this.uiChannelNameTextBox.Location = new System.Drawing.Point(251, 3);
            this.uiChannelNameTextBox.Name = "uiChannelNameTextBox";
            this.uiChannelNameTextBox.Size = new System.Drawing.Size(150, 20);
            this.uiChannelNameTextBox.TabIndex = 12;
            // 
            // uiAddProfileButton
            // 
            this.uiAddProfileButton.Location = new System.Drawing.Point(84, 310);
            this.uiAddProfileButton.Name = "uiAddProfileButton";
            this.uiAddProfileButton.Size = new System.Drawing.Size(75, 23);
            this.uiAddProfileButton.TabIndex = 29;
            this.uiAddProfileButton.Text = "Add";
            this.uiAddProfileButton.UseVisualStyleBackColor = true;
            this.uiAddProfileButton.Click += new System.EventHandler(this.uiAddProfileButton_Click);
            // 
            // uiRemoveProfileButton
            // 
            this.uiRemoveProfileButton.Location = new System.Drawing.Point(3, 310);
            this.uiRemoveProfileButton.Name = "uiRemoveProfileButton";
            this.uiRemoveProfileButton.Size = new System.Drawing.Size(75, 23);
            this.uiRemoveProfileButton.TabIndex = 30;
            this.uiRemoveProfileButton.Text = "Remove";
            this.uiRemoveProfileButton.UseVisualStyleBackColor = true;
            this.uiRemoveProfileButton.Click += new System.EventHandler(this.uiRemoveProfileButton_Click);
            // 
            // uiDefaultCheckBox
            // 
            this.uiDefaultCheckBox.AutoSize = true;
            this.uiDefaultCheckBox.Location = new System.Drawing.Point(407, 3);
            this.uiDefaultCheckBox.Name = "uiDefaultCheckBox";
            this.uiDefaultCheckBox.Size = new System.Drawing.Size(60, 17);
            this.uiDefaultCheckBox.TabIndex = 32;
            this.uiDefaultCheckBox.Text = "Default";
            this.uiDefaultCheckBox.UseVisualStyleBackColor = true;
            this.uiDefaultCheckBox.CheckedChanged += new System.EventHandler(this.uiDefaultCheckBox_CheckedChanged);
            // 
            // uiAuthenticateButton
            // 
            this.uiAuthenticateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAuthenticateButton.Enabled = false;
            this.uiAuthenticateButton.Location = new System.Drawing.Point(407, 29);
            this.uiAuthenticateButton.MaximumSize = new System.Drawing.Size(75, 23);
            this.uiAuthenticateButton.MinimumSize = new System.Drawing.Size(75, 23);
            this.uiAuthenticateButton.Name = "uiAuthenticateButton";
            this.uiAuthenticateButton.Size = new System.Drawing.Size(75, 23);
            this.uiAuthenticateButton.TabIndex = 23;
            this.uiAuthenticateButton.Text = "Authorize";
            this.uiAuthenticateButton.UseVisualStyleBackColor = true;
            this.uiAuthenticateButton.Click += new System.EventHandler(this.uiAuthorizeButton_Click);
            // 
            // TwitchChannelSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "TwitchChannelSettings";
            this.Size = new System.Drawing.Size(515, 379);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPollWaitTimeNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label uiAuthenticationStatusLabel;
        private System.Windows.Forms.Label uiChannelNameLabel;
        private System.Windows.Forms.TextBox uiChannelNameTextBox;
        private System.Windows.Forms.Button uiAuthenticateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown uiPollWaitTimeNumericUpDown;
        private System.Windows.Forms.Label uiAuthenticationKeyLabel;
        private System.Windows.Forms.TextBox uiAuthenticationKeyTextBox;
        private System.Windows.Forms.Button uiAddProfileButton;
        private System.Windows.Forms.Button uiRemoveProfileButton;
        private System.Windows.Forms.ListView uiChannelsListView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.CheckBox uiDefaultCheckBox;
    }
}

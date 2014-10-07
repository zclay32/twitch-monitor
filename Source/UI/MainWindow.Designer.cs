namespace TwitchMonitor
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.uiRunButton = new System.Windows.Forms.Button();
            this.uiStatusLabel = new System.Windows.Forms.Label();
            this.uiTotalSubscribersLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMinicastMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funStuffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diceRollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyCommanderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSubscriberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reSubscriberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsubscriberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFollowerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTwitchMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.uiUserIconPictureBox = new System.Windows.Forms.PictureBox();
            this.uiFollowersCountTitleLabel = new System.Windows.Forms.Label();
            this.uiTotalSubscriberCountLabel = new System.Windows.Forms.Label();
            this.uiTotalFollowersCountLabel = new System.Windows.Forms.Label();
            this.uiTabControl = new System.Windows.Forms.TabControl();
            this.uiSubscribersTabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.uiSubscriberDataGridView = new System.Windows.Forms.DataGridView();
            this.uiSearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiRemoveUnsubscribersButton = new System.Windows.Forms.Button();
            this.uiFollowersTabPage = new System.Windows.Forms.TabPage();
            this.uiFollowersDataGridView = new System.Windows.Forms.DataGridView();
            this.uiRecentActivityTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiActivityRichTextBox = new System.Windows.Forms.RichTextBox();
            this.uiClearNewSubcribersButton = new System.Windows.Forms.Button();
            this.uiIrcTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.uiIrcContainerPanel = new System.Windows.Forms.Panel();
            this.uiPopOutIrcButton = new System.Windows.Forms.Button();
            this.uiServersTabPage = new System.Windows.Forms.TabPage();
            this.uiTimerTabPage = new System.Windows.Forms.TabPage();
            this.uiStatusLogTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.uiStatusLogTextBox = new System.Windows.Forms.TextBox();
            this.uiViewLogButton = new System.Windows.Forms.Button();
            this.uiClearLogButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.uiViewersCountTitleLabel = new System.Windows.Forms.Label();
            this.uiViewersCountLabel = new System.Windows.Forms.Label();
            this.uiVersionLabel = new System.Windows.Forms.Label();
            this.uiUpdateAvailableLabel = new System.Windows.Forms.Label();
            this.uiStatusTitleLabel = new System.Windows.Forms.Label();
            this.uiNextAdProgressBar = new System.Windows.Forms.ProgressBar();
            this.uiNextAdLabel = new System.Windows.Forms.Label();
            this.uiRunAdButton = new System.Windows.Forms.Button();
            this.uiEditStreamTitleButton = new System.Windows.Forms.Button();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.uiIrcControl = new TwitchMonitor.Controls.IrcControl();
            this.uiServerListControl = new TwitchMonitor.UI.Controls.ServerListControl();
            this.uiTimerUserControl1 = new TwitchMonitor.UI.Controls.TimerUserControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiUserIconPictureBox)).BeginInit();
            this.uiTabControl.SuspendLayout();
            this.uiSubscribersTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSubscriberDataGridView)).BeginInit();
            this.uiFollowersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFollowersDataGridView)).BeginInit();
            this.uiRecentActivityTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiIrcTabPage.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.uiIrcContainerPanel.SuspendLayout();
            this.uiServersTabPage.SuspendLayout();
            this.uiTimerTabPage.SuspendLayout();
            this.uiStatusLogTabPage.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiRunButton
            // 
            this.uiRunButton.BackColor = System.Drawing.Color.Transparent;
            this.uiRunButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiRunButton.Location = new System.Drawing.Point(8, 8);
            this.uiRunButton.Name = "uiRunButton";
            this.tableLayoutPanel3.SetRowSpan(this.uiRunButton, 2);
            this.uiRunButton.Size = new System.Drawing.Size(130, 41);
            this.uiRunButton.TabIndex = 6;
            this.uiRunButton.Text = "Start";
            this.uiRunButton.UseVisualStyleBackColor = false;
            this.uiRunButton.Click += new System.EventHandler(this.uiRunButton_Click);
            // 
            // uiStatusLabel
            // 
            this.uiStatusLabel.AutoSize = true;
            this.uiStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiStatusLabel.Location = new System.Drawing.Point(248, 86);
            this.uiStatusLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uiStatusLabel.Name = "uiStatusLabel";
            this.uiStatusLabel.Size = new System.Drawing.Size(186, 19);
            this.uiStatusLabel.TabIndex = 7;
            this.uiStatusLabel.Text = "[STREAM_TITLE]";
            // 
            // uiTotalSubscribersLabel
            // 
            this.uiTotalSubscribersLabel.AutoSize = true;
            this.uiTotalSubscribersLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTotalSubscribersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotalSubscribersLabel.Location = new System.Drawing.Point(144, 5);
            this.uiTotalSubscribersLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 5);
            this.uiTotalSubscribersLabel.Name = "uiTotalSubscribersLabel";
            this.uiTotalSubscribersLabel.Size = new System.Drawing.Size(101, 17);
            this.uiTotalSubscribersLabel.TabIndex = 1;
            this.uiTotalSubscribersLabel.Text = "Subscribers:";
            this.uiTotalSubscribersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Browse to the folder that contains the sound files you want to play.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.profilesToolStripMenuItem,
            this.funStuffToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(513, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMinicastMonitorToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // showMinicastMonitorToolStripMenuItem
            // 
            this.showMinicastMonitorToolStripMenuItem.Name = "showMinicastMonitorToolStripMenuItem";
            this.showMinicastMonitorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.showMinicastMonitorToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.showMinicastMonitorToolStripMenuItem.Text = "Show Minicast Monitor";
            this.showMinicastMonitorToolStripMenuItem.Click += new System.EventHandler(this.showMinicastMonitorToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.CheckOnClick = true;
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.testToolStripMenuItem.Text = "test";
            // 
            // funStuffToolStripMenuItem
            // 
            this.funStuffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diceRollToolStripMenuItem,
            this.keyCommanderToolStripMenuItem});
            this.funStuffToolStripMenuItem.Name = "funStuffToolStripMenuItem";
            this.funStuffToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.funStuffToolStripMenuItem.Text = "Fun Stuff";
            // 
            // diceRollToolStripMenuItem
            // 
            this.diceRollToolStripMenuItem.Name = "diceRollToolStripMenuItem";
            this.diceRollToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.diceRollToolStripMenuItem.Text = "Dice Roll";
            this.diceRollToolStripMenuItem.Click += new System.EventHandler(this.diceRollToolStripMenuItem_Click);
            // 
            // keyCommanderToolStripMenuItem
            // 
            this.keyCommanderToolStripMenuItem.Name = "keyCommanderToolStripMenuItem";
            this.keyCommanderToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.keyCommanderToolStripMenuItem.Text = "Key Commander";
            this.keyCommanderToolStripMenuItem.Click += new System.EventHandler(this.keyCommanderToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulateToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // simulateToolStripMenuItem
            // 
            this.simulateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSubscriberToolStripMenuItem,
            this.reSubscriberToolStripMenuItem,
            this.unsubscriberToolStripMenuItem,
            this.newFollowerToolStripMenuItem});
            this.simulateToolStripMenuItem.Name = "simulateToolStripMenuItem";
            this.simulateToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.simulateToolStripMenuItem.Text = "Simulate";
            // 
            // newSubscriberToolStripMenuItem
            // 
            this.newSubscriberToolStripMenuItem.Name = "newSubscriberToolStripMenuItem";
            this.newSubscriberToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.newSubscriberToolStripMenuItem.Text = "New Subscriber";
            this.newSubscriberToolStripMenuItem.Click += new System.EventHandler(this.newSubscriberToolStripMenuItem_Click);
            // 
            // reSubscriberToolStripMenuItem
            // 
            this.reSubscriberToolStripMenuItem.Name = "reSubscriberToolStripMenuItem";
            this.reSubscriberToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.reSubscriberToolStripMenuItem.Text = "Resubscriber";
            this.reSubscriberToolStripMenuItem.Click += new System.EventHandler(this.reSubscriberToolStripMenuItem_Click);
            // 
            // unsubscriberToolStripMenuItem
            // 
            this.unsubscriberToolStripMenuItem.Name = "unsubscriberToolStripMenuItem";
            this.unsubscriberToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.unsubscriberToolStripMenuItem.Text = "Unsubscriber";
            this.unsubscriberToolStripMenuItem.Click += new System.EventHandler(this.unsubscriberToolStripMenuItem_Click);
            // 
            // newFollowerToolStripMenuItem
            // 
            this.newFollowerToolStripMenuItem.Name = "newFollowerToolStripMenuItem";
            this.newFollowerToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.newFollowerToolStripMenuItem.Text = "New Follower";
            this.newFollowerToolStripMenuItem.Click += new System.EventHandler(this.newFollowerToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutTwitchMonitorToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutTwitchMonitorToolStripMenuItem
            // 
            this.aboutTwitchMonitorToolStripMenuItem.Name = "aboutTwitchMonitorToolStripMenuItem";
            this.aboutTwitchMonitorToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.aboutTwitchMonitorToolStripMenuItem.Text = "About Twitch Monitor";
            this.aboutTwitchMonitorToolStripMenuItem.Click += new System.EventHandler(this.aboutTwitchMonitorToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates...";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
            // 
            // uiUserIconPictureBox
            // 
            this.uiUserIconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiUserIconPictureBox.Location = new System.Drawing.Point(440, 8);
            this.uiUserIconPictureBox.Name = "uiUserIconPictureBox";
            this.tableLayoutPanel3.SetRowSpan(this.uiUserIconPictureBox, 3);
            this.uiUserIconPictureBox.Size = new System.Drawing.Size(65, 65);
            this.uiUserIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiUserIconPictureBox.TabIndex = 10;
            this.uiUserIconPictureBox.TabStop = false;
            // 
            // uiFollowersCountTitleLabel
            // 
            this.uiFollowersCountTitleLabel.AutoSize = true;
            this.uiFollowersCountTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiFollowersCountTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFollowersCountTitleLabel.Location = new System.Drawing.Point(144, 32);
            this.uiFollowersCountTitleLabel.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.uiFollowersCountTitleLabel.Name = "uiFollowersCountTitleLabel";
            this.uiFollowersCountTitleLabel.Size = new System.Drawing.Size(101, 17);
            this.uiFollowersCountTitleLabel.TabIndex = 11;
            this.uiFollowersCountTitleLabel.Text = "Followers:";
            this.uiFollowersCountTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiTotalSubscriberCountLabel
            // 
            this.uiTotalSubscriberCountLabel.AutoSize = true;
            this.uiTotalSubscriberCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTotalSubscriberCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotalSubscriberCountLabel.Location = new System.Drawing.Point(248, 5);
            this.uiTotalSubscriberCountLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.uiTotalSubscriberCountLabel.Name = "uiTotalSubscriberCountLabel";
            this.uiTotalSubscriberCountLabel.Size = new System.Drawing.Size(186, 17);
            this.uiTotalSubscriberCountLabel.TabIndex = 12;
            this.uiTotalSubscriberCountLabel.Text = "[SUB_COUNT]";
            this.uiTotalSubscriberCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTotalFollowersCountLabel
            // 
            this.uiTotalFollowersCountLabel.AutoSize = true;
            this.uiTotalFollowersCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTotalFollowersCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTotalFollowersCountLabel.Location = new System.Drawing.Point(248, 32);
            this.uiTotalFollowersCountLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uiTotalFollowersCountLabel.Name = "uiTotalFollowersCountLabel";
            this.uiTotalFollowersCountLabel.Size = new System.Drawing.Size(186, 17);
            this.uiTotalFollowersCountLabel.TabIndex = 13;
            this.uiTotalFollowersCountLabel.Text = "[FOLLOWERS_COUNT]";
            this.uiTotalFollowersCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTabControl
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.uiTabControl, 4);
            this.uiTabControl.Controls.Add(this.uiSubscribersTabPage);
            this.uiTabControl.Controls.Add(this.uiFollowersTabPage);
            this.uiTabControl.Controls.Add(this.uiRecentActivityTabPage);
            this.uiTabControl.Controls.Add(this.uiIrcTabPage);
            this.uiTabControl.Controls.Add(this.uiServersTabPage);
            this.uiTabControl.Controls.Add(this.uiTimerTabPage);
            this.uiTabControl.Controls.Add(this.uiStatusLogTabPage);
            this.uiTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl.Location = new System.Drawing.Point(8, 149);
            this.uiTabControl.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.uiTabControl.Name = "uiTabControl";
            this.uiTabControl.SelectedIndex = 0;
            this.uiTabControl.Size = new System.Drawing.Size(497, 259);
            this.uiTabControl.TabIndex = 8;
            // 
            // uiSubscribersTabPage
            // 
            this.uiSubscribersTabPage.Controls.Add(this.panel1);
            this.uiSubscribersTabPage.Location = new System.Drawing.Point(4, 22);
            this.uiSubscribersTabPage.Name = "uiSubscribersTabPage";
            this.uiSubscribersTabPage.Padding = new System.Windows.Forms.Padding(5);
            this.uiSubscribersTabPage.Size = new System.Drawing.Size(489, 233);
            this.uiSubscribersTabPage.TabIndex = 0;
            this.uiSubscribersTabPage.Text = "Subscribers";
            this.uiSubscribersTabPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 223);
            this.panel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.uiSubscriberDataGridView, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.uiSearchTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uiRemoveUnsubscribersButton, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(479, 223);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // uiSubscriberDataGridView
            // 
            this.uiSubscriberDataGridView.AllowUserToAddRows = false;
            this.uiSubscriberDataGridView.AllowUserToDeleteRows = false;
            this.uiSubscriberDataGridView.AllowUserToResizeRows = false;
            this.uiSubscriberDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSubscriberDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiSubscriberDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel2.SetColumnSpan(this.uiSubscriberDataGridView, 3);
            this.uiSubscriberDataGridView.Location = new System.Drawing.Point(3, 3);
            this.uiSubscriberDataGridView.Name = "uiSubscriberDataGridView";
            this.uiSubscriberDataGridView.RowHeadersVisible = false;
            this.uiSubscriberDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiSubscriberDataGridView.Size = new System.Drawing.Size(473, 188);
            this.uiSubscriberDataGridView.TabIndex = 4;
            this.uiSubscriberDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.uiSubscriberDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.uiSubscriberDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // uiSearchTextBox
            // 
            this.uiSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSearchTextBox.Location = new System.Drawing.Point(42, 200);
            this.uiSearchTextBox.Name = "uiSearchTextBox";
            this.uiSearchTextBox.Size = new System.Drawing.Size(278, 20);
            this.uiSearchTextBox.TabIndex = 5;
            this.uiSearchTextBox.TextChanged += new System.EventHandler(this.uiSearchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Find:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiRemoveUnsubscribersButton
            // 
            this.uiRemoveUnsubscribersButton.Location = new System.Drawing.Point(326, 197);
            this.uiRemoveUnsubscribersButton.Name = "uiRemoveUnsubscribersButton";
            this.uiRemoveUnsubscribersButton.Size = new System.Drawing.Size(150, 23);
            this.uiRemoveUnsubscribersButton.TabIndex = 7;
            this.uiRemoveUnsubscribersButton.Text = "Remove Unsubscribers";
            this.uiRemoveUnsubscribersButton.UseVisualStyleBackColor = true;
            this.uiRemoveUnsubscribersButton.Click += new System.EventHandler(this.uiRemoveUnsubscribersButton_Click);
            // 
            // uiFollowersTabPage
            // 
            this.uiFollowersTabPage.Controls.Add(this.uiFollowersDataGridView);
            this.uiFollowersTabPage.Location = new System.Drawing.Point(4, 22);
            this.uiFollowersTabPage.Name = "uiFollowersTabPage";
            this.uiFollowersTabPage.Padding = new System.Windows.Forms.Padding(5);
            this.uiFollowersTabPage.Size = new System.Drawing.Size(489, 233);
            this.uiFollowersTabPage.TabIndex = 3;
            this.uiFollowersTabPage.Text = "Followers";
            this.uiFollowersTabPage.UseVisualStyleBackColor = true;
            // 
            // uiFollowersDataGridView
            // 
            this.uiFollowersDataGridView.AllowUserToAddRows = false;
            this.uiFollowersDataGridView.AllowUserToDeleteRows = false;
            this.uiFollowersDataGridView.AllowUserToResizeRows = false;
            this.uiFollowersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiFollowersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.uiFollowersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiFollowersDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.uiFollowersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiFollowersDataGridView.Location = new System.Drawing.Point(5, 5);
            this.uiFollowersDataGridView.Name = "uiFollowersDataGridView";
            this.uiFollowersDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiFollowersDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.uiFollowersDataGridView.RowHeadersVisible = false;
            this.uiFollowersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiFollowersDataGridView.Size = new System.Drawing.Size(479, 223);
            this.uiFollowersDataGridView.TabIndex = 5;
            this.uiFollowersDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.uiFollowersDataGridView_RowsAdded);
            // 
            // uiRecentActivityTabPage
            // 
            this.uiRecentActivityTabPage.Controls.Add(this.tableLayoutPanel1);
            this.uiRecentActivityTabPage.Location = new System.Drawing.Point(4, 22);
            this.uiRecentActivityTabPage.Name = "uiRecentActivityTabPage";
            this.uiRecentActivityTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.uiRecentActivityTabPage.Size = new System.Drawing.Size(489, 233);
            this.uiRecentActivityTabPage.TabIndex = 7;
            this.uiRecentActivityTabPage.Text = "Recent Activity";
            this.uiRecentActivityTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.uiActivityRichTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiClearNewSubcribersButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(483, 227);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // uiActivityRichTextBox
            // 
            this.uiActivityRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiActivityRichTextBox, 2);
            this.uiActivityRichTextBox.Location = new System.Drawing.Point(8, 8);
            this.uiActivityRichTextBox.Name = "uiActivityRichTextBox";
            this.uiActivityRichTextBox.ReadOnly = true;
            this.uiActivityRichTextBox.Size = new System.Drawing.Size(467, 175);
            this.uiActivityRichTextBox.TabIndex = 5;
            this.uiActivityRichTextBox.Text = "";
            // 
            // uiClearNewSubcribersButton
            // 
            this.uiClearNewSubcribersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiClearNewSubcribersButton.Location = new System.Drawing.Point(390, 189);
            this.uiClearNewSubcribersButton.Name = "uiClearNewSubcribersButton";
            this.uiClearNewSubcribersButton.Size = new System.Drawing.Size(85, 30);
            this.uiClearNewSubcribersButton.TabIndex = 4;
            this.uiClearNewSubcribersButton.Text = "Clear";
            this.uiClearNewSubcribersButton.UseVisualStyleBackColor = true;
            this.uiClearNewSubcribersButton.Click += new System.EventHandler(this.uiClearNewSubcribersButton_Click);
            // 
            // uiIrcTabPage
            // 
            this.uiIrcTabPage.Controls.Add(this.tableLayoutPanel5);
            this.uiIrcTabPage.Location = new System.Drawing.Point(4, 22);
            this.uiIrcTabPage.Name = "uiIrcTabPage";
            this.uiIrcTabPage.Padding = new System.Windows.Forms.Padding(5);
            this.uiIrcTabPage.Size = new System.Drawing.Size(489, 233);
            this.uiIrcTabPage.TabIndex = 4;
            this.uiIrcTabPage.Text = "IRC";
            this.uiIrcTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.uiIrcContainerPanel, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.uiPopOutIrcButton, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(479, 223);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // uiIrcContainerPanel
            // 
            this.uiIrcContainerPanel.Controls.Add(this.uiIrcControl);
            this.uiIrcContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiIrcContainerPanel.Location = new System.Drawing.Point(3, 32);
            this.uiIrcContainerPanel.Name = "uiIrcContainerPanel";
            this.uiIrcContainerPanel.Size = new System.Drawing.Size(473, 188);
            this.uiIrcContainerPanel.TabIndex = 3;
            // 
            // uiPopOutIrcButton
            // 
            this.uiPopOutIrcButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPopOutIrcButton.Location = new System.Drawing.Point(401, 3);
            this.uiPopOutIrcButton.Name = "uiPopOutIrcButton";
            this.uiPopOutIrcButton.Size = new System.Drawing.Size(75, 23);
            this.uiPopOutIrcButton.TabIndex = 1;
            this.uiPopOutIrcButton.Text = "Pop Out >>";
            this.uiPopOutIrcButton.UseVisualStyleBackColor = true;
            this.uiPopOutIrcButton.Click += new System.EventHandler(this.uiPopOutIrcButton_Click);
            // 
            // uiServersTabPage
            // 
            this.uiServersTabPage.Controls.Add(this.uiServerListControl);
            this.uiServersTabPage.Location = new System.Drawing.Point(4, 22);
            this.uiServersTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.uiServersTabPage.Name = "uiServersTabPage";
            this.uiServersTabPage.Padding = new System.Windows.Forms.Padding(5);
            this.uiServersTabPage.Size = new System.Drawing.Size(489, 233);
            this.uiServersTabPage.TabIndex = 5;
            this.uiServersTabPage.Text = "Servers";
            this.uiServersTabPage.UseVisualStyleBackColor = true;
            // 
            // uiTimerTabPage
            // 
            this.uiTimerTabPage.Controls.Add(this.uiTimerUserControl1);
            this.uiTimerTabPage.Location = new System.Drawing.Point(4, 22);
            this.uiTimerTabPage.Name = "uiTimerTabPage";
            this.uiTimerTabPage.Padding = new System.Windows.Forms.Padding(5);
            this.uiTimerTabPage.Size = new System.Drawing.Size(489, 233);
            this.uiTimerTabPage.TabIndex = 6;
            this.uiTimerTabPage.Text = "Timer";
            this.uiTimerTabPage.UseVisualStyleBackColor = true;
            // 
            // uiStatusLogTabPage
            // 
            this.uiStatusLogTabPage.Controls.Add(this.tableLayoutPanel4);
            this.uiStatusLogTabPage.Location = new System.Drawing.Point(4, 22);
            this.uiStatusLogTabPage.Name = "uiStatusLogTabPage";
            this.uiStatusLogTabPage.Padding = new System.Windows.Forms.Padding(5);
            this.uiStatusLogTabPage.Size = new System.Drawing.Size(489, 233);
            this.uiStatusLogTabPage.TabIndex = 2;
            this.uiStatusLogTabPage.Text = "Status Log";
            this.uiStatusLogTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.uiStatusLogTextBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.uiViewLogButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.uiClearLogButton, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(479, 223);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // uiStatusLogTextBox
            // 
            this.uiStatusLogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiStatusLogTextBox.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel4.SetColumnSpan(this.uiStatusLogTextBox, 2);
            this.uiStatusLogTextBox.Location = new System.Drawing.Point(3, 3);
            this.uiStatusLogTextBox.Multiline = true;
            this.uiStatusLogTextBox.Name = "uiStatusLogTextBox";
            this.uiStatusLogTextBox.ReadOnly = true;
            this.uiStatusLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uiStatusLogTextBox.Size = new System.Drawing.Size(473, 188);
            this.uiStatusLogTextBox.TabIndex = 5;
            // 
            // uiViewLogButton
            // 
            this.uiViewLogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiViewLogButton.Location = new System.Drawing.Point(320, 197);
            this.uiViewLogButton.Name = "uiViewLogButton";
            this.uiViewLogButton.Size = new System.Drawing.Size(75, 23);
            this.uiViewLogButton.TabIndex = 6;
            this.uiViewLogButton.Text = "View Log";
            this.uiViewLogButton.UseVisualStyleBackColor = true;
            this.uiViewLogButton.Click += new System.EventHandler(this.uiViewLogButton_Click);
            // 
            // uiClearLogButton
            // 
            this.uiClearLogButton.Location = new System.Drawing.Point(401, 197);
            this.uiClearLogButton.Name = "uiClearLogButton";
            this.uiClearLogButton.Size = new System.Drawing.Size(75, 23);
            this.uiClearLogButton.TabIndex = 7;
            this.uiClearLogButton.Text = "Clear";
            this.uiClearLogButton.UseVisualStyleBackColor = true;
            this.uiClearLogButton.Click += new System.EventHandler(this.uiClearLogButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.uiRunButton, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.uiTabControl, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.uiStatusLabel, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.uiTotalFollowersCountLabel, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.uiUserIconPictureBox, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.uiTotalSubscriberCountLabel, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.uiTotalSubscribersLabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.uiFollowersCountTitleLabel, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.uiViewersCountTitleLabel, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.uiViewersCountLabel, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.uiVersionLabel, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.uiUpdateAvailableLabel, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.uiStatusTitleLabel, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.uiNextAdProgressBar, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.uiNextAdLabel, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.uiRunAdButton, 3, 5);
            this.tableLayoutPanel3.Controls.Add(this.uiEditStreamTitleButton, 3, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(513, 436);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // uiViewersCountTitleLabel
            // 
            this.uiViewersCountTitleLabel.AutoSize = true;
            this.uiViewersCountTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiViewersCountTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiViewersCountTitleLabel.Location = new System.Drawing.Point(144, 59);
            this.uiViewersCountTitleLabel.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.uiViewersCountTitleLabel.Name = "uiViewersCountTitleLabel";
            this.uiViewersCountTitleLabel.Size = new System.Drawing.Size(101, 17);
            this.uiViewersCountTitleLabel.TabIndex = 14;
            this.uiViewersCountTitleLabel.Text = "Viewers:";
            this.uiViewersCountTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiViewersCountLabel
            // 
            this.uiViewersCountLabel.AutoSize = true;
            this.uiViewersCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiViewersCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiViewersCountLabel.Location = new System.Drawing.Point(248, 59);
            this.uiViewersCountLabel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.uiViewersCountLabel.Name = "uiViewersCountLabel";
            this.uiViewersCountLabel.Size = new System.Drawing.Size(186, 17);
            this.uiViewersCountLabel.TabIndex = 15;
            this.uiViewersCountLabel.Text = "[VIEWERS_COUNT]";
            this.uiViewersCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiVersionLabel
            // 
            this.uiVersionLabel.AutoSize = true;
            this.uiVersionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiVersionLabel.Location = new System.Drawing.Point(8, 411);
            this.uiVersionLabel.Name = "uiVersionLabel";
            this.uiVersionLabel.Size = new System.Drawing.Size(130, 20);
            this.uiVersionLabel.TabIndex = 16;
            this.uiVersionLabel.Text = "Version: 1.0.0";
            this.uiVersionLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // uiUpdateAvailableLabel
            // 
            this.uiUpdateAvailableLabel.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.uiUpdateAvailableLabel, 3);
            this.uiUpdateAvailableLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiUpdateAvailableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiUpdateAvailableLabel.Location = new System.Drawing.Point(144, 411);
            this.uiUpdateAvailableLabel.Name = "uiUpdateAvailableLabel";
            this.uiUpdateAvailableLabel.Size = new System.Drawing.Size(361, 20);
            this.uiUpdateAvailableLabel.TabIndex = 17;
            this.uiUpdateAvailableLabel.Text = "[UPDATE_AVAILABLE]";
            this.uiUpdateAvailableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiStatusTitleLabel
            // 
            this.uiStatusTitleLabel.AutoSize = true;
            this.uiStatusTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiStatusTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiStatusTitleLabel.Location = new System.Drawing.Point(144, 86);
            this.uiStatusTitleLabel.Margin = new System.Windows.Forms.Padding(3, 5, 0, 5);
            this.uiStatusTitleLabel.Name = "uiStatusTitleLabel";
            this.uiStatusTitleLabel.Size = new System.Drawing.Size(101, 19);
            this.uiStatusTitleLabel.TabIndex = 18;
            this.uiStatusTitleLabel.Text = "Stream Title:";
            this.uiStatusTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiNextAdProgressBar
            // 
            this.uiNextAdProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiNextAdProgressBar.Location = new System.Drawing.Point(248, 113);
            this.uiNextAdProgressBar.Name = "uiNextAdProgressBar";
            this.uiNextAdProgressBar.Size = new System.Drawing.Size(186, 23);
            this.uiNextAdProgressBar.TabIndex = 19;
            // 
            // uiNextAdLabel
            // 
            this.uiNextAdLabel.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.uiNextAdLabel, 2);
            this.uiNextAdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiNextAdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiNextAdLabel.Location = new System.Drawing.Point(8, 110);
            this.uiNextAdLabel.Name = "uiNextAdLabel";
            this.uiNextAdLabel.Size = new System.Drawing.Size(234, 29);
            this.uiNextAdLabel.TabIndex = 20;
            this.uiNextAdLabel.Text = "Time to next ad:";
            this.uiNextAdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiRunAdButton
            // 
            this.uiRunAdButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiRunAdButton.Location = new System.Drawing.Point(440, 113);
            this.uiRunAdButton.Name = "uiRunAdButton";
            this.uiRunAdButton.Size = new System.Drawing.Size(65, 23);
            this.uiRunAdButton.TabIndex = 21;
            this.uiRunAdButton.Text = "Run Ad";
            this.uiRunAdButton.UseVisualStyleBackColor = true;
            this.uiRunAdButton.Click += new System.EventHandler(this.uiRunAdButton_Click);
            // 
            // uiEditStreamTitleButton
            // 
            this.uiEditStreamTitleButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiEditStreamTitleButton.Location = new System.Drawing.Point(440, 84);
            this.uiEditStreamTitleButton.Name = "uiEditStreamTitleButton";
            this.uiEditStreamTitleButton.Size = new System.Drawing.Size(65, 23);
            this.uiEditStreamTitleButton.TabIndex = 22;
            this.uiEditStreamTitleButton.Text = "Edit";
            this.uiEditStreamTitleButton.UseVisualStyleBackColor = true;
            this.uiEditStreamTitleButton.Click += new System.EventHandler(this.uiEditStreamTitleButton_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.settingToolStripMenuItem.Text = "Setting...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(239, 6);
            // 
            // uiIrcControl
            // 
            this.uiIrcControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uiIrcControl.BotCommands = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("uiIrcControl.BotCommands")));
            this.uiIrcControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiIrcControl.IrcClient = null;
            this.uiIrcControl.Location = new System.Drawing.Point(0, 0);
            this.uiIrcControl.Margin = new System.Windows.Forms.Padding(4);
            this.uiIrcControl.MaxLineCount = 50;
            this.uiIrcControl.MessageQueue = ((System.Collections.Queue)(resources.GetObject("uiIrcControl.MessageQueue")));
            this.uiIrcControl.Name = "uiIrcControl";
            this.uiIrcControl.Size = new System.Drawing.Size(473, 188);
            this.uiIrcControl.TabIndex = 0;
            // 
            // uiServerListControl
            // 
            this.uiServerListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiServerListControl.Location = new System.Drawing.Point(5, 5);
            this.uiServerListControl.Margin = new System.Windows.Forms.Padding(4);
            this.uiServerListControl.Name = "uiServerListControl";
            this.uiServerListControl.Size = new System.Drawing.Size(479, 223);
            this.uiServerListControl.TabIndex = 0;
            // 
            // uiTimerUserControl1
            // 
            this.uiTimerUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTimerUserControl1.Location = new System.Drawing.Point(5, 5);
            this.uiTimerUserControl1.Margin = new System.Windows.Forms.Padding(4);
            this.uiTimerUserControl1.Name = "uiTimerUserControl1";
            this.uiTimerUserControl1.Padding = new System.Windows.Forms.Padding(5);
            this.uiTimerUserControl1.Size = new System.Drawing.Size(479, 223);
            this.uiTimerUserControl1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 460);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(529, 499);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Twitch Monitor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiUserIconPictureBox)).EndInit();
            this.uiTabControl.ResumeLayout(false);
            this.uiSubscribersTabPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSubscriberDataGridView)).EndInit();
            this.uiFollowersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiFollowersDataGridView)).EndInit();
            this.uiRecentActivityTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiIrcTabPage.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.uiIrcContainerPanel.ResumeLayout(false);
            this.uiServersTabPage.ResumeLayout(false);
            this.uiTimerTabPage.ResumeLayout(false);
            this.uiStatusLogTabPage.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox uiStatusLogTextBox;
        private System.Windows.Forms.Button uiRunButton;
        private System.Windows.Forms.Label uiStatusLabel;
        private System.Windows.Forms.TabControl uiTabControl;
        private System.Windows.Forms.TabPage uiSubscribersTabPage;
        private System.Windows.Forms.Label uiTotalSubscribersLabel;
        private System.Windows.Forms.TabPage uiStatusLogTabPage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button uiClearNewSubcribersButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutTwitchMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox uiUserIconPictureBox;
        private System.Windows.Forms.DataGridView uiSubscriberDataGridView;
        private System.Windows.Forms.TextBox uiSearchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox uiActivityRichTextBox;
        private System.Windows.Forms.TabPage uiFollowersTabPage;
        private System.Windows.Forms.DataGridView uiFollowersDataGridView;
        private System.Windows.Forms.Label uiFollowersCountTitleLabel;
        private System.Windows.Forms.Label uiTotalSubscriberCountLabel;
        private System.Windows.Forms.Label uiTotalFollowersCountLabel;
        private System.Windows.Forms.ToolStripMenuItem showMinicastMonitorToolStripMenuItem;
        private System.Windows.Forms.TabPage uiIrcTabPage;
        private Controls.IrcControl uiIrcControl;
        private System.Windows.Forms.TabPage uiServersTabPage;
        private UI.Controls.ServerListControl uiServerListControl;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.TabPage uiTimerTabPage;
        private UI.Controls.TimerUserControl uiTimerUserControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage uiRecentActivityTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label uiViewersCountTitleLabel;
        private System.Windows.Forms.Label uiViewersCountLabel;
        private System.Windows.Forms.Label uiVersionLabel;
        private System.Windows.Forms.Label uiUpdateAvailableLabel;
        private System.Windows.Forms.Label uiStatusTitleLabel;
        private System.Windows.Forms.ProgressBar uiNextAdProgressBar;
        private System.Windows.Forms.Label uiNextAdLabel;
        private System.Windows.Forms.Button uiRunAdButton;
        private System.Windows.Forms.Button uiViewLogButton;
        private System.Windows.Forms.ToolStripMenuItem funStuffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diceRollToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button uiEditStreamTitleButton;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSubscriberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reSubscriberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unsubscriberToolStripMenuItem;
        private System.Windows.Forms.Button uiPopOutIrcButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel uiIrcContainerPanel;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button uiClearLogButton;
        private System.Windows.Forms.Button uiRemoveUnsubscribersButton;
        private System.Windows.Forms.ToolStripMenuItem keyCommanderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFollowerToolStripMenuItem;
    }
}


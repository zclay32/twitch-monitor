namespace TwitchMonitor.Controls
{
    partial class IrcControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Ops", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Users", System.Windows.Forms.HorizontalAlignment.Left);
            this.uiConnectButton = new System.Windows.Forms.Button();
            this.uiChatTextBox = new System.Windows.Forms.TextBox();
            this.uiUsersListView = new System.Windows.Forms.ListView();
            this.uiUsersColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uiCommandMessageTextBox = new System.Windows.Forms.TextBox();
            this.uiBotCommandListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uiCommandContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiEnableBotCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.uiCommandContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiConnectButton
            // 
            this.uiConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiConnectButton.AutoSize = true;
            this.uiConnectButton.Location = new System.Drawing.Point(177, 339);
            this.uiConnectButton.Name = "uiConnectButton";
            this.uiConnectButton.Size = new System.Drawing.Size(145, 23);
            this.uiConnectButton.TabIndex = 9;
            this.uiConnectButton.Text = "Connect";
            this.uiConnectButton.UseVisualStyleBackColor = true;
            this.uiConnectButton.Click += new System.EventHandler(this.uiConnectButton_Click);
            // 
            // uiChatTextBox
            // 
            this.uiChatTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiChatTextBox, 2);
            this.uiChatTextBox.Location = new System.Drawing.Point(3, 342);
            this.uiChatTextBox.Name = "uiChatTextBox";
            this.uiChatTextBox.Size = new System.Drawing.Size(168, 20);
            this.uiChatTextBox.TabIndex = 7;
            this.uiChatTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uiChatTextBox_KeyDown);
            // 
            // uiUsersListView
            // 
            this.uiUsersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uiUsersColumnHeader});
            this.uiUsersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiUsersListView.FullRowSelect = true;
            listViewGroup1.Header = "Ops";
            listViewGroup1.Name = "Ops";
            listViewGroup2.Header = "Users";
            listViewGroup2.Name = "Users";
            this.uiUsersListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.uiUsersListView.Location = new System.Drawing.Point(177, 3);
            this.uiUsersListView.Name = "uiUsersListView";
            this.uiUsersListView.Size = new System.Drawing.Size(145, 330);
            this.uiUsersListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.uiUsersListView.TabIndex = 17;
            this.uiUsersListView.UseCompatibleStateImageBehavior = false;
            this.uiUsersListView.View = System.Windows.Forms.View.Details;
            // 
            // uiUsersColumnHeader
            // 
            this.uiUsersColumnHeader.Text = "Users";
            this.uiUsersColumnHeader.Width = 140;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel1.Controls.Add(this.uiUsersListView, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.webBrowser1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiChatTextBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiConnectButton, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(325, 365);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.tableLayoutPanel1.SetColumnSpan(this.webBrowser1, 2);
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(168, 330);
            this.webBrowser1.TabIndex = 18;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.GrayText;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.uiCommandMessageTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.uiBotCommandListView);
            this.splitContainer1.Panel2.Controls.Add(this.uiEnableBotCheckBox);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(588, 365);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.TabIndex = 19;
            // 
            // uiCommandMessageTextBox
            // 
            this.uiCommandMessageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiCommandMessageTextBox.Location = new System.Drawing.Point(96, 32);
            this.uiCommandMessageTextBox.Multiline = true;
            this.uiCommandMessageTextBox.Name = "uiCommandMessageTextBox";
            this.uiCommandMessageTextBox.ReadOnly = true;
            this.uiCommandMessageTextBox.Size = new System.Drawing.Size(153, 323);
            this.uiCommandMessageTextBox.TabIndex = 3;
            // 
            // uiBotCommandListView
            // 
            this.uiBotCommandListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.uiBotCommandListView.ContextMenuStrip = this.uiCommandContextMenuStrip;
            this.uiBotCommandListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiBotCommandListView.FullRowSelect = true;
            this.uiBotCommandListView.Location = new System.Drawing.Point(10, 32);
            this.uiBotCommandListView.Name = "uiBotCommandListView";
            this.uiBotCommandListView.Size = new System.Drawing.Size(86, 323);
            this.uiBotCommandListView.TabIndex = 2;
            this.uiBotCommandListView.UseCompatibleStateImageBehavior = false;
            this.uiBotCommandListView.View = System.Windows.Forms.View.Details;
            this.uiBotCommandListView.SelectedIndexChanged += new System.EventHandler(this.uiBotCommandListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Commands";
            this.columnHeader1.Width = 81;
            // 
            // uiCommandContextMenuStrip
            // 
            this.uiCommandContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.editToolStripMenuItem});
            this.uiCommandContextMenuStrip.Name = "uiCommandContextMenuStrip";
            this.uiCommandContextMenuStrip.Size = new System.Drawing.Size(118, 70);
            this.uiCommandContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.uiCommandContextMenuStrip_Opening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // uiEnableBotCheckBox
            // 
            this.uiEnableBotCheckBox.AutoSize = true;
            this.uiEnableBotCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiEnableBotCheckBox.Location = new System.Drawing.Point(10, 10);
            this.uiEnableBotCheckBox.Name = "uiEnableBotCheckBox";
            this.uiEnableBotCheckBox.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.uiEnableBotCheckBox.Size = new System.Drawing.Size(239, 22);
            this.uiEnableBotCheckBox.TabIndex = 0;
            this.uiEnableBotCheckBox.Text = "Enable Bot";
            this.uiEnableBotCheckBox.UseVisualStyleBackColor = true;
            this.uiEnableBotCheckBox.CheckedChanged += new System.EventHandler(this.uiEnableBotCheckBox_CheckedChanged);
            // 
            // IrcControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "IrcControl";
            this.Size = new System.Drawing.Size(588, 365);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.uiCommandContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uiConnectButton;
        private System.Windows.Forms.TextBox uiChatTextBox;
        private System.Windows.Forms.ListView uiUsersListView;
        private System.Windows.Forms.ColumnHeader uiUsersColumnHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox uiCommandMessageTextBox;
        private System.Windows.Forms.ListView uiBotCommandListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip uiCommandContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.CheckBox uiEnableBotCheckBox;
    }
}

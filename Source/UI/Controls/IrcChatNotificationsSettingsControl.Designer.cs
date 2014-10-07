namespace TwitchMonitor.UI.Controls
{
    partial class IrcChatNotificationsSettingsControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiAdBreakTextBox = new System.Windows.Forms.TextBox();
            this.uiStringTokensRichTextBox = new System.Windows.Forms.RichTextBox();
            this.uiNewSubscriberTextBox = new System.Windows.Forms.TextBox();
            this.uiShowNotificationsInChatCheckBox = new System.Windows.Forms.CheckBox();
            this.uiNewFollowerTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiShowAdBreakMessageAtWarningCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.uiReSubscriberTextBox = new System.Windows.Forms.TextBox();
            this.uiUseNewSubscriberMessageCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 400);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chat Notification Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.uiAdBreakTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.uiStringTokensRichTextBox, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.uiNewSubscriberTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiShowNotificationsInChatCheckBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiNewFollowerTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.uiShowAdBreakMessageAtWarningCheckBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiReSubscriberTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiUseNewSubscriberMessageCheckBox, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(486, 381);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // uiAdBreakTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiAdBreakTextBox, 2);
            this.uiAdBreakTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiAdBreakTextBox.Location = new System.Drawing.Point(145, 221);
            this.uiAdBreakTextBox.Multiline = true;
            this.uiAdBreakTextBox.Name = "uiAdBreakTextBox";
            this.uiAdBreakTextBox.Size = new System.Drawing.Size(333, 44);
            this.uiAdBreakTextBox.TabIndex = 25;
            // 
            // uiStringTokensRichTextBox
            // 
            this.uiStringTokensRichTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.uiStringTokensRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.uiStringTokensRichTextBox, 3);
            this.uiStringTokensRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiStringTokensRichTextBox.Location = new System.Drawing.Point(8, 311);
            this.uiStringTokensRichTextBox.Name = "uiStringTokensRichTextBox";
            this.uiStringTokensRichTextBox.Size = new System.Drawing.Size(470, 62);
            this.uiStringTokensRichTextBox.TabIndex = 26;
            this.uiStringTokensRichTextBox.Text = "String tokens:\n{{user}} - Will display the user\'s name for messages tied to a sin" +
                "gle user notification.";
            // 
            // uiNewSubscriberTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiNewSubscriberTextBox, 2);
            this.uiNewSubscriberTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiNewSubscriberTextBox.Location = new System.Drawing.Point(145, 81);
            this.uiNewSubscriberTextBox.Multiline = true;
            this.uiNewSubscriberTextBox.Name = "uiNewSubscriberTextBox";
            this.uiNewSubscriberTextBox.Size = new System.Drawing.Size(333, 44);
            this.uiNewSubscriberTextBox.TabIndex = 23;
            // 
            // uiShowNotificationsInChatCheckBox
            // 
            this.uiShowNotificationsInChatCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiShowNotificationsInChatCheckBox, 2);
            this.uiShowNotificationsInChatCheckBox.Location = new System.Drawing.Point(8, 8);
            this.uiShowNotificationsInChatCheckBox.Name = "uiShowNotificationsInChatCheckBox";
            this.uiShowNotificationsInChatCheckBox.Size = new System.Drawing.Size(151, 17);
            this.uiShowNotificationsInChatCheckBox.TabIndex = 19;
            this.uiShowNotificationsInChatCheckBox.Text = "Show Notifications In Chat";
            this.uiShowNotificationsInChatCheckBox.UseVisualStyleBackColor = true;
            this.uiShowNotificationsInChatCheckBox.CheckedChanged += new System.EventHandler(this.uiShowNotificationsInChatCheckBox_CheckedChanged);
            // 
            // uiNewFollowerTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiNewFollowerTextBox, 2);
            this.uiNewFollowerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiNewFollowerTextBox.Location = new System.Drawing.Point(145, 31);
            this.uiNewFollowerTextBox.Multiline = true;
            this.uiNewFollowerTextBox.Name = "uiNewFollowerTextBox";
            this.uiNewFollowerTextBox.Size = new System.Drawing.Size(333, 44);
            this.uiNewFollowerTextBox.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(131, 50);
            this.label1.TabIndex = 20;
            this.label1.Text = "New Follower Message:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 78);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(131, 50);
            this.label2.TabIndex = 21;
            this.label2.Text = "New Subscriber Message:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 218);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(131, 50);
            this.label3.TabIndex = 24;
            this.label3.Text = "Ad Break Message:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiShowAdBreakMessageAtWarningCheckBox
            // 
            this.uiShowAdBreakMessageAtWarningCheckBox.AutoSize = true;
            this.uiShowAdBreakMessageAtWarningCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tableLayoutPanel1.SetColumnSpan(this.uiShowAdBreakMessageAtWarningCheckBox, 2);
            this.uiShowAdBreakMessageAtWarningCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiShowAdBreakMessageAtWarningCheckBox.Location = new System.Drawing.Point(145, 271);
            this.uiShowAdBreakMessageAtWarningCheckBox.Name = "uiShowAdBreakMessageAtWarningCheckBox";
            this.uiShowAdBreakMessageAtWarningCheckBox.Size = new System.Drawing.Size(333, 34);
            this.uiShowAdBreakMessageAtWarningCheckBox.TabIndex = 27;
            this.uiShowAdBreakMessageAtWarningCheckBox.Text = "Show ad break message when Twitch Monitor warns the ad break will be starting soo" +
                "n";
            this.uiShowAdBreakMessageAtWarningCheckBox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.uiShowAdBreakMessageAtWarningCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 128);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(131, 50);
            this.label4.TabIndex = 28;
            this.label4.Text = "Re-Subscriber Message:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // uiReSubscriberTextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.uiReSubscriberTextBox, 2);
            this.uiReSubscriberTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiReSubscriberTextBox.Location = new System.Drawing.Point(145, 131);
            this.uiReSubscriberTextBox.Multiline = true;
            this.uiReSubscriberTextBox.Name = "uiReSubscriberTextBox";
            this.uiReSubscriberTextBox.Size = new System.Drawing.Size(333, 44);
            this.uiReSubscriberTextBox.TabIndex = 29;
            // 
            // uiUseNewSubscriberMessageCheckBox
            // 
            this.uiUseNewSubscriberMessageCheckBox.AutoSize = true;
            this.uiUseNewSubscriberMessageCheckBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tableLayoutPanel1.SetColumnSpan(this.uiUseNewSubscriberMessageCheckBox, 2);
            this.uiUseNewSubscriberMessageCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiUseNewSubscriberMessageCheckBox.Location = new System.Drawing.Point(145, 181);
            this.uiUseNewSubscriberMessageCheckBox.Name = "uiUseNewSubscriberMessageCheckBox";
            this.uiUseNewSubscriberMessageCheckBox.Size = new System.Drawing.Size(333, 34);
            this.uiUseNewSubscriberMessageCheckBox.TabIndex = 30;
            this.uiUseNewSubscriberMessageCheckBox.Text = "Use new subscriber message";
            this.uiUseNewSubscriberMessageCheckBox.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.uiUseNewSubscriberMessageCheckBox.UseVisualStyleBackColor = true;
            this.uiUseNewSubscriberMessageCheckBox.CheckedChanged += new System.EventHandler(this.uiUseNewSubscriberMessageCheckBox_CheckedChanged);
            // 
            // IrcChatNotificationsSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "IrcChatNotificationsSettingsControl";
            this.Size = new System.Drawing.Size(512, 545);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox uiNewSubscriberTextBox;
        private System.Windows.Forms.TextBox uiNewFollowerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox uiShowNotificationsInChatCheckBox;
        private System.Windows.Forms.TextBox uiAdBreakTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox uiStringTokensRichTextBox;
        private System.Windows.Forms.CheckBox uiShowAdBreakMessageAtWarningCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uiReSubscriberTextBox;
        private System.Windows.Forms.CheckBox uiUseNewSubscriberMessageCheckBox;
    }
}

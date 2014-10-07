namespace TwitchMonitor.Controls
{
    partial class IrcSettingsControl
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
            this.uiBottSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.uiAnyModeratorRadioButton = new System.Windows.Forms.RadioButton();
            this.uiChannelOwnerOnlyRadioButton = new System.Windows.Forms.RadioButton();
            this.uiEnabledOnStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.uiAuthorizeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uiUsernameTextBox = new System.Windows.Forms.TextBox();
            this.uiPasswordTextBox = new System.Windows.Forms.TextBox();
            this.uiFakeSeparatorLabel = new System.Windows.Forms.Label();
            this.uiBottSettingsGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiBottSettingsGroupBox
            // 
            this.uiBottSettingsGroupBox.Controls.Add(this.groupBox2);
            this.uiBottSettingsGroupBox.Controls.Add(this.uiEnabledOnStartupCheckBox);
            this.uiBottSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiBottSettingsGroupBox.Location = new System.Drawing.Point(10, 99);
            this.uiBottSettingsGroupBox.Name = "uiBottSettingsGroupBox";
            this.uiBottSettingsGroupBox.Size = new System.Drawing.Size(465, 119);
            this.uiBottSettingsGroupBox.TabIndex = 1;
            this.uiBottSettingsGroupBox.TabStop = false;
            this.uiBottSettingsGroupBox.Text = "Bot Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.uiAnyModeratorRadioButton);
            this.groupBox2.Controls.Add(this.uiChannelOwnerOnlyRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 70);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chat commands will be enabled for the following user(s)...";
            // 
            // uiAnyModeratorRadioButton
            // 
            this.uiAnyModeratorRadioButton.AutoSize = true;
            this.uiAnyModeratorRadioButton.Location = new System.Drawing.Point(16, 43);
            this.uiAnyModeratorRadioButton.Name = "uiAnyModeratorRadioButton";
            this.uiAnyModeratorRadioButton.Size = new System.Drawing.Size(211, 17);
            this.uiAnyModeratorRadioButton.TabIndex = 3;
            this.uiAnyModeratorRadioButton.TabStop = true;
            this.uiAnyModeratorRadioButton.Text = "Channel owner and any chat moderator";
            this.uiAnyModeratorRadioButton.UseVisualStyleBackColor = true;
            // 
            // uiChannelOwnerOnlyRadioButton
            // 
            this.uiChannelOwnerOnlyRadioButton.AutoSize = true;
            this.uiChannelOwnerOnlyRadioButton.Location = new System.Drawing.Point(16, 19);
            this.uiChannelOwnerOnlyRadioButton.Name = "uiChannelOwnerOnlyRadioButton";
            this.uiChannelOwnerOnlyRadioButton.Size = new System.Drawing.Size(128, 17);
            this.uiChannelOwnerOnlyRadioButton.TabIndex = 2;
            this.uiChannelOwnerOnlyRadioButton.TabStop = true;
            this.uiChannelOwnerOnlyRadioButton.Text = "Channel owner ONLY";
            this.uiChannelOwnerOnlyRadioButton.UseVisualStyleBackColor = true;
            // 
            // uiEnabledOnStartupCheckBox
            // 
            this.uiEnabledOnStartupCheckBox.AutoSize = true;
            this.uiEnabledOnStartupCheckBox.Location = new System.Drawing.Point(10, 20);
            this.uiEnabledOnStartupCheckBox.Name = "uiEnabledOnStartupCheckBox";
            this.uiEnabledOnStartupCheckBox.Size = new System.Drawing.Size(115, 17);
            this.uiEnabledOnStartupCheckBox.TabIndex = 0;
            this.uiEnabledOnStartupCheckBox.Text = "Enabled on startup";
            this.uiEnabledOnStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiAuthorizeButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiUsernameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiPasswordTextBox, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(459, 62);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "IRC Authorization Token:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiAuthorizeButton
            // 
            this.uiAuthorizeButton.Location = new System.Drawing.Point(387, 31);
            this.uiAuthorizeButton.Name = "uiAuthorizeButton";
            this.uiAuthorizeButton.Size = new System.Drawing.Size(69, 23);
            this.uiAuthorizeButton.TabIndex = 4;
            this.uiAuthorizeButton.Text = "Authorize";
            this.uiAuthorizeButton.UseVisualStyleBackColor = true;
            this.uiAuthorizeButton.Click += new System.EventHandler(this.uiAuthorizeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiUsernameTextBox
            // 
            this.uiUsernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.uiUsernameTextBox, 2);
            this.uiUsernameTextBox.Location = new System.Drawing.Point(135, 5);
            this.uiUsernameTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.uiUsernameTextBox.Name = "uiUsernameTextBox";
            this.uiUsernameTextBox.Size = new System.Drawing.Size(321, 20);
            this.uiUsernameTextBox.TabIndex = 0;
            // 
            // uiPasswordTextBox
            // 
            this.uiPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiPasswordTextBox.Location = new System.Drawing.Point(135, 33);
            this.uiPasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.uiPasswordTextBox.Name = "uiPasswordTextBox";
            this.uiPasswordTextBox.Size = new System.Drawing.Size(246, 20);
            this.uiPasswordTextBox.TabIndex = 1;
            // 
            // uiFakeSeparatorLabel
            // 
            this.uiFakeSeparatorLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiFakeSeparatorLabel.Location = new System.Drawing.Point(10, 91);
            this.uiFakeSeparatorLabel.Name = "uiFakeSeparatorLabel";
            this.uiFakeSeparatorLabel.Size = new System.Drawing.Size(465, 8);
            this.uiFakeSeparatorLabel.TabIndex = 2;
            // 
            // IrcSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiBottSettingsGroupBox);
            this.Controls.Add(this.uiFakeSeparatorLabel);
            this.Controls.Add(this.groupBox1);
            this.Name = "IrcSettingsControl";
            this.Size = new System.Drawing.Size(485, 432);
            this.uiBottSettingsGroupBox.ResumeLayout(false);
            this.uiBottSettingsGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uiPasswordTextBox;
        private System.Windows.Forms.TextBox uiUsernameTextBox;
        private System.Windows.Forms.GroupBox uiBottSettingsGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton uiAnyModeratorRadioButton;
        private System.Windows.Forms.RadioButton uiChannelOwnerOnlyRadioButton;
        private System.Windows.Forms.CheckBox uiEnabledOnStartupCheckBox;
        private System.Windows.Forms.Button uiAuthorizeButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label uiFakeSeparatorLabel;
    }
}

namespace TwitchMonitor.UI.Controls
{
    partial class MissileLauncherSettingsControl
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
            this.uiUsbLibraryPathLabel = new System.Windows.Forms.Label();
            this.uiUsbLibraryTextBox = new System.Windows.Forms.TextBox();
            this.uiBrowseButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uiFireOnNewSubCheckBox = new System.Windows.Forms.CheckBox();
            this.uiFireOnReSubscriberCheckBox = new System.Windows.Forms.CheckBox();
            this.uiFireOnNewFollowerCheckBox = new System.Windows.Forms.CheckBox();
            this.uiFireOnLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiTestFireButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiUsbLibraryPathLabel
            // 
            this.uiUsbLibraryPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiUsbLibraryPathLabel.AutoSize = true;
            this.uiUsbLibraryPathLabel.Location = new System.Drawing.Point(3, 0);
            this.uiUsbLibraryPathLabel.Name = "uiUsbLibraryPathLabel";
            this.uiUsbLibraryPathLabel.Size = new System.Drawing.Size(164, 29);
            this.uiUsbLibraryPathLabel.TabIndex = 0;
            this.uiUsbLibraryPathLabel.Text = "Dream Cheeky USB Library Path:";
            this.uiUsbLibraryPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uiUsbLibraryTextBox
            // 
            this.uiUsbLibraryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiUsbLibraryTextBox.Location = new System.Drawing.Point(173, 3);
            this.uiUsbLibraryTextBox.Name = "uiUsbLibraryTextBox";
            this.uiUsbLibraryTextBox.Size = new System.Drawing.Size(255, 20);
            this.uiUsbLibraryTextBox.TabIndex = 1;
            // 
            // uiBrowseButton
            // 
            this.uiBrowseButton.Location = new System.Drawing.Point(434, 3);
            this.uiBrowseButton.Name = "uiBrowseButton";
            this.uiBrowseButton.Size = new System.Drawing.Size(24, 23);
            this.uiBrowseButton.TabIndex = 2;
            this.uiBrowseButton.Text = "...";
            this.uiBrowseButton.UseVisualStyleBackColor = true;
            this.uiBrowseButton.Click += new System.EventHandler(this.uiBrowseButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "DLL files|*.dll";
            // 
            // uiFireOnNewSubCheckBox
            // 
            this.uiFireOnNewSubCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiFireOnNewSubCheckBox, 3);
            this.uiFireOnNewSubCheckBox.Location = new System.Drawing.Point(3, 55);
            this.uiFireOnNewSubCheckBox.Name = "uiFireOnNewSubCheckBox";
            this.uiFireOnNewSubCheckBox.Size = new System.Drawing.Size(101, 17);
            this.uiFireOnNewSubCheckBox.TabIndex = 3;
            this.uiFireOnNewSubCheckBox.Text = "New Subscriber";
            this.uiFireOnNewSubCheckBox.UseVisualStyleBackColor = true;
            // 
            // uiFireOnReSubscriberCheckBox
            // 
            this.uiFireOnReSubscriberCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiFireOnReSubscriberCheckBox, 3);
            this.uiFireOnReSubscriberCheckBox.Location = new System.Drawing.Point(3, 78);
            this.uiFireOnReSubscriberCheckBox.Name = "uiFireOnReSubscriberCheckBox";
            this.uiFireOnReSubscriberCheckBox.Size = new System.Drawing.Size(93, 17);
            this.uiFireOnReSubscriberCheckBox.TabIndex = 4;
            this.uiFireOnReSubscriberCheckBox.Text = "Re-Subscriber";
            this.uiFireOnReSubscriberCheckBox.UseVisualStyleBackColor = true;
            // 
            // uiFireOnNewFollowerCheckBox
            // 
            this.uiFireOnNewFollowerCheckBox.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiFireOnNewFollowerCheckBox, 3);
            this.uiFireOnNewFollowerCheckBox.Location = new System.Drawing.Point(3, 101);
            this.uiFireOnNewFollowerCheckBox.Name = "uiFireOnNewFollowerCheckBox";
            this.uiFireOnNewFollowerCheckBox.Size = new System.Drawing.Size(90, 17);
            this.uiFireOnNewFollowerCheckBox.TabIndex = 5;
            this.uiFireOnNewFollowerCheckBox.Text = "New Follower";
            this.uiFireOnNewFollowerCheckBox.UseVisualStyleBackColor = true;
            // 
            // uiFireOnLabel
            // 
            this.uiFireOnLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.uiFireOnLabel, 3);
            this.uiFireOnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiFireOnLabel.Location = new System.Drawing.Point(3, 29);
            this.uiFireOnLabel.Name = "uiFireOnLabel";
            this.uiFireOnLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.uiFireOnLabel.Size = new System.Drawing.Size(303, 23);
            this.uiFireOnLabel.TabIndex = 6;
            this.uiFireOnLabel.Text = "Fire a missile when Twitch Monitor detects any of the following:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.uiUsbLibraryPathLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiFireOnNewFollowerCheckBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.uiFireOnLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiFireOnReSubscriberCheckBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.uiUsbLibraryTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiFireOnNewSubCheckBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.uiBrowseButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.uiTestFireButton, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(542, 228);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // uiTestFireButton
            // 
            this.uiTestFireButton.Location = new System.Drawing.Point(464, 3);
            this.uiTestFireButton.Name = "uiTestFireButton";
            this.uiTestFireButton.Size = new System.Drawing.Size(75, 23);
            this.uiTestFireButton.TabIndex = 7;
            this.uiTestFireButton.Text = "Test Fire";
            this.uiTestFireButton.UseVisualStyleBackColor = true;
            this.uiTestFireButton.Click += new System.EventHandler(this.uiTestFireButton_Click);
            // 
            // MissileLauncherSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MissileLauncherSettingsControl";
            this.Size = new System.Drawing.Size(542, 228);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label uiUsbLibraryPathLabel;
        private System.Windows.Forms.TextBox uiUsbLibraryTextBox;
        private System.Windows.Forms.Button uiBrowseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox uiFireOnNewSubCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox uiFireOnNewFollowerCheckBox;
        private System.Windows.Forms.Label uiFireOnLabel;
        private System.Windows.Forms.CheckBox uiFireOnReSubscriberCheckBox;
        private System.Windows.Forms.Button uiTestFireButton;
    }
}

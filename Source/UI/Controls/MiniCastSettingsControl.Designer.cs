namespace TwitchMonitor.UI.Controls
{
    partial class MiniCastSettingsControl
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
            this.uiShowViewerCountCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.uiShowNewFollowersCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiShowViewerCountCheckBox
            // 
            this.uiShowViewerCountCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiShowViewerCountCheckBox.AutoSize = true;
            this.uiShowViewerCountCheckBox.Location = new System.Drawing.Point(6, 19);
            this.uiShowViewerCountCheckBox.Name = "uiShowViewerCountCheckBox";
            this.uiShowViewerCountCheckBox.Size = new System.Drawing.Size(119, 17);
            this.uiShowViewerCountCheckBox.TabIndex = 0;
            this.uiShowViewerCountCheckBox.Text = "Show Viewer Count";
            this.uiShowViewerCountCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.uiShowNewFollowersCheckBox);
            this.groupBox1.Controls.Add(this.uiShowViewerCountCheckBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MiniCast Monitor Settings";
            // 
            // uiShowNewFollowersCheckBox
            // 
            this.uiShowNewFollowersCheckBox.AutoSize = true;
            this.uiShowNewFollowersCheckBox.Location = new System.Drawing.Point(6, 43);
            this.uiShowNewFollowersCheckBox.Name = "uiShowNewFollowersCheckBox";
            this.uiShowNewFollowersCheckBox.Size = new System.Drawing.Size(171, 17);
            this.uiShowNewFollowersCheckBox.TabIndex = 1;
            this.uiShowNewFollowersCheckBox.Text = "Show New Follower Messages";
            this.uiShowNewFollowersCheckBox.UseVisualStyleBackColor = true;
            // 
            // MiniCastSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "MiniCastSettingsControl";
            this.Size = new System.Drawing.Size(307, 153);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox uiShowViewerCountCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox uiShowNewFollowersCheckBox;
    }
}

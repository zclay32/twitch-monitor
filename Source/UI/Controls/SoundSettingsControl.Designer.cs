namespace TwitchMonitor.UI.Controls
{
    partial class SoundSettingsControl
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
            this.uiNewFollowerSoundTriggerControl = new TwitchMonitor.UI.Controls.SoundTriggerControl();
            this.uiNewSubscriberSoundTriggerControl = new TwitchMonitor.UI.Controls.SoundTriggerControl();
            this.uiReSubscriberSoundTriggerControl = new TwitchMonitor.UI.Controls.SoundTriggerControl();
            this.SuspendLayout();
            // 
            // uiNewFollowerSoundTriggerControl
            // 
            this.uiNewFollowerSoundTriggerControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNewFollowerSoundTriggerControl.Location = new System.Drawing.Point(3, 3);
            this.uiNewFollowerSoundTriggerControl.MinimumSize = new System.Drawing.Size(361, 140);
            this.uiNewFollowerSoundTriggerControl.Name = "uiNewFollowerSoundTriggerControl";
            this.uiNewFollowerSoundTriggerControl.Size = new System.Drawing.Size(432, 140);
            this.uiNewFollowerSoundTriggerControl.SoundDirectoryPath = "";
            this.uiNewFollowerSoundTriggerControl.SoundFilePath = "";
            this.uiNewFollowerSoundTriggerControl.SoundType = TwitchMonitor.Core.PlaySoundType.None;
            this.uiNewFollowerSoundTriggerControl.TabIndex = 0;
            this.uiNewFollowerSoundTriggerControl.Title = "New Follower Sound Settings";
            this.uiNewFollowerSoundTriggerControl.VolumeLevel = 0;
            // 
            // uiNewSubscriberSoundTriggerControl
            // 
            this.uiNewSubscriberSoundTriggerControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiNewSubscriberSoundTriggerControl.Location = new System.Drawing.Point(3, 149);
            this.uiNewSubscriberSoundTriggerControl.MinimumSize = new System.Drawing.Size(361, 140);
            this.uiNewSubscriberSoundTriggerControl.Name = "uiNewSubscriberSoundTriggerControl";
            this.uiNewSubscriberSoundTriggerControl.Size = new System.Drawing.Size(432, 140);
            this.uiNewSubscriberSoundTriggerControl.SoundDirectoryPath = "";
            this.uiNewSubscriberSoundTriggerControl.SoundFilePath = "";
            this.uiNewSubscriberSoundTriggerControl.SoundType = TwitchMonitor.Core.PlaySoundType.None;
            this.uiNewSubscriberSoundTriggerControl.TabIndex = 1;
            this.uiNewSubscriberSoundTriggerControl.Title = "New Subscriber Sound Settings";
            this.uiNewSubscriberSoundTriggerControl.VolumeLevel = 0;
            // 
            // uiReSubscriberSoundTriggerControl
            // 
            this.uiReSubscriberSoundTriggerControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uiReSubscriberSoundTriggerControl.Location = new System.Drawing.Point(3, 295);
            this.uiReSubscriberSoundTriggerControl.MinimumSize = new System.Drawing.Size(361, 140);
            this.uiReSubscriberSoundTriggerControl.Name = "uiReSubscriberSoundTriggerControl";
            this.uiReSubscriberSoundTriggerControl.Size = new System.Drawing.Size(432, 140);
            this.uiReSubscriberSoundTriggerControl.SoundDirectoryPath = "";
            this.uiReSubscriberSoundTriggerControl.SoundFilePath = "";
            this.uiReSubscriberSoundTriggerControl.SoundType = TwitchMonitor.Core.PlaySoundType.None;
            this.uiReSubscriberSoundTriggerControl.TabIndex = 2;
            this.uiReSubscriberSoundTriggerControl.Title = "Re-Subscriber Sound Settings";
            this.uiReSubscriberSoundTriggerControl.VolumeLevel = 0;
            // 
            // SoundSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiReSubscriberSoundTriggerControl);
            this.Controls.Add(this.uiNewSubscriberSoundTriggerControl);
            this.Controls.Add(this.uiNewFollowerSoundTriggerControl);
            this.Name = "SoundSettingsControl";
            this.Size = new System.Drawing.Size(438, 445);
            this.ResumeLayout(false);

        }

        #endregion

        private SoundTriggerControl uiNewFollowerSoundTriggerControl;
        private SoundTriggerControl uiNewSubscriberSoundTriggerControl;
        private SoundTriggerControl uiReSubscriberSoundTriggerControl;

    }
}

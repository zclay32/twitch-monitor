using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Controls;
using TwitchMonitor.Core.Interfaces;
using TwitchMonitor.Core;

namespace TwitchMonitor.UI.Controls
{
    public partial class SoundSettingsControl : BaseSettingsControl
    {
        public SoundSettingsControl() : base()
        {
            InitializeComponent();
        }

        public SoundSettingsControl(ISettingsView parent) : base(parent)
        {
            InitializeComponent();

            this.uiNewFollowerSoundTriggerControl.Initialize(parent);
            this.uiNewSubscriberSoundTriggerControl.Initialize(parent);
            this.uiReSubscriberSoundTriggerControl.Initialize(parent);
        }

        public override void LoadSettings()
        {
            this.LoadSettingsToControl(this.uiNewFollowerSoundTriggerControl, this.ParentView.Engine.Settings.FollowerSounds);
            this.LoadSettingsToControl(this.uiNewSubscriberSoundTriggerControl, this.ParentView.Engine.Settings.SubscriberSounds);
            this.LoadSettingsToControl(this.uiReSubscriberSoundTriggerControl, this.ParentView.Engine.Settings.ReSubscriberSounds);
        }

        public override void SaveSettings()
        {
            this.SaveSettingsFromControl(this.uiNewFollowerSoundTriggerControl, this.ParentView.Engine.Settings.FollowerSounds);
            this.SaveSettingsFromControl(this.uiNewSubscriberSoundTriggerControl, this.ParentView.Engine.Settings.SubscriberSounds);
            this.SaveSettingsFromControl(this.uiReSubscriberSoundTriggerControl, this.ParentView.Engine.Settings.ReSubscriberSounds);
        }

        private void LoadSettingsToControl(SoundTriggerControl control, SoundPlaySettings soundSettings)
        {
            control.SoundDirectoryPath = soundSettings.SoundDirectory;
            control.SoundFilePath = soundSettings.SoundFile;
            control.VolumeLevel = soundSettings.SoundVolume;
            control.SoundType = soundSettings.PlaySoundType;

            control.RefreshFields();
        }

        private void SaveSettingsFromControl(SoundTriggerControl control, SoundPlaySettings soundSettings)
        {
            soundSettings.SoundDirectory = control.SoundDirectoryPath;
            soundSettings.SoundFile = control.SoundFilePath;
            soundSettings.SoundVolume = control.VolumeLevel;
            soundSettings.PlaySoundType = control.SoundType;
        }
    }
}

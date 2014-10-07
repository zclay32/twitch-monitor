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

namespace TwitchMonitor.UI.Controls
{
    public partial class MiniCastSettingsControl : BaseSettingsControl
    {
        public MiniCastSettingsControl() : base()
        {
            InitializeComponent();
        }

        public MiniCastSettingsControl(ISettingsView parent) : base(parent)
        {
            this.InitializeComponent();
        }

        public override void LoadSettings()
        {
            this.uiShowViewerCountCheckBox.Checked = this.ParentView.Engine.Settings.MiniCast.ShowViewerCount;
            this.uiShowNewFollowersCheckBox.Checked = this.ParentView.Engine.Settings.MiniCast.ShowNewFollowerMessages;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SaveSettings()
        {
            this.ParentView.Engine.Settings.MiniCast.ShowViewerCount = this.uiShowViewerCountCheckBox.Checked;
            this.ParentView.Engine.Settings.MiniCast.ShowNewFollowerMessages = this.uiShowNewFollowersCheckBox.Checked;
        }
    }
}

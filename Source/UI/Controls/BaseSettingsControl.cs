using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Core.Interfaces;

namespace TwitchMonitor.Controls
{
    public partial class BaseSettingsControl : UserControl
    {
        public ISettingsView ParentView { get; protected set; }

        public BaseSettingsControl()
        {
            InitializeComponent();
        }
        public BaseSettingsControl(ISettingsView parent)
        {
            InitializeComponent();

            this.ParentView = parent;
        }

        public virtual void LoadSettings()
        {
        }

        public virtual void SaveSettings()
        {
        }
    }
}

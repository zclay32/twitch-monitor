using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Core;
using TwitchMonitor.Core.Apis.KeyboardCommands;

namespace TwitchMonitor.UI
{
    public partial class AddOrEditKeyCommandDialog : Form
    {
        public AddOrEditKeyCommandDialog()
        {
            InitializeComponent();

            this.uiKeyCommandComboBox.DataSource = Enum.GetValues(typeof(KeyCommandType));
        }

        public void SetKeyCommandEntry(KeyCommandEntry entry)
        {
            this.uiCommandTextBox.Text = entry.Name;
            this.uiKeyCommandComboBox.SelectedItem = entry.Command;
            this.uiMessageTextBox.Text = entry.CustomValue;
            this.uiIrcCommandTextBox.Text = entry.IrcCommand;
        }

        public KeyCommandEntry GetKeyCommandEntry()
        {
            KeyCommandEntry entry = new KeyCommandEntry();
            entry.Name = this.uiCommandTextBox.Text;
            entry.Command = (KeyCommandType)this.uiKeyCommandComboBox.SelectedItem;
            entry.CustomValue = this.uiMessageTextBox.Text;
            entry.IrcCommand = this.uiIrcCommandTextBox.Text;
            return entry;
        }
    }
}

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
using TwitchMonitor.Core.Apis.KeyboardCommands;

namespace TwitchMonitor.UI.Controls
{
    public partial class KeyCommandSettingsControl : BaseSettingsControl
    {
        private Dictionary<ListViewItem, KeyCommandEntry> commands;

        /// <summary>
        /// Default constructor that initializes this object to be used by the Designer.
        /// </summary>
        public KeyCommandSettingsControl() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor that stores a reference to the parent settings object to be used when loading and saving the settings.
        /// </summary>
        /// <param name="parent"></param>
        public KeyCommandSettingsControl(ISettingsView parent)
            : base(parent)
        {
            InitializeComponent();

            this.commands = new Dictionary<ListViewItem, KeyCommandEntry>();
        }

        /// <summary>
        /// Loads all the settings into the controls.
        /// </summary>
        public override void LoadSettings()
        {
            this.uiWindowNameTextBox.Text = this.ParentView.Engine.Settings.KeyCommands.WindowName;
            this.uiClassNameTextBox.Text = this.ParentView.Engine.Settings.KeyCommands.ClassName;
            this.uiWindowDimensionXTextBox.Text = this.ParentView.Engine.Settings.KeyCommands.WindowX;
            this.uiWindowDimensionYTextBox.Text = this.ParentView.Engine.Settings.KeyCommands.WindowY;

            foreach (KeyCommandEntry entry in this.ParentView.Engine.Settings.KeyCommands.Commands)
            {
                this.AddOrEditCommand(entry);
            }
        }

        /// <summary>
        /// Saves all the settings.
        /// </summary>
        public override void SaveSettings()
        {
            this.ParentView.Engine.Settings.KeyCommands.WindowName = this.uiWindowNameTextBox.Text;
            this.ParentView.Engine.Settings.KeyCommands.ClassName = this.uiClassNameTextBox.Text;
            this.ParentView.Engine.Settings.KeyCommands.Commands = this.commands.Values.ToList();
            this.ParentView.Engine.Settings.KeyCommands.WindowX = this.uiWindowDimensionXTextBox.Text;
            this.ParentView.Engine.Settings.KeyCommands.WindowY = this.uiWindowDimensionYTextBox.Text;
        }

        private void AddOrEditCommand(KeyCommandEntry command)
        {
            ListViewItem itemToEdit = null;
            foreach (ListViewItem item in this.commands.Keys)
            {
                if (this.commands[item].Name.Equals(command.Name))
                {
                    itemToEdit = item;
                    break;
                }
            }

            //  Add a new item for this entry if it wasn't found.
            if (itemToEdit == null)
            {
                itemToEdit = new ListViewItem(new string[] {"", "", ""} );
                this.uiKeyCommandsListView.Items.Add(itemToEdit);
            }

            itemToEdit.SubItems[0].Text = command.Name;
            itemToEdit.SubItems[1].Text = command.Command == KeyCommandType.Custom ? command.CustomValue : command.Command.ToString();
            itemToEdit.SubItems[2].Text = command.IrcCommand;
            this.commands[itemToEdit] = command;
        }

        private void uiNewKeyButton_Click(object sender, EventArgs e)
        {
            using (AddOrEditKeyCommandDialog dialog = new AddOrEditKeyCommandDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.AddOrEditCommand(dialog.GetKeyCommandEntry());
                }
            }
        }

        private void uiEditButton_Click(object sender, EventArgs e)
        {
            using (AddOrEditKeyCommandDialog dialog = new AddOrEditKeyCommandDialog())
            {
                if (this.uiKeyCommandsListView.SelectedItems.Count > 0)
                {
                    dialog.SetKeyCommandEntry(this.commands[this.uiKeyCommandsListView.SelectedItems[0]]);
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.AddOrEditCommand(dialog.GetKeyCommandEntry());
                }
            }
        }

        private void uiRemoveButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.uiKeyCommandsListView.SelectedItems)
            {
                this.uiKeyCommandsListView.Items.Remove(item);
                this.commands.Remove(item);
            }
        }
    }
}

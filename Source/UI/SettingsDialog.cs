using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwitchMonitor.Controls;
using TwitchMonitor.Core;
using TwitchMonitor.Core.Interfaces;
using TwitchMonitor.UI.Controls;

namespace TwitchMonitor
{
    public partial class SettingsDialog : Form, ISettingsView
    {
        //======================================================================
        //  Private Members
        //======================================================================
        private TwitchChannelSettings uiTwitchChannelSettings;
        private SubscriberSettingsControl uiSubscriberSettingsControl;
        private SoundSettingsControl uiSoundSettingsControl;
        private FileOutputSettingsControl uiFileOutputSettingsControl;
        private MiniCastSettingsControl uiMiniCastSettingsControl;
        private NewSubcriberSettingsControl uiNotificationsControl;
        private IrcSettingsControl uiIrcSettingsControl;
        private IrcFontsAndColorsSettingsControl uiIrcFontsAndColorsSettingsControl;
        private IrcChatNotificationsSettingsControl uiIrcChatNotificationsSettingsControl;
        private MissileLauncherSettingsControl uiMissileLauncherSettingsControl;
        private KeyCommandSettingsControl uiKeyCommandSettingsControl;

        private Dictionary<string, TreeNode> settingsGroups;
        private Dictionary<TreeNode, Control> settingsNodes;
        private TreeNode defaultSelectedNode;

        private static readonly string GeneralGroup       = "General";
        private static readonly string NotificationsGroup = "Notifications";
        private static readonly string IrcGroup           = "IRC";
        private static readonly string PartnersGroup      = "Partnered Accounts";
        private static readonly string FunStuffGroup      = "Fun Stuff";

        //======================================================================
        //  Public Properties
        //======================================================================
        /// <summary>
        /// Gets or sets the engine object for this form to use.
        /// </summary>
        public Engine Engine { get; set; }

        /// <summary>
        /// Gets whether or not the settings view is loading.
        /// </summary>
        public bool IsLoading { get; private set; }

        //======================================================================
        //  Constructors
        //======================================================================
        /// <summary>
        /// 
        /// </summary>
        public SettingsDialog()
        {
            InitializeComponent();

            this.IsLoading = false;

            //------------------------------------------------------------------
            //  Setup each of the settings control objects.
            //------------------------------------------------------------------
            this.uiTwitchChannelSettings = new TwitchChannelSettings(this);
            this.uiSubscriberSettingsControl = new SubscriberSettingsControl(this);
            this.uiSoundSettingsControl = new SoundSettingsControl(this);
            this.uiFileOutputSettingsControl = new FileOutputSettingsControl(this);
            this.uiMiniCastSettingsControl = new MiniCastSettingsControl(this);
            this.uiNotificationsControl = new NewSubcriberSettingsControl(this);
            this.uiIrcSettingsControl = new IrcSettingsControl(this);
            this.uiIrcFontsAndColorsSettingsControl = new IrcFontsAndColorsSettingsControl(this);
            this.uiIrcChatNotificationsSettingsControl = new IrcChatNotificationsSettingsControl(this);
            this.uiMissileLauncherSettingsControl = new MissileLauncherSettingsControl(this);
            this.uiKeyCommandSettingsControl = new KeyCommandSettingsControl(this);

            this.settingsGroups = new Dictionary<string, TreeNode>();
            this.settingsNodes = new Dictionary<TreeNode, Control>();

            this.RegisterSettingsControl(SettingsDialog.GeneralGroup, "Profiles", this.uiTwitchChannelSettings, true);
            this.RegisterSettingsControl(SettingsDialog.GeneralGroup, "File Output", this.uiFileOutputSettingsControl);
            this.RegisterSettingsControl(SettingsDialog.GeneralGroup, "MiniCast Monitor", this.uiMiniCastSettingsControl);
            this.RegisterSettingsControl(SettingsDialog.NotificationsGroup, "Sounds", this.uiSoundSettingsControl);
            this.RegisterSettingsControl(SettingsDialog.NotificationsGroup, "Announcement Overlay", this.uiNotificationsControl);
            this.RegisterSettingsControl(SettingsDialog.PartnersGroup, "Ads", this.uiSubscriberSettingsControl);
            this.RegisterSettingsControl(SettingsDialog.IrcGroup, "General", this.uiIrcSettingsControl);
            this.RegisterSettingsControl(SettingsDialog.IrcGroup, "Fonts and Colors", this.uiIrcFontsAndColorsSettingsControl);
            this.RegisterSettingsControl(SettingsDialog.IrcGroup, "Notification Messages", this.uiIrcChatNotificationsSettingsControl);
            this.RegisterSettingsControl(SettingsDialog.FunStuffGroup, "Missile Launcher", this.uiMissileLauncherSettingsControl);
            this.RegisterSettingsControl(SettingsDialog.FunStuffGroup, "Key Commander", this.uiKeyCommandSettingsControl);

            //------------------------------------------------------------------
            //  Default the selection to the first in the list.
            //------------------------------------------------------------------
            this.uiSettingsTreeView.SelectedNode = this.defaultSelectedNode;
            this.ShowSelectedSettings();
            this.uiSettingsTreeView.ExpandAll();
        }

        //======================================================================
        //  Public Methods
        //======================================================================
        /// <summary>
        /// Handles a change detected by one of the child controls. This way the user is only presented with the option
        /// to save their settings if anything has been changed.
        /// </summary>
        public void ChangeDetected()
        {
            this.uiOkButton.Enabled = true;
        }

        /// <summary>
        /// Saves the settings to the engine and to disk.
        /// </summary>
        public void SaveSettings()
        {
            foreach (BaseSettingsControl settingsControl in this.settingsNodes.Values)
            {
                settingsControl.SaveSettings();
            }

            this.Engine.SaveSettings();
        }

        /// <summary>
        /// Loads the settings from the engine.
        /// </summary>
        public void LoadSettings(Engine engine)
        {
            this.IsLoading = true;
            this.Engine = engine;

            foreach (BaseSettingsControl settingsControl in this.settingsNodes.Values)
            {
                settingsControl.LoadSettings();
            }

            this.IsLoading = false;
        }

        //======================================================================
        //  Private Methods
        //======================================================================
        /// <summary>
        /// Registers a settings control with this parent control.
        /// </summary>
        /// <param name="settingsName"></param>
        /// <param name="control"></param>
        private void RegisterSettingsControl(string group, string settingsName, Control control, bool isDefault = false)
        {
            if (!this.settingsGroups.ContainsKey(group))
            {
                this.settingsGroups[group] = this.uiSettingsTreeView.Nodes.Add(group);
            }
            TreeNode node = this.settingsGroups[group].Nodes.Add(settingsName);
            this.settingsNodes[node] = control;
            if (isDefault)
            {
                this.defaultSelectedNode = node;
            }

            this.uiActiveSettingsPanel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.Hide();
        }

        /// <summary>
        /// Event handler for when the selected index is changed in the ListBox containing all the settings names.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSettingsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowSelectedSettings();
        }

        /// <summary>
        /// Displays the appropriate settings based on the currently-selected ListBox item.
        /// </summary>
        private void ShowSelectedSettings()
        {
            //------------------------------------------------------------------
            //  Set the selected node.
            //------------------------------------------------------------------
            TreeNode selectedNode = this.uiSettingsTreeView.SelectedNode;
            if (selectedNode == null)
            {
                selectedNode = this.uiSettingsTreeView.TopNode;
                if (selectedNode == null) { return; }
            }
            
            if (selectedNode.Nodes.Count > 0)
            {
                selectedNode = selectedNode.Nodes[0];
            }

            //------------------------------------------------------------------
            //  Show/hide the correct control based on the current selection.
            //------------------------------------------------------------------
            var it = this.settingsNodes.GetEnumerator();
            while (it.MoveNext())
            {
                if (it.Current.Key.Equals(selectedNode))
                {
                    it.Current.Value.Show();
                }
                else
                {
                    it.Current.Value.Hide();
                }
            }
        }

        /// <summary>
        /// Event handler for after a tree node is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiSettingsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.ShowSelectedSettings();
        }
    }
}

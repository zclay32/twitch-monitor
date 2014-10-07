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
    public partial class IrcFontsAndColorsSettingsControl : BaseSettingsControl
    {
        public IrcFontsAndColorsSettingsControl() : base() { InitializeComponent(); }
        public IrcFontsAndColorsSettingsControl(ISettingsView parent)
            : base(parent)
        {
            InitializeComponent();

            this.uiTextColorButton.Click += (sender, e) => { this.PromptForColor(sender as Button); };
            this.uiBackColorButton.Click += (sender, e) => { this.PromptForColor(sender as Button); };
            this.uiModColorButton.Click += (sender, e) => { this.PromptForColor(sender as Button); };
            this.uiStatusColorButton.Click += (sender, e) => { this.PromptForColor(sender as Button); };
            this.uiErrorColorButton.Click += (sender, e) => { this.PromptForColor(sender as Button); };
            this.uiTimestampColorButton.Click += (sender, e) => { this.PromptForColor(sender as Button); };
        }

        /// <summary>
        /// Prompts the user to pick a color.
        /// </summary>
        /// <param name="button"></param>
        private void PromptForColor(Button button)
        {
            using (this.uiColorDialog = new ColorDialog())
            {
                this.uiColorDialog.Color = ColorTranslator.FromHtml(button.Text);
                if (this.uiColorDialog.ShowDialog() == DialogResult.OK)
                {
                    button.Text = ColorTranslator.ToHtml(this.uiColorDialog.Color);
                    button.ForeColor = this.uiColorDialog.Color;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void LoadSettings()
        {
            this.SetButtonColor(this.uiTextColorButton, this.ParentView.Engine.Settings.Irc.TextColor);
            this.SetButtonColor(this.uiBackColorButton, this.ParentView.Engine.Settings.Irc.BackColor);
            this.SetButtonColor(this.uiModColorButton, this.ParentView.Engine.Settings.Irc.ModColor);
            this.SetButtonColor(this.uiStatusColorButton, this.ParentView.Engine.Settings.Irc.StatusColor);
            this.SetButtonColor(this.uiErrorColorButton, this.ParentView.Engine.Settings.Irc.ErrorColor);
            this.SetButtonColor(this.uiTimestampColorButton, this.ParentView.Engine.Settings.Irc.TimestampColor);
            this.uiShowAllMessagesCheckBox.Checked = this.ParentView.Engine.Settings.Irc.ShowAllMessages;
            this.uiShowTimestampCheckBox.Checked = this.ParentView.Engine.Settings.Irc.ShowTimestamp;
        }

        /// <summary>
        /// Sets the color text for the button.
        /// </summary>
        /// <param name="color"></param>
        private void SetButtonColor(Button button, string color)
        {
            button.Text = color;
            button.ForeColor = ColorTranslator.FromHtml(color);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SaveSettings()
        {
            try
            {
                this.ParentView.Engine.Settings.Irc.TextColor = this.uiTextColorButton.Text;
                this.ParentView.Engine.Settings.Irc.BackColor = this.uiBackColorButton.Text;
                this.ParentView.Engine.Settings.Irc.ModColor = this.uiModColorButton.Text;
                this.ParentView.Engine.Settings.Irc.StatusColor = this.uiStatusColorButton.Text;
                this.ParentView.Engine.Settings.Irc.ErrorColor = this.uiErrorColorButton.Text;
                this.ParentView.Engine.Settings.Irc.TimestampColor = this.uiTimestampColorButton.Text;
                this.ParentView.Engine.Settings.Irc.ShowAllMessages = this.uiShowAllMessagesCheckBox.Checked;
                this.ParentView.Engine.Settings.Irc.ShowTimestamp = this.uiShowTimestampCheckBox.Checked;
            }
            catch (Exception ex)
            {
                this.ParentView.Engine.WriteStatusLogMessage("[ERROR] Failed to store the IRC display settings: " + ex.Message);
            }
        }
    }
}

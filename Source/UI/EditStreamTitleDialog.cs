using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitchMonitor.UI
{
    public partial class EditStreamTitleDialog : Form
    {
        public string StreamTitle
        {
            get { return this.uiStreamTitleTextBox.Text; }
            set { this.uiStreamTitleTextBox.Text = value; }
        }

        public string CurrentGame
        {
            get { return this.uiCurrentGameTextBox.Text; }
            set { this.uiCurrentGameTextBox.Text = value; }
        }

        public EditStreamTitleDialog()
        {
            InitializeComponent();
            this.UpdateCharacterCountText();
        }

        private void uiStreamTitleTextBox_TextChanged(object sender, EventArgs e)
        {
            this.UpdateCharacterCountText();
        }

        private void UpdateCharacterCountText()
        {
            this.uiCharacterCountLabel.Text = string.Format("{0} characters in title.", this.uiStreamTitleTextBox.Text.Length);
            if (this.uiStreamTitleTextBox.Text.Length > 130)
            {
                this.uiCharacterCountLabel.ForeColor = Color.DarkRed;
            }
            else
            {
                this.uiCharacterCountLabel.ForeColor = Color.Black;
            }
        }
    }
}

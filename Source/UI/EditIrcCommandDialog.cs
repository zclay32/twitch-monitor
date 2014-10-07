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
    public partial class EditIrcCommandDialog : Form
    {
        public string Command 
        {
            get { return this.uiCommandTextBox.Text; }
            set { this.uiCommandTextBox.Text = value; }
        }
        public string Message 
        { 
            get { return this.uiMessageTextBox.Text; }
            set { this.uiMessageTextBox.Text = value; }
        }

        public EditIrcCommandDialog()
        {
            InitializeComponent();
        }
    }
}

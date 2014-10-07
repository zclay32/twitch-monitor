using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TwitchMonitor.Controls
{
    public partial class FlickerFreeRichTextBox : RichTextBox
    {
        const short WM_PAINT = 0x00f;
        public bool _Paint = true;

        public FlickerFreeRichTextBox()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            // Code courtesy of Mark Mihevc
            // sometimes we want to eat the paint message so we don't have to see all the
            // flicker from when we select the text to change the color.
            switch (m.Msg)
            {
                case WM_PAINT:
                    if (_Paint)
                    {
                        base.WndProc(ref m); // if we decided to paint this control, just call the RichTextBox WndProc
                    }
                    else
                    {
                        m.Result = IntPtr.Zero; // not painting, must set this to IntPtr.Zero if not painting therwise serious problems.
                    }
                    break;

                default:
                    base.WndProc(ref m); // message other than WM_PAINT, jsut do what you normally do.
                    break;
            }
        }
    }
}

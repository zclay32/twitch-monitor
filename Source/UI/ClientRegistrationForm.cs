using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using TwitchMonitor.Core.Apis.Twitch;
using System.Runtime.InteropServices;

namespace TwitchMonitor
{
    public enum RegistrationMode
    {
        Default,
        IRC
    }

    public partial class ClientRegistrationForm : Form
    {
        private RegistrationMode mode;

        public string Username { get; set; }
        public string AuthenticationKey { get; private set; }
        public bool IsFinished { get; private set; }

        private static readonly string AuthorizationUri = "https://api.twitch.tv/kraken/oauth2/authorize?" +
                                            "response_type=token" +
                                            "&client_id=25rizidpx2zuq7wbj90mjmzzks7xuxo" +
                                            "&redirect_uri=http://www.zclaycreationz.com/twitch-monitor/authorization" +
                                            "&scope=channel_subscriptions%20channel_commercial%20channel_editor";

        private static readonly string IrcAuthorizationUri = "https://api.twitch.tv/kraken/oauth2/authorize?" +
                                            "response_type=token" +
                                            "&client_id=n94amde6xj7z3fo5e0811rqqrkjq8oe" +
                                            "&redirect_uri=http://www.zclaycreationz.com/twitch-monitor/irc_auth" +
                                            "&scope=chat_login";

        

        /// <summary>
        /// 
        /// </summary>
        public ClientRegistrationForm()
        {
            InitializeComponent();
            this.webBrowser1.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Hide();
            //this.Register();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Register(RegistrationMode mode = RegistrationMode.Default)
        {
            this.mode = mode;
            this.Hide();
            this.IsFinished = false;
            this.AuthenticationKey = string.Empty;

            string uri = string.Empty;
            switch (this.mode)
            {
                case RegistrationMode.IRC:
                    uri = ClientRegistrationForm.IrcAuthorizationUri;
                    break;

                case RegistrationMode.Default:
                default:
                    uri = ClientRegistrationForm.AuthorizationUri;
                    break;
            }
            this.webBrowser1.Url = new Uri(uri);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            try
            {
                if (e.Url.AbsoluteUri.Contains("zclaycreationz"))
                {
                    if (e.Url.AbsoluteUri.Contains("#access_token"))
                    {
                        this.AuthenticationKey = e.Url.AbsoluteUri.Split(new string[] { "#access_token=" }, StringSplitOptions.RemoveEmptyEntries)[1].Split('&')[0];

                        if (this.mode == RegistrationMode.IRC)
                        {
                            this.AuthenticationKey = "oauth:" + this.AuthenticationKey;
                        }
                    }
                    else if (e.Url.AbsoluteUri.Contains("action=authorize") || e.Url.AbsoluteUri.Contains("/oauth2/authorize?"))
                    {
                        if (!this.Visible)
                        {
                            this.webBrowser1.Visible = true;
                            this.CenterToParent();
                            this.Show();
                        }
                    }
                    else
                    {
                        this.IsFinished = true;
                    }
                }
                else if (e.Url.AbsoluteUri.Equals("https://api.twitch.tv/kraken/oauth2/allow"))
                {
                    this.webBrowser1.GoBack();
                }
                else if (e.Url.AbsoluteUri.EndsWith("/login"))
                {
                    this.webBrowser1.Stop();
                }
                else if (!e.Url.AbsoluteUri.Contains("/oauth2/authorize?"))
                {
                    this.webBrowser1.Visible = true;
                    this.CenterToParent();
                    this.Show();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("ERROR:{0}{1}{0}{0}Stack Trace:{0}{2}", Environment.NewLine, ex.Message, ex.StackTrace));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.AuthenticationKey))
            {
                this.Visible = false;
                this.IsFinished = true;
            }
        }

        private void ClientRegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}

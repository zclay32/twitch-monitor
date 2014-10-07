using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitchMonitor.Core.Types;

namespace TwitchMonitor.Core
{
    public class FormattedIrcMessages
    {
        protected static readonly string userToken = "{{user}}";

        public static string GetDisplayMessage(IrcMessageType messageType, string message, string parameter)
        {
            //------------------------------------------------------------------
            //  Return if there's no message to display.
            //------------------------------------------------------------------
            if (string.IsNullOrEmpty(message))
            {
                return string.Empty;
            }

            string displayMessage = message;
            switch (messageType)
            {
                case IrcMessageType.NewSubscriber:
                case IrcMessageType.ReSubscriber:
                    if (displayMessage.Contains(userToken))
                    {
                        displayMessage = displayMessage.Replace(userToken, parameter);
                    }
                    break;

                case IrcMessageType.RunningAd:
                    break;

                case IrcMessageType.NewFollower:
                    if (displayMessage.Contains(userToken))
                    {
                        displayMessage = displayMessage.Replace(userToken, parameter);
                    }
                    break;
            }
            return displayMessage;
        }
    }
}

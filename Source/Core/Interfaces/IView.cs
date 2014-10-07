using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TwitchMonitor.Core.Types;

namespace TwitchMonitor.Core.Interfaces
{
    public interface IView
    {
        void ToggleMonitoring();
        void ShowMainWindow();
        void DisplayStatusMessage(string message);
        void UpdateUserIcon();
        void UpdateSubscriberLists();
        void UpdateFollowersList();
        void UpdateViewerCount();
        void FinishedMonitoring();
        void UpdateServerPings();
        void UpdateProfileInfo();
        void DoEvents();
        void ShowNoAds();
        void ShowAdBreakMessage();
        void ShowAboutToTakeAdBreakMessage();
        void HideAboutToTakeAdBreakMessage();
        void ShowMessage(string message);
        void UpdateAdTimeRemaining(AdTimeRemaining adTimeRemaining);
        void RunAdBreak();
        void ShowUpdateAvailableMessage();
        void SendIrcMessage(string message);
        void SendIrcMessage(IrcMessageType messageType, string parameter);
        Engine Engine { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Interfaces
{
    public interface ILoadingView
    {
        void DisplayMessage(string message);
        void SetProgress(int percent);
    }
}

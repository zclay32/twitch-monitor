using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public enum ThreadMessageStatus
    {
        Informational,
        Error,
        UpdateIcon,
        UpdateProfile,
        UpdateViewers,
        UpdateSubscribers,
        UpdateFollowers,
        SaveFollowersCache,
        UpdateServerPings,
        Debug,
        RunAdBreak
    }

    public class ThreadMessage
    {
        public ThreadMessageStatus Status { get; set; }
        public string Message { get; set; }
    }
}

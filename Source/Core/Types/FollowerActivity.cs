using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public enum FollowerActivityState
    {
        New,
        Unfollowed
    }

    public class FollowerActivity
    {
        public UserJson User { get; set; }
        public FollowerActivityState State { get; set; }
        public bool Processed { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public enum SubscriberActivityState
    {
        New,
        Resubscribed,
        Unsubscribed
    }

    public class SubscriberActivity
    {
        public Subscriber Subscriber { get; set; }
        public SubscriberActivityState State { get; set; }
        public bool Processed { get; set; }
    }
}

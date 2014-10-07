using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public class ChannelLinksJson : LinksJson
    {
        public string chat { get; set; }
        public string commercial { get; set; }
        public string subscriptions { get; set; }
        public string teams { get; set; }
        public string features { get; set; }
        public string editors { get; set; }
        public string videos { get; set; }
        public string follows { get; set; }
        public string stream_key { get; set; }
    }

    public class LinksJson
    {
        public string next { get; set; }
        public string self { get; set; }
        public string channel { get; set; }
    }
}

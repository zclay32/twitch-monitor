using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.IRC.Types
{
    public class TwitchIrcUser
    {
        public string Name { get; set; }
        public string ChatColor { get; set; }
        public bool Op { get; set; }
        public bool Subscriber { get; set; }
        public bool Admin { get; set; }
        public bool Staff { get; set; }
        public bool Turbo { get; set; }
    }
}

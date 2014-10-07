using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public class AdTimeRemaining
    {
        public int Percent { get; set; }
        public TimeSpan TimeRemaining { get; set; }
    }
}

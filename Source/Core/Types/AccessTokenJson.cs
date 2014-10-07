using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public class AccessTokenJson
    {
        public IList<string> scrope { get; set; }
        public string access_token { get; set; }
    }
}

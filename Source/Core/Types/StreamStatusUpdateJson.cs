using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TwitchMonitor.Core.Types
{
    public class StreamChannelJson
    {
        public string status { get; set; }
        public string game { get; set; }
    }

    public class StreamChannelUpdateJson
    {
        public StreamChannelJson channel { get; set; }

        public StreamChannelUpdateJson()
        {
            this.channel = new StreamChannelJson();
        }
    }
}

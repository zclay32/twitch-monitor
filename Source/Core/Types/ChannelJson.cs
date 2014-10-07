using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public class ChannelJson
    {
        public string profile_banner { get; set; }
        public string background { get; set; }
        public string status { get; set; }
        public string display_name { get; set; }
        public string game { get; set; }
        public string banner { get; set; }
        public string _id { get; set; }
        public string url { get; set; }
        public string video_banner { get; set; }
        public long delay { get; set; }
        public string created_at { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public bool? mature { get; set; }
        public string updated_at { get; set; }
        public ChannelLinksJson _links { get; set; }

        public ChannelJson()
        {
            this._links = new ChannelLinksJson();
        }
    }
}

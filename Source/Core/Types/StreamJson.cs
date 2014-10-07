using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public class PreviewJson
    {
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
        public string template { get; set; }
    }

    public class StreamJson
    {
        //public PreviewJson preview { get; set; }
        public object game { get; set; }
        public long viewers { get; set; }
        public string broadcaster { get; set; }
        public string _id { get; set; }
        public LinksJson _links { get; set; }
        public ChannelJson channel { get; set; }

        public StreamJson()
        {
            //this.preview = new PreviewJson();
            this._links = new LinksJson();
            this.channel = new ChannelJson();
        }
    }

    public class StreamJsonPacket
    {
        public StreamJson stream { get; set; }
        public LinksJson _links { get; set; }

        public StreamJsonPacket()
        {
            this.stream = new StreamJson();
            this._links = new LinksJson();
        }
    }
}

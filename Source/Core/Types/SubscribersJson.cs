using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public class SubscriberJson
    {
        public string _id { get; set; }
        public LinksJson _links { get; set; }
        public UserJson user { get; set; }
        public string created_at { get; set; }

        public SubscriberJson()
        {
            this._links = new LinksJson();
            this.user = new UserJson();
        }
    }

    public class SubscribersJsonPacket
    {
        public IList<SubscriberJson> subscriptions { get; set; }
        public long _total { get; set; }
        public LinksJson _links { get; set; }

        public SubscribersJsonPacket()
        {
            this.subscriptions = new List<SubscriberJson>();
            this._links = new LinksJson();
        }
    }
}

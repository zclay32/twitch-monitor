using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public class FollowsJson
    {
        public LinksJson _links{ get; set; }
        public UserJson user { get; set; }
        public string created_at { get; set; }

        public FollowsJson()
        {
            this._links = new LinksJson();
        }
    }

    public class FollowersJsonPacket
    {
        public LinksJson _links { get; set; }
        public IList<FollowsJson> follows { get; set; }
        public long _total { get; set; }

        public FollowersJsonPacket()
        {
            this._links = new LinksJson();
            this.follows = new List<FollowsJson>();
        }
    }
}

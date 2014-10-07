using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitchMonitor.Core.Types
{
    public class UserJson
    {
        public LinksJson _links { get; set; }
        public bool staff { get; set; }
        public string logo { get; set; }
        public string display_name { get; set; }
        public string name { get; set; }
        public string bio { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public long _id { get; set; }

        public UserJson()
        {
            this._links = new LinksJson();
        }
    }
}

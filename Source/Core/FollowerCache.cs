using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TwitchMonitor.Core
{
    [XmlRoot("followerCache")]
    public class FollowerCache
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("followersCount")]
        public long FollowersCount { get; set; }

        [XmlElement("mostRecentFollowerDate")]
        public DateTime MostRecentFollowerDate { get; set; }

        [XmlElement("id")]
        public List<long> Ids;

        /// <summary>
        /// Default constructor that initializes the subscriber list.
        /// </summary>
        public FollowerCache()
        {
            this.Ids = new List<long>();
            this.FollowersCount = 0;
            this.MostRecentFollowerDate = DateTime.MinValue;
        }
    }
}

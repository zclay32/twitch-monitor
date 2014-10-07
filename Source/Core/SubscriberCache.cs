using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TwitchMonitor.Core
{
    public class Subscriber
    {
        [XmlText()]
        public string Name { get; set; }

        [XmlAttribute("id")]
        public long Id { get; set; }

        [XmlAttribute("active")]
        public bool Active { get; set; }

        [XmlAttribute("notes")]
        public string Notes { get; set; }

        #region Deprecated Fields
        [XmlAttribute("minecraftUserName")]
        public string MinecraftUserName { get; set; }

        [XmlIgnore()]
        public bool MinecraftUserNameSpecified { get { return false; } }
        #endregion

        public Subscriber()
        {
            this.Active = true; // Default is active subscription if none is specified.
        }
    }

    [XmlRoot("subscriberCache")]
    public class SubscriberCache
    {
        [XmlElement("subscriber")]
        public List<Subscriber> Subscribers;

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("followersCount")]
        public long FollowersCount { get; set; }

        /// <summary>
        /// Default constructor that initializes the subscriber list.
        /// </summary>
        public SubscriberCache()
        {
            this.Subscribers = new List<Subscriber>();
            this.FollowersCount = 0;
        }
    }
}

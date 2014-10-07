using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TwitchMonitor.Core.Types
{
    public class IngestJson
    {
        [JsonProperty("availability")]  
        public string Availability { get; set; }
        [JsonProperty("default")]
        public bool Default { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url_template")]
        public string UrlTemplate { get; set; }
        [JsonProperty("_id")]
        public int Id { get; set; }
    }

    public class IngestsJsonPacket
    {
        [JsonProperty("_links")]
        public LinksJson Links { get; set; }
        [JsonProperty("ingests")]
        public IList<IngestJson> Ingests { get; set; }

        public IngestsJsonPacket()
        {
            this.Ingests = new List<IngestJson>();
        }
    }
}

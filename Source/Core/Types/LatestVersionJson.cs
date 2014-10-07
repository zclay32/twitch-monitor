using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace TwitchMonitor.Core.Types
{
    public class LatestVersionJson
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("download")]
        public string DownloadUrl { get; set; }
    }
}

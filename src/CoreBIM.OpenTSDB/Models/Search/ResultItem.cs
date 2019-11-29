using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenTSDB.Core.Models.Search
{
    public class ResultItem
    {
        [JsonProperty("tags")]
        public Dictionary<string, string> Tags { get; set; }

        [JsonProperty("metric")]
        public string Metric { get; set; }

        [JsonProperty("tsuid")]
        public string Tsuid { get; set; }
    }


}

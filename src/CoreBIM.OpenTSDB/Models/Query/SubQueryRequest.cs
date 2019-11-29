using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenTSDB.Core.Models.Query
{
    public class SubQueryRequest
    {
        [JsonProperty("aggregator")]
        public string Aggregator { get; set; }

        [JsonProperty("metric")]
        public string Metric { get; set; }

        [JsonProperty("rate")]
        public bool Rate { get; set; }

        [JsonProperty("rateOptions")]
        public Dictionary<string, string> RateOptions { get; set; }

        [JsonProperty("downsample")]
        public string Downsample { get; set; }

        [JsonProperty("tags")]
        public Tags Tags { get; set; }

        [JsonProperty("filters")]
        public IEnumerable<string> Filters { get; set; }

        [JsonProperty("explicitTags")]
        public bool ExplicitTags { get; set; }

        [JsonProperty("percentiles")]
        public IEnumerable<string> Percentiles { get; set; }
    }

}

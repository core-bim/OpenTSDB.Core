using Newtonsoft.Json;

namespace OpenTSDB.Core.Models.Search
{
    public class SearchRequest
    {
        /// <summary>
        /// The string based query to pass to the search engine. 
        /// This will be parsed by the engine or plugin to perform the actual search. 
        /// Allowable values depends on the plugin. Ignored for lookups.
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// Limits the number of results returned per query so as not to override the TSD or search engine. 
        /// Allowable values depends on the plugin. Ignored for lookups.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Used in combination with the limit value to page through results.
        /// Allowable values depends on the plugin. Ignored for lookups.
        /// </summary>
        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }

        /// <summary>
        /// The name of a metric or a wildcard for lookup queries
        /// </summary>
        [JsonProperty("metric")]
        public string Metric { get; set; }

        /// <summary>
        /// One or more key/value objects with tag names and/or tag values for lookup queries. 
        /// </summary>
        /// <example> "tags":[ { "key": "type", "value": "*" }]</example>
        [JsonProperty("tags")]
        public Tags Tags { get; set; }
    }





}

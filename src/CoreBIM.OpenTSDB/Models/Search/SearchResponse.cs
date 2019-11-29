using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenTSDB.Core.Models.Search
{
    public class SearchResponse<T>
    {

        /// <summary>
        /// The type of query submitted, i.e. the endpoint called.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Ignored for lookup queries.
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// The list of tag pairs used for the lookup. May be an empty list.
        /// </summary>
        [JsonProperty("tags")]
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        ///The metric used for the lookup 
        /// </summary>
        [JsonProperty("metric")]
        public string Metric { get; set; }

        /// <summary>
        /// 	The maximum number of items returned in the result set.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// The result set with the TSUID, metric and tags for each series.
        /// </summary>
        [JsonProperty("results")]
        public List<T> Results { get; set; }

        /// <summary>
        /// The amount of time it took, in milliseconds, to complete the query
        /// </summary>
        [JsonProperty("time")] 
        public int Time { get; set; }

        /// <summary>
        /// Ignored for lookup queries, always the default.
        /// </summary>
        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }


        /// <summary>
        /// 	The total number of results matched by the query
        /// </summary>
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }
    }



}

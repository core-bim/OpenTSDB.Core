using Newtonsoft.Json;

namespace OpenTSDB.Core.Models.Search.Lookup
{
    public class SearchLookupRequest
    {
        /// <summary>
        /// Ignored for lookup queries.
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; set; }

        /// <summary>
        /// 	Whether or not to use the meta data table or the raw data table. The raw table will be much slower.
        /// </summary>
        [JsonProperty("useMeta")]
        public bool UseMeta { get; set; } = true;
        /// <summary>
        /// 	The maximum number of items returned in the result set.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Ignored for lookup queries, always the default.
        /// </summary>
        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }

    }

}

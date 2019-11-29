using Newtonsoft.Json;

namespace OpenTSDB.Core.Models.Suggest
{
    /// <summary>
    /// http://opentsdb.net/docs/build/html/api_http/suggest.html
    /// </summary>
    public class SuggestRequest
    {
        /// <summary>
        /// The type of data to auto complete on. Must be one of the following: metrics, tagk or tagv
        /// </summary>
        /// <example>metrics, tagk or tagv</example>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// A string to match on for the given type
        /// </summary>
        /// <example>web</example>
        [JsonProperty("q")]
        public string Q { get; set; }

        /// <summary>
        /// The maximum number of suggested results to return. Must be greater than 0
        /// </summary>
        /// <example>10</example>
        [JsonProperty("max")]
        public int Max { get; set; }
    }
}

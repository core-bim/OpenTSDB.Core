using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenTSDB.Core.Models.Histogram
{
    /// <summary>
    /// Available with OpenTSDB 2.4
    /// This endpoint allows for storing histogram data in OpenTSDB over HTTP as an alternative to the Telnet interface. Histogram write Request can only be performed via content associated with the POST method. Queries over histogram data are performed via the query endpoints.
    /// </summary>
    /// <remarks>If the content you provide with the request cannot be parsed, such JSON content missing a quotation mark or curly brace, then all of the datapoints will be discarded. The API will return an error with details about what went wrong.</remarks>
    public class HistogramRequest : DataPoint<string>
    {
        /// <summary>
        /// 	When writing histograms or sketches other than the default simple bucketed histogram,
        /// 	this value must be set to the ID of the proper histogram codec as defined in the tsd.core.histograms.config configuration setting. 
        /// 	The value must be between 0 and 255. When given, the value must be set.
        /// </summary>
        /// <example>1</example>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// A map of bucket lower and upper bounds (separated by commas) as keys with integer counter bucket values
        /// </summary>
        /// <example>
        /// {"0,1.75":12,"1.75,3.5":16}
        /// </example>
        [JsonProperty("buckets")]
        public Dictionary<string, int> Buckets { get; set; }

        /// <summary>
        /// The count of measurements lower than the lowest bucket lower bound. Default is zero.
        /// </summary>
       /// <example>0</example>
        [JsonProperty("underflow")]
        public int Underflow { get; set; }

        /// <summary>
        ///The count of measurements higher than the highest bucket upper bound. Default is zero.
        /// </summary>
        /// <example>0</example>
        [JsonProperty("overflow")]
        public int Overflow { get; set; }
    }
}

using Newtonsoft.Json;

namespace OpenTSDB.Core.Models.Rollup
{
    /// <summary>
    /// Rollup and pre-aggregate values are extensions of the put object with three additional fields. 
    /// </summary>
    public class RollupRequest<T>: DataPoint<T> 
    {
        /// <summary>
        /// A time interval reflecting what timespan the rollup value represents. 
        /// The interval consists of <amount><unit> similar to a downsampler or relative query timestamp. 
        /// E.g. 6h for 5 hours of data, 30m for 30 minutes of data.
        /// </summary>
        /// <example>1h</example>
        [JsonProperty("interval")]
        public string Interval { get; set; }

        /// <summary>
        /// An aggregation function used to generate the rollup value. Must match a supplied TSDB aggregator.
        /// </summary>
        /// <example>SUM</example>
        [JsonProperty("aggregator")]
        public string Aggregator { get; set; }

        /// <summary>
        /// An aggregation function used to generate the pre-aggregate value. Must match a supplied TSDB aggregator.
        /// </summary>
        /// <example>COUNT</example>
        [JsonProperty("groupByAggregator")]
        public string GroupByAggregator { get; set; }
    }
}

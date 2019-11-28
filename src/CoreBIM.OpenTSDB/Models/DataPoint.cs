using System.Runtime.Serialization;
using System.Text;

namespace OpenTSDB.Core.Models
{

    [DataContract]
    public class DataPoint<T>
    {
        /// <summary>
        /// The name of the metric you are storing
        /// </summary>
        /// <example>sys.cpu.nice</example>
        [DataMember(Name = "metric")]
        public string Metric { get; set; }

        /// <summary>
        /// A Unix epoch style timestamp in seconds or milliseconds. The timestamp must not contain non-numeric characters.
        /// </summary>
        /// <example>1365465600</example>
        [DataMember(Name = "timestamp")]
        public int Timestamp { get; set; }

        /// <summary>
        /// The value to record for this data point. It may be quoted or not quoted and must conform to the OpenTSDB value rules: 
        /// DataType:Integer, Float, String
        /// </summary>
        /// <example>42.5</example>
        [DataMember(Name = "value")]
        public T Value { get; set; }

        /// <summary>
        /// A key/value metadata list.
        /// A map of tag name/tag value pairs. At least one pair must be supplied.
        /// </summary>
        /// <example>{"host":"web01"}</example>
        [DataMember(Name = "tags")]
        public Tags Tags { get; set; } = Tags.Create();
    }
}




using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenTSDB.Core.Models.Uid.Tsmeta
{
    /// <summary>
    /// http://opentsdb.net/docs/build/html/api_http/uid/tsmeta.html
    /// </summary>
    public class TsmetaRequest
    {
        /// <summary>
        /// A hexadecimal representation of the timeseries UID
        /// </summary>
        [JsonProperty("tsuid")]
        public string Tsuid { get; set; }
        /// <summary>
        /// 	Detailed notes about what the UID represents
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// A brief description of what the UID represents
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// A short name that can be displayed in GUIs instead of the default name
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// A key/value map to store custom fields and values
        /// </summary>
        [JsonProperty("custom")]
        public Dictionary<string,string> Custom { get; set; }
        /// <summary>
        /// Units reflective of the data stored in the timeseries, may be used in GUIs or calculations
        /// </summary>
        [JsonProperty("units")]
        public string Units { get; set; }

        /// <summary>
        /// 	The kind of data stored in the timeseries such as counter, gauge, absolute, etc.
        /// 	These may be defined later but they should be similar to Data Source Types in an RRD
        /// </summary>
        [JsonProperty("dataType")]
        public string DataType { get; set; }

        /// <summary>
        /// The number of days of data points to retain for the given timeseries. Not Implemented. 
        /// When set to 0, the default, data is retained indefinitely.
        /// </summary>
        [JsonProperty("retention")]
        public int Retention { get; set; } = 0;

        /// <summary>
        /// An optional maximum value for this timeseries that may be used in calculations such as percent of maximum.
        /// If the default of NaN is present, the value is ignored.
        /// </summary>
        [JsonProperty("max")]
        public float Max { get; set; } = float.NaN;

        /// <summary>
        /// An optional minimum value for this timeseries that may be used in calculations such as percent of minimum. 
        /// If the default of NaN is present, the value is ignored.
        /// </summary>
        [JsonProperty("min")]
        public float Min { get; set; } = float.NaN;
    }
}

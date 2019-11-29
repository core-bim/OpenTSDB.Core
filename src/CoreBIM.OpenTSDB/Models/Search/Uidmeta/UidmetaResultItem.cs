using Newtonsoft.Json;

namespace OpenTSDB.Core.Models.Search.Uidmeta
{
    public class UidmetaResultItem
    {
        /// <summary>
        /// A hexadecimal representation of the timeseries UID
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; set; }
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
        public object Custom { get; set; }
        /// <summary>
        /// Units reflective of the data stored in the timeseries, may be used in GUIs or calculations
        /// </summary>
        [JsonProperty("units")]
        public string Units { get; set; }

        /// <summary>
        /// 	The kind of data stored in the timeseries such as counter, gauge, absolute, etc.
        /// 	These may be defined later but they should be similar to Data Source Types in an RRD
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("created")]
        public int Created { get; set; }

    }

}

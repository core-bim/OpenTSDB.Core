using Newtonsoft.Json;

namespace OpenTSDB.Core.Models.Uid.Uidmeta
{
    public class UidmetaRequest
    {
        /// <summary>
        /// A hexadecimal representation of the UID
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; set; }

        /// <summary>
        /// The type of UID, must be metric, tagk or tagv
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

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
        /// Detailed notes about what the UID represents
        /// </summary>
        [JsonProperty("notes")]
        public string Notes { get; set; }

        /// <summary>
        /// A key/value map to store custom fields and values
        /// </summary>
        [JsonProperty("custom")]
        public string Custom { get; set; }
    }
}

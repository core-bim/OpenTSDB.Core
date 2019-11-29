using Newtonsoft.Json;

namespace OpenTSDB.Core.Models.Version
{
    public class VersionResponse
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("repo")]
        public string Repo { get; set; }

        [JsonProperty("full_revision")]
        public string Full_revision { get; set; }

        [JsonProperty("short_revision")]
        public string Short_revision { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("repo_status")]
        public string Repo_status { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

}

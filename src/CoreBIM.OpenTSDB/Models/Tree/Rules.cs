using Newtonsoft.Json;

namespace OpenTSDB.Core.Models.Tree
{
    public class Rules
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("regex")]
        public string Regex { get; set; }

        [JsonProperty("separator")]
        public string Separator { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("treeId")]
        public int TtreeId { get; set; }

        [JsonProperty("customField")]
        public string CustomField { get; set; }

        [JsonProperty("regexGroupIdx")]
        public int RegexGroupIdx { get; set; }

        [JsonProperty("displayFormat")]
        public string DisplayFormat { get; set; }
    }


}

using Newtonsoft.Json;
using System.Collections.Generic;

namespace OpenTSDB.Core.Models.Search.Annotation
{
    public class AnnotationResultItem
    {
        [JsonProperty("notes")]
        public  string Notes { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tsuid")]
        public string Tsuid { get; set; }

        [JsonProperty("custom")]
        public Dictionary<string,string> Custom { get; set; }
       
        [JsonProperty("endTime")]
        public int endTime { get; set; }
       
        [JsonProperty("startTime")]
        public int startTime { get; set; }
    }


}

using Newtonsoft.Json;

namespace OpenTSDB.Core.Models.Uid.Assign
{
    public class AssignRequest
    {

        [JsonProperty("metric")]
        public string Metric { get; set; }


        [JsonProperty("tagk")]
        public string Tagk { get; set; }

        [JsonProperty("tagv")]
        public string Tagv { get; set; }


    }



}

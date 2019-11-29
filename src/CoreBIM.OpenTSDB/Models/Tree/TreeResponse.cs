using Newtonsoft.Json;

namespace OpenTSDB.Core.Models.Tree
{
    public class TreeResponse
    {
        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("rules")]
        public Rules Rules { get; set; }
    }


}

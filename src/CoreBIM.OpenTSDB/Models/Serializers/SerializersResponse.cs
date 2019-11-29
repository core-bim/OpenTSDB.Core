using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenTSDB.Core.Models.Serializers
{
   public class SerializersResponse
    {
        [JsonProperty("serializer")]
        public string Serializer { get; set; }

        [JsonProperty("formatters")]
        public List<string> Formatters { get; set; }

        [JsonProperty("parsers")]
        public List<string> Parsers { get; set; }
    }
}

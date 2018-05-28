using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MeleeHandler.DataType
{
    public class SmashLoungeGif
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}

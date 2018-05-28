using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MeleeHandler.DataType
{
    public class MeleeTechnique
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("tech")]
        public string TechName { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("smashwiki")]
        public string SmashWikiLink { get; set; }
        [JsonProperty("inputs")]
        public string Inputs { get; set; }
        [JsonProperty("gifs")]
        public List<SmashLoungeGif> Gifs { get; set; }
    }
}

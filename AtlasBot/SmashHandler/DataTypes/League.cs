using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmashHandler.DataTypes
{
    public class League
    {
        [JsonProperty(PropertyName = "name")]
        public string Tier { get; set; }
        [JsonProperty(PropertyName = "division")]
        public string Division { get; set; }
        public StatsSerialized stats_serialized { get; set; }
        public Stats stats { get; set; }
        public int tier_rank { get; set; }
        public int division_number { get; set; }
        public string image_url { get; set; }
        public Season season { get; set; }
    }
}

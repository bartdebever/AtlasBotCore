using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmashHandler.DataTypes
{
    public class Stats
    {
        [JsonProperty(PropertyName = "ranked_played")]
        public int? RankedPlayed { get; set; }
        [JsonProperty(PropertyName = "total_friendlies_played")]
        public int? TotalFriendliesPlayed { get; set; }
        [JsonProperty(PropertyName = "unique_opponents")]
        public int? UniqueOpponents { get; set; }
    }
}

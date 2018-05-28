using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotWrapper.DataTypes
{
    public class MatchReferenceDto
    {
        [JsonProperty("lane")]
        public string Lane { get; set; }
        [JsonProperty("gameId")]
        public long GameId { get; set; }

        public long championId = 0;
        [JsonProperty("champion")]
        public long ChampionId
        {
            get => championId;
            set => championId = Convert.ToInt64(value);
        }
        [JsonProperty("platformId")]
        public string PlatformId { get; set; }
        [JsonProperty("season")]
        public int Season { get; set; }
        [JsonProperty("queue")]
        public int Queue { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }
}

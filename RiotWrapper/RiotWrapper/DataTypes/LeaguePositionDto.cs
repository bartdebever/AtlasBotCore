using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotWrapper.DataTypes
{
    public class LeaguePositionDto
    {
        [JsonProperty("queueType")]
        public string QueueType { get; set; }
        [JsonProperty("rank")]
        public string Rank { get; set; }
        [JsonProperty("hotStreak")]
        public bool OnHotStreak { get; set; }
        [JsonProperty("miniSeries")]
        public MiniSeriesDto MiniSeries { get; set; }
        [JsonProperty("wins")]
        public int Wins { get; set; }
        [JsonProperty("veteran")]
        public bool Veteran { get; set; }
        [JsonProperty("losses")]
        public int Losses { get; set; }
        [JsonProperty("freshBlood")]
        public bool IsFreshBlood { get; set; }
        [JsonProperty("leagueId")]
        public string LeaugeId { get; set; }
        [JsonProperty("playerOrTeamName")]
        public string PlayerOrTeamName { get; set; }
        [JsonProperty("inactive")]
        public bool IsInactive { get; set; }
        [JsonProperty("playerOrTeamId")]
        public string PlayerOrTeamId { get; set; }
        [JsonProperty("tier")]
        public string Tier { get; set; }
        [JsonProperty("leaguePoints")]
        public int LeaguePoints { get; set; }
    }
}

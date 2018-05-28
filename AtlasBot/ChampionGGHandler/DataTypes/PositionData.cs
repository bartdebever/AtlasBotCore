using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChampionGGHandler.DataTypes
{
    /// <summary>
    /// In which position of the lane this champion belongs on that stat
    /// </summary>
    public class PositionData
    {
        [JsonProperty("deaths")]
        public int Deaths { get; set; }
        [JsonProperty("winRates")]
        public int WinRates { get; set; }
        [JsonProperty("minionsKilled")]
        public int MinionsKilled { get; set; }
        [JsonProperty("banRates")]
        public int BanRates { get; set; }
        [JsonProperty("assists")]
        public int Assists { get; set; }
        [JsonProperty("kills")]
        public int Kills { get; set; }
        [JsonProperty("playRates")]
        public int PlayRates { get; set; }
        [JsonProperty("goldEarned")]
        public int GoldEarned { get; set; }
        [JsonProperty("overallPerformanceScore")]
        public int PerformanceScore { get; set; }

    }
}

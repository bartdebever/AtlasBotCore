using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChampionGGHandler.DataTypes
{
    public class ChampionData
    {
        [JsonProperty("elo")]
        public string Elo { get; set; }
        [JsonProperty("patch")]
        public string Patch { get; set; }
        [JsonProperty("championId")]
        public int ChampionId { get; set; }
        [JsonProperty("positions")]
        public PositionData PositionData { get; set; }
        [JsonProperty("winRate")]
        public double WinRate { get; set; }
        [JsonProperty("kills")]
        public double AverageKills { get; set; }
        [JsonProperty("assists")]
        public double AverageAssists { get; set; }
        [JsonProperty("deaths")]
        public double AverageDeaths { get; set; }
        [JsonProperty("gamesPlayed")]
        public int TotalGamesPlayed { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
        [JsonProperty("neutralMinionsKilledTeamJungle")]
        public double MonstersKilledTeamJungle { get; set; }
        [JsonProperty("neutralMinionsKilledEnemyJungle")]
        public double MonstersKilledEnemyJungle { get; set; }
        [JsonProperty("averageGames")]
        public double AverageGames { get; set; }
        [JsonProperty("PlayRate")]
        public double PlayRate { get; set; }
        [JsonProperty("minionsKilled")]
        public double MinionsKilled { get; set; }
        [JsonProperty("totalHeal")]
        public double Healed { get; set; }
        [JsonProperty("percentRolePlayed")]
        public double PercentageRolePlayed { get; set; }
    }
}

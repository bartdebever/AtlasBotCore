using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotWrapper.DataTypes
{
    public class CurrentGameParticipant
    {
        [JsonProperty("profileIconId")]
        public long ProfileIconId { get; set; }
        [JsonProperty("championId")]
        public long ChampionId { get; set; }
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
        [JsonProperty("gameCustomizationObjects")]
        public List<GameCustomizationObject> GameCustomizationObjects { get; set; }
        [JsonProperty("bot")]
        public bool IsBot { get; set; }
        /// <summary>
        /// New Rune System
        /// </summary>
        [JsonProperty("perks")]
        public Perks Perks { get; set; }
        [JsonProperty("spell2Id")]
        public long SummonerSpell2Id { get; set; }
        [JsonProperty("teamId")]
        public long TeamId { get; set; }
        [JsonProperty("spell1Id")]
        public long SummonerSpell1Id { get; set; }
        [JsonProperty("summonerId")]
        public long SummonerId { get; set; }
    }
}

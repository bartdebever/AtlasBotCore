using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotWrapper.DataTypes
{
    public class ChampionMasteryDto
    {
        /// <summary>
        /// Is chest granted for this champion or not in current season.
        /// </summary>
        [JsonProperty("chestGranted")]
        public bool ChestGranted { get; set; }
        /// <summary>
        /// Champion level for specified player and champion combination.
        /// </summary>
        [JsonProperty("championLevel")]
        public int Level { get; set; }
        /// <summary>
        /// Champion ID for this entry.
        /// </summary>
        [JsonProperty("championId")]
        public long ChampionId { get; set; }
        /// <summary>
        /// Total number of champion points for this player and champion combination - they are used to determine championLevel.
        /// </summary>
        [JsonProperty("championPoints")]
        public long ChampionPoints { get; set; }
        /// <summary>
        /// Last time this champion was played by this player - in Unix milliseconds time format.
        /// </summary>
        [JsonProperty("lastPlayTime")]
        public long LastPlayTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotWrapper.DataTypes
{
    public class CurrentGameInfo
    {
        [JsonProperty("gameId")]
        public long GameId { get; set; }
        /// <summary>
        /// The game start time represented in epoch milliseconds
        /// </summary>
        [JsonProperty("gameStartTime")]
        public long gameStartTime { get; set; } //TODO Convert to DateTime
        [JsonProperty("platformId")]
        public string PlatformId { get; set; } //TODO Convert to Platform enum
        [JsonProperty("gameMode")]
        public string GameMode { get; set; } //TODO Convert to Object
        [JsonProperty("mapId")]
        public long MapId { get; set; } //TODO Convert to Map
        [JsonProperty("gameType")]
        public string GameType { get; set; }
        [JsonProperty("bannedChampions")]
        public List<BannedChampion> BannedChampions { get; set; }
        [JsonProperty("observers")]
        public Observer Observers { get; set; }
        [JsonProperty("participants")]
        public List<CurrentGameParticipant> Participants { get; set; }
        /// <summary>
        /// The amount of time in seconds that has passed since the game started
        /// </summary>
        [JsonProperty("gameLength")]
        public long GameLength { get; set; } //TODO Convert to TimeSpan
        /// <summary>
        /// The queue type (queue types are documented on the Game Constants page)
        /// </summary>
        [JsonProperty("gameQueueConfigId")]
        public long GameQueueConfigId { get; set; }
    }
}

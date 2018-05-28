using Newtonsoft.Json;

namespace RiotWrapper.DataTypes
{
    public class SummonerDto
    {
        /// <summary>
        /// ID of the summoner icon associated with the summoner.
        /// </summary>
        [JsonProperty("profileIconId")]
        public int ProfileIconId { get; set; }
        /// <summary>
        /// Summoner name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Summoner level associated with the summoner.
        /// </summary>
        [JsonProperty("summonerLevel")]
        public long SummonerLevel { get; set; }
        /// <summary>
        /// Date summoner was last modified specified as epoch milliseconds. The following events will update this timestamp:
        /// profile icon change, playing the tutorial or advanced tutorial, finishing a game, summoner name change
        /// </summary>
        [JsonProperty("revisionDate")]
        public long RevisionDate { get; set; }
        /// <summary>
        /// Summoner ID.
        /// Use this ID for requests!
        /// </summary>
        [JsonProperty("id")]
        public long SummonerId { get; set; }
        /// <summary>
        /// Account ID.
        /// Used to transfer summoner across regions, don't use for further requests.
        /// </summary>
        [JsonProperty("accountId")]
        public long AccountId { get; set; }
    }
}

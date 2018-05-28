using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotWrapper.DataTypes
{
    public class LeagueListDto
    {
        [JsonProperty("leagueId")]
        public string LeagueId { get; set; }
        [JsonProperty("tier")]
        public string Tier { get; set; }
        [JsonProperty("entries")]
        public List<LeagueItemDto> Entries { get; set; }
        [JsonProperty("queue")]
        public string Queue { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

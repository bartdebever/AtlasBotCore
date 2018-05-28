using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotWrapper.DataTypes
{
    public class MatchListDto
    {
        [JsonProperty("matches")]
        public List<MatchReferenceDto> Matches { get; set; }
        [JsonProperty("totalGames")]
        public int TotalGames { get; set; }
        [JsonProperty("startIndex")]
        public int StartIndex { get; set; }
        [JsonProperty("endIndex")]
        public int EndIndex { get; set; }
    }
}

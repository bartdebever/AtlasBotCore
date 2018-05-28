
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotWrapper.DataTypes
{
    public class MiniSeriesDto
    {
        [JsonProperty("wins")]
        public int Wins { get; set; }
        [JsonProperty("losses")]
        public int Losses { get; set; }
        [JsonProperty("target")]
        public int Target { get; set; }
        [JsonProperty("progress")]
        public string Progress { get; set; }
    }
}

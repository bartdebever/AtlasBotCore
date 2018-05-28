using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RiotWrapper.DataTypes
{
    public class Perks
    {
        [JsonProperty("perkStyle")]
        public long PerkStyle { get; set; }
        [JsonProperty("perkIds")]
        public List<long> PerkIds { get; set; }
        [JsonProperty("perkSubStyle")]
        public long SecondaryPerkStyle { get; set; }

    }
}

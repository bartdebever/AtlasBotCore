using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KugorganeHammerHandler.Data_Types
{
    public class Movement
    {
        public List<MovementAttribute> Attributes { get; private set; }

        public Movement(List<MovementAttribute> atts)
        {
            this.Attributes = atts;
        }
    }

    public class MovementAttribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("ownerId")]
        public int OwnerId { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}

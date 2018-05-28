using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmashHandler.DataTypes
{
    public class Location
    {
        [JsonProperty(PropertyName = "coordinates")]
        public List<double> Coordinates { get; set; }
        [JsonProperty(PropertyName = "country")]
        public Country Country { get; set; }
        [JsonProperty(PropertyName = "state.name")]
        public string State { get; set; }
        [JsonProperty(PropertyName = "locality.name")]
        public string Locality { get; set; }
        [JsonProperty(PropertyName = "country_state")]
        public string CountryState { get; set; }
    }
}

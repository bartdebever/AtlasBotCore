using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmashHandler.DataTypes
{
    public class GameSmall
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
    public class Games
    {
        [JsonProperty(PropertyName = "1")]
        public GameSmall ProjectM { get; set; }
        [JsonProperty(PropertyName = "2")]
        public GameSmall Melee { get; set; }
        [JsonProperty(PropertyName = "3")]
        public GameSmall Sm4sh3ds { get; set; }
        [JsonProperty(PropertyName = "4")]
        public GameSmall Sm4shWiiU { get; set; }
        [JsonProperty(PropertyName = "5")]
        public GameSmall Smash64 { get; set; }
        [JsonProperty(PropertyName = "6")]
        public GameSmall Brawl { get; set; }
        [JsonProperty(PropertyName = "7")]
        public GameSmall SuperSmashFlash { get; set; }
        [JsonProperty(PropertyName = "8")]
        public GameSmall RPS { get; set; }
        [JsonProperty(PropertyName = "9")]
        public GameSmall MeleeLight { get; set; }
        public List<GameSmall> AllGames => new List<GameSmall>()
        {
            ProjectM, Melee, Sm4sh3ds, Sm4shWiiU, Smash64, Brawl, RPS, SuperSmashFlash, MeleeLight
        };
    }
    public class GamesRoot
    {
        public Games games { get; set; }
    }
}

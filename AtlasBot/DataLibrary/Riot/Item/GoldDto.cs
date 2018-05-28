using Newtonsoft.Json;

namespace DataLibrary.Riot.Item
{
    public class GoldDto
    {
        public int Id { get; set; }
        public int sell { get; set; }
        public int total { get; set; }
        [JsonProperty("base")]
        public int Base { get; set; }
        public bool purchasable { get; set; }
    }
}

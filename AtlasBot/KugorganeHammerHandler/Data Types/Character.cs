using Newtonsoft.Json;

namespace KugorganeHammerHandler.Data_Types
{
    public class Character
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("style")]
        public string Style { get; set; }
        [JsonProperty("mainImageUrl")]
        public string MainImageURL { get; set; }
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailURL { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("fullUrl")]
        public string FullURL { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DataLibrary.Riot.Item
{
    public class ItemDto
    {
        public int Id { get; set; }
        public GoldDto gold { get; set; }
        public string plaintext { get; set; }
        public bool inStore { get; set; }
        [JsonProperty("id")]
        public int ItemId { get; set; }
        public string description { get; set; }
        public string requiredChampion { get; set; }
        public string group { get; set; }
        public string name { get; set; }
        public bool consumed { get; set; }
        public int stacks { get; set; }
    }

    public class RootItem
    {
        public Dictionary<string, ItemDto> data { get; set; }
        public string version { get; set; }
    }
}

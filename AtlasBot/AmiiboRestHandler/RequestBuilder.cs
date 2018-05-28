using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace AmiiboRestHandler
{
    public static class RequestBuilder
    {
        public static string GetJson(string name)
        {
            Uri baseuri = new Uri("http://www.amiiboapi.com");
            var client = new RestClient(baseuri);
            var endpoint = "api/amiibo";
            var request = new RestRequest(endpoint + "?name=" + name, Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

    }

    public static class RequestHandler
    {
        public static AmiiboRoot GetAmiibo(string name)
        {
            string response = RequestBuilder.GetJson(name);
            AmiiboRoot amiibo = JsonConvert.DeserializeObject<AmiiboRoot>(response);
            return amiibo;
        }
    }
    public class Amiibo
    {
        [JsonProperty("amiiboSeries")]
        public string Series { get; set; }
        [JsonProperty("character")]
        public string Character { get; set; }
        [JsonProperty("gameSeries")]
        public string GameSeries { get; set; }
        [JsonProperty("image")]
        public string ImageURL { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("release")]
        public Release Releases { get; set; }
    }
    public class Release
    {
        public string au { get; set; }
        public string eu { get; set; }
        public string jp { get; set; }
        public string na { get; set; }
    }

    public class AmiiboRoot
    {
        public List<Amiibo> amiibo { get; set; }
    }
}

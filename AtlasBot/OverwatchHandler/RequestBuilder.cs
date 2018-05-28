using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverwatchHandler.DataTypes;
using RestSharp;

namespace OverwatchHandler
{
    public static class RequestBuilder
    {
        private static Uri _baseUri => new Uri("https://overwatch-api.net/api/v1");
        private static string _heroEndpoint => "hero";

        public static string GetHeroById(int id)
        {
            var client = new RestClient(_baseUri);
            var request = new RestRequest($"{_heroEndpoint}/{id}", Method.GET);
            return client.Execute(request).Content;
        }

        public static string GetPlayerByName(string region, string name)
        {
            var client = new RestClient(new Uri("http://ow-api.com/v1/stats/pc"));
            var request = new RestRequest($"{region}/{name.Replace("#", "-")}/complete", Method.GET);
            return client.Execute(request).Content;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RiotWrapper.DataTypes;

namespace RiotWrapper
{
    public static class RestRequestBuilder
    {
        public static RestRequest GetBaseRequest(string request, string apiKey)
        {
            var result = new RestRequest(request);
            result = result.AddHeader("X-Riot-Token", apiKey) as RestRequest;
            return result;
        }

        public static RestClient GetBaseClient(Platforms platform)
        {
            return new RestClient($"https://{platform.ToString().ToLower()}.api.riotgames.com");
        }
    }
}

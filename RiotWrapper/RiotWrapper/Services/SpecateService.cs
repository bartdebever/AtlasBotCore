using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RiotWrapper.DataTypes;

namespace RiotWrapper.Services
{
    public class SpecateService : Service
    {
        private string _endPoint = "lol/spectator/v3/";
        private string _activeGame = "active-games/by-summoner/";
        public SpecateService(string apiKey) : base(apiKey)
        {
        }

        public CurrentGameInfo GameBySummoner(Platforms platform, long summonerId)
        {
            var restClient = RestRequestBuilder.GetBaseClient(platform);
            var restRequest = RestRequestBuilder.GetBaseRequest(_endPoint + _activeGame + summonerId, ApiKey);
            restRequest.Method = Method.GET;
            var result = restClient.Execute(restRequest);
            var json = result.Content;
            return JsonConvert.DeserializeObject<CurrentGameInfo>(json);
        }
    }
}

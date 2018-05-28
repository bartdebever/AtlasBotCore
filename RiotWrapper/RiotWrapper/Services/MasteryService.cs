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
    public class MasteryService
    {
        private string _apiKey;
        private string _endPoint = "lol/champion-mastery/v3/";
        private string _bySummoner = "champion-masteries/by-summoner/";

        public MasteryService(string apiKey)
        {
            this._apiKey = apiKey;
        }

        public List<ChampionMasteryDto> GetchampionMasteries(Platforms platform, long summonerId)
        {
            var restClient = RestRequestBuilder.GetBaseClient(platform);
            var restRequest = RestRequestBuilder.GetBaseRequest($"{_endPoint}{_bySummoner}{summonerId}", _apiKey);
            restRequest.Method = Method.GET;
            var response = restClient.Execute(restRequest);
            var json = response.Content;
            return JsonConvert.DeserializeObject<List<ChampionMasteryDto>>(json);
        }
    }
}

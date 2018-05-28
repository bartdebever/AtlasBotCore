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
    public class LeagueService
    {
        private string _apikey;
        private string _endpoint = "lol/league/v3/";
        private string _leaguePositions = "positions/by-summoner/";
        public LeagueService(string apiKey)
        {
            this._apikey = apiKey;
        }

        public List<LeaguePositionDto> GetPositionDto(Platforms platform, long summonerId)
        {
            var restClient = RestRequestBuilder.GetBaseClient(platform);
            var restRequest = RestRequestBuilder.GetBaseRequest($"{_endpoint}{_leaguePositions}{summonerId}", _apikey);
            restRequest.Method = Method.GET;
            var response = restClient.Execute(restRequest);
            var json = response.Content;
            return JsonConvert.DeserializeObject<List<LeaguePositionDto>>(json);
        }
    }
}

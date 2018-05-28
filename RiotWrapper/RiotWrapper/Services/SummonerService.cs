using Newtonsoft.Json;
using RestSharp;
using RiotWrapper.DataTypes;

namespace RiotWrapper.Services
{
    public class SummonerService
    {
        private string _apiKey;
        private string _endpoint = "lol/summoner/v3/summoners/";
        private string _byName = "by-name/";
        public SummonerService(string apiKey)
        {
            this._apiKey = apiKey;
        }
        public SummonerDto GetSummonerByName(string summonerName, Platforms platform)
        {
            var restClient = RestRequestBuilder.GetBaseClient(platform);
            var restRequest = RestRequestBuilder.GetBaseRequest(_endpoint + _byName + summonerName, _apiKey);
            restRequest.Method = Method.GET;
            var result = restClient.Execute(restRequest);
            var json = result.Content;
            return JsonConvert.DeserializeObject<SummonerDto>(json);
        }
    }
}

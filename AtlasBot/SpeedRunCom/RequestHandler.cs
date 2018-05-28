using System;
using System.Collections.Generic;
using DataLibrary.Static_Data;
using Newtonsoft.Json;
using RestSharp;
using SpeedRunCom.Models;

namespace SpeedRunCom
{
    public class RequestHandler
    {
        public RootObject LookupGame(string game)
        {
            var client = new RestClient(new Uri("http://speedrun.com"));
            var request = new RestRequest($"api/v1/games?name={game}&embed=categories,moderators,platforms",Method.GET);
            request.AddHeader("X-API-Key", OptionManager.SpeedrunCom);

            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootObject>(response.Content);
        }
        public RootLeaderboard GetLeaderboard(string game, string category)
        {
            var client = new RestClient(new Uri("http://speedrun.com"));
            var request = new RestRequest($"api/v1/leaderboards/{game}/category/{category}?embed=players,category,game,game.platforms,game.moderators,game.categories&top=10", Method.GET);
            request.AddHeader("X-API-Key", OptionManager.SpeedrunCom);

            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootLeaderboard>(response.Content);
        }
        public RootLeaderboard GetWorldRecord(string game, string category)
        {
            var client = new RestClient(new Uri("http://speedrun.com"));
            var request = new RestRequest($"api/v1/leaderboards/{game}/category/{category}?embed=players,category,game,game.platforms,game.moderators,game.categories&top=1", Method.GET);
            request.AddHeader("X-API-Key", OptionManager.SpeedrunCom);

            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootLeaderboard>(response.Content);
        }

        public UserRoot GetUser(string name)
        {
            var client = new RestClient(new Uri("http://speedrun.com"));
            var request = new RestRequest($"api/v1/users/{name}", Method.GET);
            request.AddHeader("X-API-Key", OptionManager.SpeedrunCom);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<UserRoot>(response.Content);
        }

        public List<UserRunList> GetWorldRecordsPerUser(string id)
        {
            var client = new RestClient(new Uri("http://speedrun.com"));
            var request = new RestRequest($"api/v1/users/{id}/personal-bests?top=1&embed=level,category,game,game.platforms", Method.GET);
            request.AddHeader("X-API-Key", OptionManager.SpeedrunCom);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootRunList>(response.Content.Replace("\"level\":{\"data\":[]}", "\"level\":{\"data\":null}")).data;
        }

        public List<UserRunList> GetLatestRunsPerUser(string id)
        {
            var client = new RestClient(new Uri("http://speedrun.com"));
            var request = new RestRequest($"api/v1/users/{id}/personal-bests?embed=level,category,game,game.platforms", Method.GET);
            request.AddHeader("X-API-Key", OptionManager.SpeedrunCom);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootRunList>(response.Content.Replace("\"level\":{\"data\":[]}", "\"level\":{\"data\":null}")).data;
        }
        public List<UserRunList> GetRunsPerUserPerGame(string id, string game)
        {
            var client = new RestClient(new Uri("http://speedrun.com"));
            var request = new RestRequest($"api/v1/users/{id}/personal-bests?game={game}&embed=level,category,game,game.platforms", Method.GET);
            request.AddHeader("X-API-Key", OptionManager.SpeedrunCom);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<RootRunList>(response.Content.Replace("\"level\":{\"data\":[]}", "\"level\":{\"data\":null}")).data;
        }
    }
}

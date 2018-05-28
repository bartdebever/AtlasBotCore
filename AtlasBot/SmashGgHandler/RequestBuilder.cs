using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace SmashGgHandler
{
    public static class RequestBuilder
    {
        public static string GetTournamentInfoJson(string tournament)
        {
            var client = new RestClient(Adresses.BaseUri);
            var request = new RestRequest($"{Adresses.TournamentEndpoint}{tournament}?{Adresses.Event}&expand[]=groups&expand[]=phase", Method.GET);
            return client.Execute(request).Content;
        }

        public static string GetTournamentResultJson(int groupId)
        {
            var client = new RestClient(Adresses.BaseUri);
            var request = new RestRequest($"phase_group/{groupId}?expand[]=entrants&expand[]=seeds", Method.GET);
            return client.Execute(request).Content;
        }

        public static string GetTournamentResultSetsJson(int groupId)
        {
            var client = new RestClient(Adresses.BaseUri);
            var request = new RestRequest($"phase_group/{groupId}?expand[]=entrants&expand[]=seeds&expand[]=sets", Method.GET);
            return client.Execute(request).Content;
        }

        public static string GetRecentDutchTournaments()
        {
            var client = new RestClient(Adresses.BaseUri);
            var request = new RestRequest("public/tournaments/schedule?per_page=30&filter={\"upcoming\"%3Afalse%2C\"videogameIds\"%3A1%2C\"countryCode\"%3A\"NL\"}&page=1", Method.GET);
            return client.Execute(request).Content;
        }
    }
}

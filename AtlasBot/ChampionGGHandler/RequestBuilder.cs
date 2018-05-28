using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace ChampionGGHandler
{
    public static class RequestBuilder
    {
        static readonly string token = "54b4521cb95ee64fb2986521919ac420";
        public static string GetChampionStats(int id)
        { 
            var client = new RestClient(Adresses.BaseUri);
            var request = new RestRequest(Adresses.ChampionEndpoint + $"{id}?elo=PLATINUM&champData=kda,damage,averageGames,totalHeal,killingSpree,minions,gold,positions,normalized,groupedWins,trinkets,runes,firstitems,summoners,skills,finalitems,masteries&limit=200&api_key={token}");
            return client.Execute(request).Content;
        }

        public static string GetPerformance()
        {
            var client= new RestClient(Adresses.BaseUri);
            var request = new RestRequest($"overall?elo=PLATINUM&api_key={token}");
            return client.Execute(request).Content;
        }
    }
}

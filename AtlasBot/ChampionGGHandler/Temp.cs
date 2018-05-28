using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using DataLibrary;
using DataLibrary.Riot.Item;
using DataLibrary.Static_Data;
using Microsoft.EntityFrameworkCore;

namespace ChampionGGHandler
{
    public static class Temp
    {
        public static string GetChampionName(int id)
        {
            return new RiotData().Champions.FirstOrDefault(x => x.ChampionId == id).name;
        }

        public static void GetChammpions()
        {
            var client = new RestClient(new Uri("https://euw1.api.riotgames.com"));
            var request =
                new RestRequest(
                    $"lol/static-data/v3/champions?locale=en_US&tags=all&dataById=false&api_key={OptionManager.RiotKey}");
            var response = client.Execute(request);
            var json = response.Content;
            var champions = JsonConvert.DeserializeObject<RootChampion>(json).data;
            var database = new RiotData();
            database.Database.Migrate();
            foreach (var champ in champions.AllChampions)
            {
                database.Champions.Add(champ);
            }
            database.SaveChanges();
        }

        public static void GetItems()
        {
            var client = new RestClient(new Uri("https://euw1.api.riotgames.com"));
            var request = new RestRequest($"lol/static-data/v3/items?locale=en_US&tags=consumeOnFull&tags=consumed&tags=depth&tags=effect&tags=gold&tags=image&tags=inStore&tags=requiredChampion&tags=stacks&api_key={OptionManager.RiotKey}");
            var response = client.Execute(request);
            var json = response.Content;
            var items = JsonConvert.DeserializeObject<RootItem>(json).data;
            var database = new RiotData();
            foreach (var item in items)
            {
                database.Items.Add(item.Value);
            }
            database.SaveChanges();
        }

    }
}

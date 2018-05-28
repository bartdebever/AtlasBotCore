using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OverwatchHandler.DataTypes;

namespace OverwatchHandler
{
    public static class RequestHandler
    {
        private static List<string> Heros => new List<string>()
        {
            "ana",
            "bastion",
            "d.va",
            "genji",
            "hanzo",
            "junkrat",
            "lucio",
            "mccree",
            "mei",
            "mercy",
            "pharah",
            "reaper",
            "reinhardt",
            "roadhog",
            "soldier: 76",
            "symmetra",
            "torbjörn",
            "tracer",
            "widowmaker",
            "winston",
            "zarya",
            "zenyatta",
            "orisa"
        };

        public static OverwatchHero GetHeroByName(string name)
        {
            var heroId = Heros.IndexOf(name.ToLower()) +1;
            var hero = RequestBuilder.GetHeroById(heroId);
            return JsonConvert.DeserializeObject<OverwatchHero>(hero);
        }

        public static RootObject GetProfileByName(string region, string name)
        {
            var profile = RequestBuilder.GetPlayerByName(region, name);
            return JsonConvert.DeserializeObject<RootObject>(profile);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmashHandler.Constant_data;
using SmashHandler.DataTypes;

namespace SmashHandler
{
    public static class RequestHandler
    {
        public static RootObject GetUserByName(string username)
        {
            username = username.Replace(" ", "-");
            HttpWebRequest request = RequestBuilder.GetRequest(Adresses.BaseUri+Endpoints.MatchmakingEndpoint+"?username="+username);
            string result = null;
            try
            {
                using (var reader = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch
            {
                
            }
            RootObject root = JsonConvert.DeserializeObject<RootObject>(result);
            return root;
        }

        public static List<string> GetRanksByName(string username)
        {
            username = username.Replace(" ", "-");
            HttpWebRequest request =
                RequestBuilder.GetRequest(Adresses.BaseUri + Endpoints.MatchmakingEndpoint + "?username=" + username);
            string result = null;
            try
            {
                using (var reader = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch
            {

            }
            RootObject root = JsonConvert.DeserializeObject<RootObject>(result);
            var ranks = new List<string>();
            foreach (var game in root.user.ladder_information.AllGames.Where(x=>x != null).ToList())
            {
                if (!string.IsNullOrEmpty(game.league.Tier))
                {
                    ranks.Add(game.name + " " + game.league.Tier + " " + game.league.division_number);
                }
            }
            return ranks;
        }

        public static List<GameSmall> GetGames()
        {
            HttpWebRequest request =
                RequestBuilder.GetRequest(Adresses.BaseUri + Adresses.Apibase + Endpoints.GamesEndpoint);
            string result = null;
            try
            {
                using (var reader = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch
            {

            }
            Games games = JsonConvert.DeserializeObject<GamesRoot>(result).games;
            return games.AllGames;
        }

        public static List<CharacterDetailed> GetCharacters()
        {
            HttpWebRequest request =
                RequestBuilder.GetRequest(Adresses.BaseUri + Adresses.Apibase + Endpoints.CharactersEndpoint);
            string result = null;
            try
            {
                using (var reader = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch
            {
                
            }
            List<CharacterDetailed> characters = JsonConvert.DeserializeObject<RootCharacters>(result).AllCharacters;
            return characters;
        }
    }
}

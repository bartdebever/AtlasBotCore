using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KugorganeHammerHandler.Data_Types;
using Newtonsoft.Json;
using RestSharp;

namespace KugorganeHammerHandler
{
    public static class RequestHandler
    {
        public static Character GetCharacterName(string name)
        {
            string json = RequestBuilder.GetChampion(name);
            return JsonConvert.DeserializeObject<Character>(json);
        }

        public static Movement GetMovement(string name)
        {
            string json = RequestBuilder.GetMovement(name);
            var movements = JsonConvert.DeserializeObject<List<MovementAttribute>>(json);
            return new Movement(movements);
        }

        public static List<Move> GetMoves(string name)
        {
            return JsonConvert.DeserializeObject<List<Move>>(RequestBuilder.GetMoves(name));
        }
    }

    public static class RequestBuilder
    {
        private static Uri BaseUri => new Uri("http://beta-api-kuroganehammer.azurewebsites.net");
        private static string CharacterEndpoint => "api/characters/";
        private static string Movement => "movements/";
        private static string MovementEndpoint => "api/movements/";

        public static string GetChampion(string name)
        {
            var client = new RestClient(BaseUri);
            var request = new RestRequest(CharacterEndpoint + "name/" + name, Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public static string GetMovement(string name)
        {
            var client = new RestClient(BaseUri);
            var request = new RestRequest(CharacterEndpoint + "name/"+name+"/"+ Movement);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public static string GetMoves(string name)
        {
            var client = new RestClient(BaseUri);
            var request = new RestRequest(CharacterEndpoint + "name/" + name + "/moves", Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }
    }
}

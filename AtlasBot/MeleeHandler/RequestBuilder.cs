using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace MeleeHandler
{
    public static class RequestBuilder
    {
        public static string GetCharacter()
        {
            var client = new RestClient(new Uri("http://smashlounge.com/api"));
            string characterendpoint = $"chars/all";
            var request = new RestRequest(characterendpoint, Method.GET);
            var json = client.Execute(request);
            return json.Content;
        }

        public static string GetTechniques()
        {
            var client = new RestClient(new Uri("http://smashlounge.com/api"));
            string characterendpoint = $"techs/all";
            var request = new RestRequest(characterendpoint, Method.GET);
            var json = client.Execute(request);
            return json.Content;
        }
    }
}

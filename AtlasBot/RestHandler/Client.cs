using System;
using Newtonsoft.Json;
using RestSharp;

namespace RestHandler
{
    public class Client : IJsonClient
    {
        private string _uri;
        private RestClient _client;

        public Client(string uri)
        {
            this._uri = uri;
            _client = new RestClient(uri);
        }

        public object Send(string endpoint, Method method, Type type)
        {
            if (string.IsNullOrEmpty(endpoint))
                return null;
            var request = new RestRequest(endpoint, method);
            var response = _client.Execute(request);
            return Deserialize(response.Content, type);
        }

        private static object Deserialize(string json, Type type)
        {
            try
            {
                return JsonConvert.DeserializeObject(json, type);
            }
            catch
            {
                //JSON did not deserialize properly. Log error
            }
            return null;
        }
    }
}


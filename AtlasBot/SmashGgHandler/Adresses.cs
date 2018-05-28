using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashGgHandler
{
    public static class Adresses
    {
        private static Uri _baseUri = new Uri("http://api.smash.gg");
        private static string _tournamentEndpoint = "tournament/";
        private static string _event = "expand[]=event";

        public static Uri BaseUri
        {
            get { return _baseUri; }
        }

        public static string TournamentEndpoint
        {
            get { return _tournamentEndpoint; }
        }

        public static string Event
        {
            get { return _event; }
        }
    }
}
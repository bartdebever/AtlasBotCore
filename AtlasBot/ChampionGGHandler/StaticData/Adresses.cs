using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionGGHandler
{
    public static class Adresses
    {
        public static Uri BaseUri => new Uri("http://api.champion.gg/v2");
        public static string ChampionEndpoint => "champions/";
    }
}

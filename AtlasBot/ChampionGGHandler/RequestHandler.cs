using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChampionGGHandler.DataTypes;
using Newtonsoft.Json;

namespace ChampionGGHandler
{
    public static class RequestHandler
    {
        public static ChampionData[] GetChampionDataById(int id)
        {
            var json = RequestBuilder.GetChampionStats(id);
            return JsonConvert.DeserializeObject<ChampionData[]>(json);
        }

        public static ChampionPerformance GetOverallPerformance()
        {
            var json = RequestBuilder.GetPerformance();
            return JsonConvert.DeserializeObject<ChampionPerformance[]>(json)[0];
        }
    }
}

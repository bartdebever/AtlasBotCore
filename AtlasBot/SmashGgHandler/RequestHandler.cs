using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmashGgHandler
{
    public static class RequestHandler
    {
        public static TournamentRoot GetTournamentRoot(string name)
        {
            var json = RequestBuilder.GetTournamentInfoJson(name.Replace(" ", "-"));
            return JsonConvert.DeserializeObject<TournamentRoot>(json);
        }

        public static ResultRoot GetResult(int groupId)
        {
            var json = RequestBuilder.GetTournamentResultJson(groupId);
            return JsonConvert.DeserializeObject<ResultRoot>(json);
        }
        public static ResultRoot GetResultSets(int groupId)
        {
            var json = RequestBuilder.GetTournamentResultSetsJson(groupId);
            return JsonConvert.DeserializeObject<ResultRoot>(json);
        }

        public static TournamentScheduleRoot GetDutchTournaments()
        {
            return JsonConvert.DeserializeObject<TournamentScheduleRoot>(RequestBuilder.GetRecentDutchTournaments());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SmashGgHandler
{
    public class TournamentScheduleRoot
    {
       public TournamentScheduleItems items { get; set; }
    }

    public class TournamentScheduleItems
    {
        public TournamentEntities entities { get; set; }
    }
    public class TournamentEntities
    {
        public List<ScheduleTournament> tournament { get; set; }
    }

    public class ScheduleTournament
    {
        public int id { get; set; }
        public int? seriesId { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string shortSlug { get; set; }
    }
}

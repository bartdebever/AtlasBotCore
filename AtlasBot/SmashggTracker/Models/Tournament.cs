using System.Collections.Generic;

namespace SmashggTracker.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public int SmashggId { get; set; }
        public string Name { get; set; }
        public List<GameEvent> Events { get; set; }
        public List<Match> Matches { get; set; }

        public Tournament()
        {
            Events = new List<GameEvent>();
            Matches = new List<Match>();
        }
    }
}

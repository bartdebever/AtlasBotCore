using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmashGgHandler
{
    public class Tournament
    {
        public int id { get; set; }
        public int? seriesId { get; set; }
        public int? ownerId { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string timezone { get; set; }
        [JsonProperty("private")]
        public bool Private{ get; set;}
        public long startAt { get; set; }
        public long endAt { get; set; }
        public string venueName { get; set; }
        public string venueAddress { get; set; }
        public string region { get; set; }
        public string details { get; set; }
        public string registrationMarkdown { get; set; }
        public string prizes { get; set; }
        public string rules { get; set; }
        public string contactEmail { get; set; }
        public string currency { get; set; }
        public List<TournamentImage> images { get; set; }


    }

    public class TournamentImage
    {
        public int? id { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Event
    {
        public int id { get; set; }
        public int tournamentId { get; set; }
        public int videogameId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
        public int? entrantSizeMin { get; set; }
        public int? entrantSizeMax { get; set; }
        public long startAt { get; set; }
        public long endAt { get; set; }

    }

    public class VideoGame
    {
        public int id { get; set; }
        public string abbrev { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public bool approved { get; set; }
        public List<TournamentImage> images { get; set; }
    }
    public class TournamentRoot
    {
        public Entities entities { get; set; }
    }

    public class Entities
    {
        public Tournament tournament { get; set; }
        [JsonProperty("event")]
        public List<Event> Event{ get; set; }
        public List<VideoGame> videogame { get; set; }
        public List<Phase> phase { get; set; }
        public List<Group> groups { get; set; }
    }
    public class TiebreakOrder
    {
        public string type { get; set; }
        public List<object> inputs { get; set; }
    }

    public class Group
    {
        public int id { get; set; }
        public int phaseId { get; set; }
        public object startAt { get; set; }
        public object startedAt { get; set; }
    }

    public class Phase
    {
        public int id { get; set; }
        public int eventId { get; set; }
        public bool isDefault { get; set; }
        public int groupCount { get; set; }
    }
}
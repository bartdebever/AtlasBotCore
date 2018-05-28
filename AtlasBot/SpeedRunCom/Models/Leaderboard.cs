using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRunCom.Models
{
    public class Leaderboard
    {
        public string weblink { get; set; }
        public RunGame game { get; set; }
        public RunCategory category { get; set; }
        public string timing { get; set; }
        public List<RunList> runs { get; set; }
        public RootPlayers players { get; set; }
    }

    public class RootLeaderboard
    {
        public Leaderboard data { get; set; }
    }

    public class RunGame
    {
        public Game data { get; set; }
    }

    public class RunCategory
    {
        public Catagory data { get; set; }
    }
    public class RunList
    {
        public int place { get; set; }
        public Run run { get; set; }
    }

    public class RootRunList
    {
        public List<UserRunList> data { get; set; }
    }
    public class UserRunList
    {
        public int place { get; set; }
        public Run run { get; set; }
        public RunGame game { get; set; }
        public RunCategory category { get; set; }
        public LevelRoot level { get;set; }
    }

    public class LevelRoot
    {
        public Level data { get; set; }
    }

    public class Level
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    public class Run
    {
        public string id { get; set; }
        public string weblink { get; set; }
        public Video videos { get; set; }
        public string comment { get; set; }
        public RunStatus status { get; set; }
        public List<RunPlayer> players { get; set; }
        public Times times { get; set; }
    }

    public class Links
    {
        public string uri { get; set; }
    }
    public class Video
    {
        public List<Links> links { get; set; }
       
    }

    public class RunStatus
    {
        public string status { get; set; }
    }

    public class RunPlayer
    {
        public string rel { get; set; }
        public string id { get; set; }
        public string uri { get; set; }
    }

    public class Times
    {
        public string primary { get; set; }
        public string realtime { get; set; }
    }

    public class RootPlayers
    {
        public List<Player> data { get; set; }
    }
    public class Player
    {
        public string id { get; set; }
        public Dictionary<string,string> names { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public Dictionary<string, string> names { get; set; }
        public string weblink { get; set; }
        public Links twitch { get; set; }
        public Links hitbox { get; set; }
        public Links twitter { get; set; }
        public Links youtube { get; set; }
        public Links speedrunslive { get; set; }
        public LocationRoot location { get; set; }
        public List<RefLinks> links { get; set; }
    }

    public class RefLinks
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }
    public class UserRoot
    {
        public User data { get; set; }
    }
    public class LocationRoot
    {
        public Location country { get; set; }
        public Location region { get; set; }
    }

    public class Location
    {
        public string code { get; set; }
        public Dictionary<string,string> names { get; set; }
    }
}

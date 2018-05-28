using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmashHandler.DataTypes
{
    public class Country
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class StatsSerialized
    {
        public double rating { get; set; }
        public int bonus_pool_used { get; set; }
        public int? id { get; set; }
    }
    public class StartDate
    {
        public int timestamp { get; set; }
        public string courtesy { get; set; }
        public string full { get; set; }
    }

    public class EndDate
    {
        public int timestamp { get; set; }
        public string courtesy { get; set; }
        public string full { get; set; }
    }

    public class Season
    {
        public int id { get; set; }
        public string name { get; set; }
        public StartDate start_date { get; set; }
        public EndDate end_date { get; set; }
        public int games_required_for_ladder { get; set; }
        public int opponents_required_for_ladder { get; set; }
    }

    public class Build
    {
        public string download_file { get; set; }
        public string detail_url { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string icon_directory { get; set; }
        public string download_link { get; set; }
        public int? @default { get; set; }
        public object active { get; set; }
        public int is_currently_used { get; set; }
        public int dolphin_build_id { get; set; }
        public int order { get; set; }
        public int ladder_id { get; set; }
    }

    public class Game
    {
        public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public string image_url { get; set; }
        public League league { get; set; }
        public List<Character> characters { get; set; }
    }

    public class StatsSerialized2
    {
        public int rating { get; set; }
        public int bonus_pool_used { get; set; }
        public object id { get; set; }
    }

    public class Stats2
    {
        public int ranked_played { get; set; }
        public object total_friendlies_played { get; set; }
        public int unique_opponents { get; set; }
    }
    public class Character
    {
        public string name { get; set; }
        public int percent { get; set; }
    }
    public class LadderInformation
    {
        private List<Game> _games = null;
        [JsonProperty(PropertyName = "1")]
        public Game ProjectM { get; set; }
        [JsonProperty(PropertyName = "2")]
        public Game Melee { get; set; }
        [JsonProperty(PropertyName = "3")]
        public Game Smash3DS { get; set; }
        [JsonProperty(PropertyName = "4")]
        public Game Smash4Wiiu { get; set; }
        [JsonProperty(PropertyName = "5")]
        public Game Smash64 { get; set; }
        [JsonProperty(PropertyName = "6")]
        public Game Brawl { get; set; }
        [JsonProperty(PropertyName = "7")]
        public Game SFF2 { get; set; }
        [JsonProperty(PropertyName = "8")]
        public Game RPS { get; set; }

        public List<Game> AllGames
        {
            get
            {
                _games = new List<Game>();
                try { _games.Add(ProjectM); } catch { }
                try { _games.Add(Melee); } catch { }
                try { _games.Add(Smash3DS); } catch { }
                try { _games.Add(Smash4Wiiu); } catch { }
                try { _games.Add(Smash64); } catch { }
                try { _games.Add(Brawl); } catch { }
                try { _games.Add(SFF2); } catch { }
                try { _games.Add(RPS); } catch { }
                return _games;
            }
        }

    }

    public class MemberSince
    {
        public int timestamp { get; set; }
        public string courtesy { get; set; }
        public DateTime full { get; set; }
    }

    public class User
    {
        public object display_name { get; set; }
        public object max_tier_achievement { get; set; }
        public Location location { get; set; }
        public object is_subscribed { get; set; }
        public int id { get; set; }
        public string username { get; set; }
        public Flair selected_flair { get; set; }
        public object glow_color { get; set; }
        public bool is_admin { get; set; }
        public bool is_mod { get; set; }
        public string away_message { get; set; }
        public bool is_playing { get; set; }
        public bool is_online { get; set; }
        public string profile_url { get; set; }
        public LadderInformation ladder_information { get; set; }
        public int total_matches_played { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public List<object> notes { get; set; }
        public int is_friend { get; set; }
        public bool has_dolphin_launcher { get; set; }
        public int subscription_streak { get; set; }
        public MemberSince member_since { get; set; }
        public Lobby now_playing { get; set; }
    }

    public class Flair
    {
        public string url { get; set; }
        public string safe_url { get; set; }
        public override string ToString()
        {
            return url;
        }
    }

    public class RootObject
    {
        public bool success { get; set; }
        public User user { get; set; }
        public Lobby now_playing { get; set; }
    }
    public class Player
    {
        public int id { get; set; }
        public string username { get; set; }
        public LadderInformation ladder_information { get; set; }
    }

    public class Lobby
    {
        public bool is_ranked { get; set; }
        public int game_type { get; set; }
        public int ladder_id { get; set; }
        public string ladder_name { get; set; }
        public string ladder_slug { get; set; }
        public string game_slug { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public PreferredBuild preferred_build { get; set; }
        public Ladder ladder { get; set; }
    }
    public class PreferredBuild
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Ladder
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}

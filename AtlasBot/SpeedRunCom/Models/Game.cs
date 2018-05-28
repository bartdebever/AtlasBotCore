using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRunCom.Models
{
    public class Game
    {
        public string id { get; set; }
        public int released { get; set; }
        public string abbreviation { get; set; }
        public string weblink { get; set; }
        public Dictionary<string, string> names { get; set; }
        public Dictionary<string, object> ruleset { get; set; }
        public Dictionary<string, ImageFormat> assets { get; set; }
        public RootCat categories { get; set; }
        public RootModerator moderators { get; set; }
        public RootPlatform platforms { get; set; }
    }

    public class RootObject
    {
        public List<Game> data { get; set; }
    }

    public class RootCat
    {
        public List<Catagory> data { get; set; }
    }

    public class RootPlatform
    {
        public List<Platform> data { get; set; }
    }

    public class RootModerator
    {
        public List<Moderator> data { get; set; }
    }

    public class Platform
    {
        public string id { get; set; }
        public string name { get; set; }
        public int released { get; set; }
    }
    public class Moderator
    {
        public string id { get; set; }
        public Dictionary<string, string> names { get; set; }
        public string weblink { get; set; }

    }

    public class ImageFormat
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Catagory
    {
        public string id { get; set; }
        public string name { get; set; }
        public string weblink { get; set; }
        public string type { get; set; }
        public string rules { get; set; }
    }
}

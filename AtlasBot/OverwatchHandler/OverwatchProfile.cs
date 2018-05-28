using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchHandler
{
    public class OverwatchProfile
    {
        public string icon { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public int prestige { get; set; }
        public string rating { get; set; }
        public string ratingIcon { get; set; }
        public string ratingName { get; set; }
        public int gamesWon { get; set; }
        public OverwatchStats quickPlayStats { get; set; }
        public OverwatchStats competitiveStats { get; set; }
    }

    public class OverwatchStats
    {
        public OverwatchGameStats games { get; set; }
    }

    public class OverwatchGameStats
    {
        public int played { get; set; }
        public int won { get; set; }
    }
}

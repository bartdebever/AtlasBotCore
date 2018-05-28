using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionGGHandler.DataTypes
{
    public class PerformanceRoot
    {
        public List<ChampionPerformance> performances { get; set; }
    }
    public class ChampionPerformance
    {
        public string elo { get; set; }
        public string patch { get; set; }
        public Positions positions { get; set; }
        public DateTime lastUpdate { get; set; }
    }

    public class Positions
    {
        public PositionStat MIDDLE { get; set; }
        public PositionStat TOP { get; set; }
        public PositionStat DUO_SUPPORT { get; set; }
        public PositionStat JUNGLE { get; set; }
        public PositionStat DUO_CARRY { get; set; }
    }

    public class PositionStat
    {
        public Stats performanceDelta { get; set; }
        public Stats winrate { get; set; }
        public Stats performanceScore { get; set; }
    }

    public class Stats
    {
        public Stat worst { get; set; }
        public Stat best { get; set; }
    }
    public class Stat
    {
        public double score { get; set; }
        public int championId { get; set; }
    }
}

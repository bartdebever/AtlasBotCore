using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashHandler.DataTypes
{
    public static class Ranks
    {
        private static List<string> _base = null;
        private static List<string> _full = null;

        public static List<string> Tiers
        {
            get
            {
                if (_base == null)
                {
                    _base = new List<string>()
                    {
                        "Bronze",
                        "Silver",
                        "Gold",
                        "Platinum",
                        "Master",
                        "Grand Smasher"
                    };
                }
                return _base;
            }
        }

        public static List<string> AllRanks
        {
            get
            {
                if (_full == null)
                {
                    _full = new List<string>();
                    foreach (var rank in Tiers)
                    {
                        _full.Add(rank + " I");
                        _full.Add(rank + " II");
                        _full.Add(rank+" III");
                    }
                }
                return _full;
            }
        }
    }
}

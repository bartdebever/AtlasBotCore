using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiotWrapper.DataTypes;

namespace RiotWrapper.Helpers
{
    public static class PlatformHelper
    {
        public static Platforms StringToPlatform(string region)
        {
            region = region.ToLower();
            if (region == "eune")
            {
                return Platforms.EUN1;
            }
            else if (region == "las")
            {
                return Platforms.LA2;
            }
            else if (region == "lan")
            {
                return Platforms.LA1;
            }
            else if (region == "oce")
            {
                return Platforms.OC1;
            }
            region = region + "1";
            return (Platforms) Enum.Parse(typeof(Platforms), region.ToUpper());
        }
    }
}

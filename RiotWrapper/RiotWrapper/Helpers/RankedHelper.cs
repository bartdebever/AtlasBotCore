using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotWrapper.Helpers
{
    public static class RankedHelper
    {
        public static string NormalizedQueue(string queue)
        {
            switch (queue)
            {
                case "RANKED_SOLO_5x5":
                    return "Ranked Solo/Duo";
                case "RANKED_FLEX_SR":
                    return "Ranked Flex";
                case "RANKED_FLEX_TT":
                    return "Ranked 3v3 Flex";
            }
            return null;
        }
    }
}

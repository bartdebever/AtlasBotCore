using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmashggTrackerWeb
{
    public class StageConverter
    {
        private static List<string> stages = new List<string>()
        {
            "Mushroom Kingdom",
            "Princess Peach's Castle",
            "Rainbow Cruise",
            "Yoshi's Island",
            "Yoshi's Story",
            "Kongo Jungle",
            "Jungle Japes",
            "Great Bay",
            "Temple",
            "Brinstar",
            "Fountain of Dreams",
            "Green Greens",
            "Corneria",
            "Venom",
            "Pokemon Stadium",
            "Mute City",
            "Onett",
            "Icicle Mountain",
            "Battlefield",
            "Final Destination",
            "Mushroom Kingdom II",
            "Yoshi's Island 64",
            "Kongo Jungle 64",
            "Brinstar Depths",
            "Dream Land",
            "Pokefloats",
            "Big Blue",
            "Fourside",
            "Flat Zone"
        };

        public static string GetStageById(int id)
        {
            if(id <= stages.Count && id > 0)
                return stages[id-1];
            return null;
        }
    }
}

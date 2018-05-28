using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmashggTrackerWeb
{
    public static class CharacterConverter
    {
        private static List<string> characters = new List<string>()
        {
            "Bowser",
            "Captain Falcon",
            "Donkey Kong",
            "Dr. Mario",
            "Falco",
            "Fox",
            "Ganondorf",
            "Ice Climbers",
            "Jigglypuff",
            "Kirby",
            "Link",
            "Luigi",
            "Mario",
            "Marth",
            "Mewtwo",
            "Mr. Game And Watch",
            "Ness",
            "Peach",
            "Pichu",
            "Pikachu",
            "Roy",
            "Samus",
            "Sheik",
            "Yoshi",
            "Young Link",
            "Zelda"
        };

        public static string GetChracterById(int id)
        {
            if (id < 0 || id > characters.Count)
                return null;
            return characters[id];
        }
    }
}

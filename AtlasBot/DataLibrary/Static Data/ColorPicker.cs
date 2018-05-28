using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace DataLibrary.Static_Data
{
    /// <summary>
    /// A class used to pick colors per module and response.
    /// </summary>
    public static class ColorPicker
    {
        //Module Colors
        public static Color UserModule => Color.Blue;
        public static Color ServerModule => Color.DarkGreen;
        public static Color LeagueModule => Color.DarkBlue;
        public static Color CoachModule => Color.Orange;

        public static Color SmashModule => Color.Gold;
        //Responses
        public static Color FailedResponse => Color.DarkRed;
        public static Color SuccesResponse => Color.Green;
        
    }
}

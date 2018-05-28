using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace DataLibrary.Static_Data
{
    public static class DiscordManager
    {
        public static CommandService Commands { get; set; }
        public static DiscordSocketClient Client { get; set; }
    }
}

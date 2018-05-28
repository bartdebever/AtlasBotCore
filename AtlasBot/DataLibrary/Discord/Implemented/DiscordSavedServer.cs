using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Discord.Implemented
{
    public class DiscordSavedServer
    {
        public int Id { get; set; }
        public long ServerId { get; set; }
        public Options Options { get; set; }
        public long BotCommanderRole { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AtlasBot.Modules;

namespace DataLibrary
{
    public class Options
    {
        public int Id { get; set; }
        public List<DiscordModule> ModulesEnabled { get; set; }
        public List<RoleEmote> RoleEmotes { get; set; }
        public long RoleEmoteMessageId { get; set; }
        public long BotChannel { get; set; }
        public long BotCommander { get; set; }
    }
}

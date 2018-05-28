using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasBot.Modules
{
    public class RoleEmote
    {
        public int Id { get; set; }
        public long Emote { get; set; }
        public long DiscordRole { get; set; }
        public RoleEmote() { }
        public RoleEmote(long emote, long role)
        {
            this.Emote = emote;
            this.DiscordRole = role;
        }
    }
}

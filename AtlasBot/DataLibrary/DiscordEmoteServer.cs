using System;
using System.Collections.Generic;
using System.Text;
using AtlasBot.Modules;

namespace DataLibrary
{
    public class DiscordEmoteServer
    {
        public int Id { get; set; }
        public long ServerId { get; set; }
        public List<RoleEmote> RoleEmotes { get; set; }
        public long EmoteMessage { get; set; }
        public DiscordEmoteServer() { }

        public DiscordEmoteServer(long id, long message)
        {
            this.EmoteMessage = message;
            this.ServerId = id;
            this.RoleEmotes = new List<RoleEmote>();
        }
    }
}

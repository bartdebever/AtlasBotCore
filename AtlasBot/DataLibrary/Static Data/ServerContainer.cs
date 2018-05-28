using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLibrary.Discord.Implemented;
using Discord;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary.Static_Data
{
    public static class ServerContainer
    {
        private static List<DiscordSavedServer> savedServers = new List<DiscordSavedServer>();

        public static DiscordSavedServer GetServerById(long id)
        {
            var server = savedServers.FirstOrDefault(x => x.Id == id);
            if (server == null)
            {
                var db = new DatabaseContext();
                server = db.Servers.Include(x => x.Options).ThenInclude(x => x.RoleEmotes).FirstOrDefault(x => x.ServerId == id);
                savedServers.Add(server);
            }
            return server;
        }

        public static void DeleteCache()
        {
            savedServers = new List<DiscordSavedServer>();
        }

    }
}

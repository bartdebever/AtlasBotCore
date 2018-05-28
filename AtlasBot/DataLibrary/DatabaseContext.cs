using System.Collections.Generic;
using AtlasBot.Modules;
using DataLibrary.Discord.Implemented;
using DataLibrary.Static_Data;
using DataLibrary.Useraccounts.Implementation;
using Microsoft.EntityFrameworkCore;

namespace DataLibrary
{
    public class DatabaseContext : DbContext
    { 
        public DbSet<DiscordSavedServer> Servers { get; set; }
        public DbSet<RoleEmote> RoleEmotes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(OptionManager.GeneralDatabase);
        }
    }

}

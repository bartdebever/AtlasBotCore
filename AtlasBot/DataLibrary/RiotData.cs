using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Riot.Item;
using DataLibrary.Static_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLibrary
{
    public class RiotData : DbContext
    {
        public DbSet<Champion> Champions { get; set; }
        public DbSet<ItemDto> Items { get; set; }
        public DbSet<ChampionSpellDto> Spells { get; set; }
        public DbSet<PassiveDto> Passives { get; set; }
        public DbSet<StatsDto> Stats { get; set; }
        public DbSet<SkinDto> Skins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(OptionManager.RiotDatabase);
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Static_Data;
using Microsoft.EntityFrameworkCore;
using SmashggTracker.Models;

namespace SmashggTracker.DAL
{
    public class SmashggTrackerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(OptionManager.SmashggTrackerContext);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}

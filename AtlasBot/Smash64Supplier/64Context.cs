using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.Static_Data;
using Microsoft.EntityFrameworkCore;

namespace Smash64Supplier
{
    public class _64Context : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(OptionManager.GeneralDatabase);

        }
    }
}

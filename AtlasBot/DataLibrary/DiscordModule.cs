using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary
{
    public class DiscordModule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public DiscordModule() { }

        public DiscordModule(string name)
        {
            this.Name = name;
            this.Enabled = false;
        }
    }
}

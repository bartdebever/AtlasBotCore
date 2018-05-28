using System;
using System.Collections.Generic;
using System.Text;
using Discord;

namespace AtlasBot.EmbedBuilder
{
    public class CachedEmbed
    {
        public string CommandArgs { get; set; }
        public Embed Embed { get; set; }
        public DateTime DeletedBy { get; set; }
        public CachedEmbed() { }

        public CachedEmbed(string commandArgs, Embed embed, TimeSpan time)
        {
            this.CommandArgs = commandArgs;
            this.Embed = embed;
            this.DeletedBy = DateTime.Now.Add(time);
        }
    }
}

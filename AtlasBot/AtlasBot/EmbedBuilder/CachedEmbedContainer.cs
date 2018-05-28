using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;

namespace AtlasBot.EmbedBuilder
{
    public static class CachedEmbedContainer
    {
        private static List<CachedEmbed> embeds;

        public static Embed GetEmbedByArgs(string commandArgs)
        {
            var result = embeds?.FirstOrDefault(x => x.CommandArgs == commandArgs);
            return result?.Embed;
        }

        public static void AddEmbed(Embed embed, string commandArgs, TimeSpan time)
        {
            if(embeds == null)
                embeds = new List<CachedEmbed>();
            embeds.Add(new CachedEmbed(commandArgs, embed, time));
        }
    }
}

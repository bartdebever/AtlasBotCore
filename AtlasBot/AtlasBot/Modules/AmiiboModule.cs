using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmiiboRestHandler;
using AtlasBot.EmbedBuilder;
using AtlasBot.Preconditions;
using Discord;
using Discord.Commands;

namespace AtlasBot.Modules
{
    [Group("amiibo")]
    public class AmiiboModule:ModuleBase
    {
        [Command("search")]
        [Summary("Search for all available Amiibo by character name.")]
        public async Task Search([Remainder] string name)
        {
            var root = RequestHandler.GetAmiibo(name);
            foreach (var amiibo in root.amiibo)
            {
                Discord.EmbedBuilder builder = Builders.BaseBuilder("", "", Color.DarkMagenta,
                    new EmbedAuthorBuilder().WithName("AmiiboAPI's Results").WithUrl("http://www.amiiboapi.com"), null);
                builder.AddInlineField("General Information",
                    "**Name: **" + amiibo.Name + "\n"+
                    "**Amiibo Series: **" + amiibo.Series +"\n"+
                    "**Game Series: **" + amiibo.GameSeries);
                builder.AddInlineField("Releases",
                    "**NA:** " + Convert.ToDateTime(amiibo.Releases.na).ToLongDateString() + "\n" +
                    "**EU: **" + Convert.ToDateTime(amiibo.Releases.eu).ToLongDateString() + "\n" +
                    "**JP: **" + Convert.ToDateTime(amiibo.Releases.jp).ToLongDateString() + "\n" +
                    "**AU: **" + Convert.ToDateTime(amiibo.Releases.au).ToLongDateString());
                try
                {
                    builder.WithImageUrl(amiibo.ImageURL);
                }
                catch { }
                await ReplyAsync("", embed: builder.Build());
            }
            
           
        }
    }
}

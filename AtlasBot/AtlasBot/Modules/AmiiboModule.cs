﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmiiboRestHandler;
using AtlasBot.Attributes;
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
        [Example("-s Amiibo Search Mario")]
        [Creator("Bort")]
        [Update("30 May 2018")]
        [DataProvider("http://www.amiiboapi.com")]
        public async Task Search([Remainder] string name)
        {
            AmiiboRoot root;
            try
            {
                root = RequestHandler.GetAmiibo(name);
            }
            catch
            {
                root = null;
            }
            if (root != null)
            {
                foreach (var amiibo in root.amiibo)
                {
                    Discord.EmbedBuilder builder = Builders.BaseBuilder("", "", Color.DarkMagenta,
                        new EmbedAuthorBuilder().WithName("AmiiboAPI's Results").WithUrl("http://www.amiiboapi.com"),
                        null);
                    builder.AddInlineField("General Information",
                        $"**Name:** {amiibo.Name}\n" +
                        $"**Amiibo Series:** {amiibo.Series}\n" +
                        $"**Game Series:** {amiibo.GameSeries}");
                    builder.AddInlineField("Releases",
                        $"**NA:** {Convert.ToDateTime(amiibo.Releases.na).ToLongDateString()}\n" +
                        $"**EU: **{Convert.ToDateTime(amiibo.Releases.eu).ToLongDateString()}\n" +
                        $"**JP: **{Convert.ToDateTime(amiibo.Releases.jp).ToLongDateString()}\n" +
                        $"**AU: **{Convert.ToDateTime(amiibo.Releases.au).ToLongDateString()}");
                    if (!string.IsNullOrEmpty(amiibo.ImageURL))
                        try
                        {
                            builder.WithImageUrl(amiibo.ImageURL);
                        }
                        catch
                        {
                        }
                    await ReplyAsync("", embed: builder.Build());
                }
            }
            else
            {
                var builder = Builders.BaseBuilder("Not found", "", Color.Red, null, null);
                builder.AddField("Amiibo not found.",
                    "AtlasBot was unable to find an Amiibo with that name, check your spelling.\n" +
                    "If you think this is a bug please report it at https://github.com/bartdebever/AtlasBotCore");
                await ReplyAsync("", embed: builder.Build());
            }
                

            
           
        }
    }
}

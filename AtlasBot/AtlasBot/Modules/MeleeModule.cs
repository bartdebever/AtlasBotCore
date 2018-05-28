using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlasBot.Attributes;
using Discord;
using Discord.Commands;
using DiscordBot.EmbedBuilder;
using MeleeHandler;

namespace AtlasBot.Modules
{
    [Group("Melee")]
    public class MeleeModule : ModuleBase
    {
        [Creator("Bort")]
        [Example("-s Melee Character Fox")]
        [Command("character")]
        [Summary("View details of a Super Smash Bros Melee character by name.")]
        [DataProvider("SmashLounge")]
        public async Task GetCharacter([Remainder] string name)
        {
            var character = MeleeHandler.RequestHandler.GetCharacter(name);
            if (character == null)
            {
                await ReplyAsync("", embed: Builders.ErrorBuilder("Character not found"));
            }
            else
            {
                var builder = Builders.BaseBuilder("", "", Color.Teal,
                    new EmbedAuthorBuilder().WithName(character.name).WithIconUrl($"http://smashlounge.com/img/pixel/{character.name.Replace(" ", "")}HeadSSBM.png"), "");
                builder.AddField("Description", character.guide);
                builder.AddField("Stats", $"**Tier: **{character.tierdata}\n" +
                                          $"**Weight: **{character.weight}\n" +
                                          $"**Fallspeed: **{character.fallspeed}\n" +
                                          $"**Can Walljump: **{Convert.ToBoolean(Int32.Parse(character.walljump))}");
                if (character.gifs != null)
                {
                    foreach (var smashLoungeGif in character.gifs)
                    {
                        builder.AddInlineField(smashLoungeGif.Description,
                            $"**Link: **https://gfycat.com/{smashLoungeGif.Url}\n" +
                            $"**Source: **{smashLoungeGif.Source}\n");
                    }
                }
                await ReplyAsync("", embed: builder.Build());
                    
            }

        }

        [Command("tech")]
        [Summary("Get details about a tech by name of the tech")]
        [Example("-melee tech waveshine")]
        public async Task GetTech([Remainder] string name)
        {
            var tech = MeleeHandler.RequestHandler.GetTechnique(name);
            if (tech == null)
            {
                await ReplyAsync("", embed: Builders.ErrorBuilder("Tech not found").Build());
            }
            else
            {
                var builder = Builders.BaseBuilder("", "", Color.Teal,
                    new EmbedAuthorBuilder().WithName(tech.TechName),
                    "");
                builder.AddField("Information",
                    $"**Description: **{tech.Description}\n" +
                    $"**Inputs: **{tech.Inputs}\n" +
                    $"**SmashWiki Link: **{tech.SmashWikiLink}");
                if (tech.Gifs != null)
                {
                    builder.WithImageUrl($"https://zippy.gfycat.com/{tech.Gifs[0].Url}.gif");
                    foreach (var gif in tech.Gifs)
                    {
                        string source = "";
                        if (!string.IsNullOrEmpty(gif.Source)) source = $"**Source: **{gif.Source}";
                        builder.AddInlineField(gif.Description,
                            $"**Link: **https://gfycat.com/{gif.Url} \n" + source
                        );
                    }
                }
                await ReplyAsync("", embed: builder.Build());
            }
        }

        [Command("Tierlist")]
        [Summary("Get an image of the latest Super Smash Bros Melee tierlist.")]
        public async Task GetTierlist()
        {
            var builder = Builders.BaseBuilder("Tierlist", "", Color.Blue, null, "");
            builder.WithImageUrl("https://i.imgur.com/veixUjI.png");
            builder.AddField("Information",
                "The SSBM Tierlist as of 25 December 2017.\nRemember that Tierlists are objective, always play who you love instead of the best character.");
            await ReplyAsync("", embed: builder.Build());
        }

        [Command("guide")]
        [Summary("Get a guide from the 2018 Melee Techs and Tricks Guides made by Third Chair")]
        public async Task GetGuide([Remainder] string name)
        {
            var client = new MeleeClient();
            var link = client.ContentWrapper.MediaContent.Get2018GuideByCharacterName(name);
            if (link != null)
            {
                var builder = Builders.BaseBuilder("", "", Color.DarkRed,
                    new EmbedAuthorBuilder().WithName("2018 Melee Guides by Third Chair")
                        .WithUrl("https://www.youtube.com/playlist?list=PLQRQYzKDzrDrv0I9N68Y-9efH2Jo3Vt-r"), null);
                builder.AddField("Links",
                    $"Link for {name}: {link}\n" +
                    $"General playlist: https://www.youtube.com/playlist?list=PLQRQYzKDzrDrv0I9N68Y-9efH2Jo3Vt-r");
                builder.AddField("Information",
                    "All of this content is owned and made by Third Chair. Atlas does not have any relationship with Third Chair.");
                await ReplyAsync("", embed: builder.Build());
            }
        }
    }
}

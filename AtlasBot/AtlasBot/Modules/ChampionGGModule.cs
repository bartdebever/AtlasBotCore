using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChampionGGHandler;
using DataLibrary;
using Discord;
using Discord.Commands;
using DiscordBot.EmbedBuilder;

namespace DiscordBot.Modules
{
    [Group("Championgg")]
    class ChampionGGModule : ModuleBase
    {
        [Command("Search")]
        [Summary("Search for Championgg statistics by champion name")]
        public async Task Stats([Remainder] string name)
        {
            var champion = new RiotData().Champions.FirstOrDefault(x => x.name.ToLower() == name.ToLower());
            var stats = RequestHandler.GetChampionDataById(champion.ChampionId);
            var builder = ChampionGGBuilder.GetChampionInfo(stats[0]);
            builder.ThumbnailUrl = $"http://ddragon.leagueoflegends.com/cdn/6.24.1/img/champion/{champion.key}.png";
            await ReplyAsync("", embed: builder.Build());
        }

        [Command("Performance")]
        [Summary("Show the top performing champions for each lane on the current patch.")]
        public async Task Performance()
        {
            var stats = RequestHandler.GetOverallPerformance();
            var builder = Builders.BaseBuilder("Performance per lane", $"On patch *{stats.patch}* and elo *{stats.elo}*", Color.LightOrange,
                new EmbedAuthorBuilder().WithName("Statistics by Champion.gg").WithUrl("http://champion.gg"), "");
            builder.AddField(ChampionGGBuilder.GetFieldByLane("Top", stats.positions.TOP));
            builder.AddField(ChampionGGBuilder.GetFieldByLane("Jungle", stats.positions.JUNGLE));
            builder.AddField(ChampionGGBuilder.GetFieldByLane("Mid", stats.positions.MIDDLE));
            builder.AddField(ChampionGGBuilder.GetFieldByLane("ADC", stats.positions.DUO_CARRY));
            builder.AddField(ChampionGGBuilder.GetFieldByLane("Support", stats.positions.DUO_SUPPORT));
            await ReplyAsync("", embed: builder.Build());
        }
    }
}

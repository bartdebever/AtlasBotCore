using ChampionGGHandler;
using DataLibrary;
using DataLibrary.Static_Data;
using Discord;
using Discord.Commands;
using RiotWrapper;
using RiotWrapper.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AtlasBot.EmbedBuilder;
using DataLibrary.Riot.Item;
using Microsoft.EntityFrameworkCore;
using RiotWrapper.Helpers;

namespace AtlasBot.Modules
{
    [Group("lol")]
    class LeagueModule : ModuleBase
    {
        [Command("iteminit")]
        [Summary("Get's all items from the Riot API and saves them. COMMAND CAN ONLY BE USED BY THE BOTOWNER!")]
        public async Task Init()
        {
            if (Context.User.Id == 394426703423864852)
            {
                Temp.GetItems();
                await ReplyAsync("Done!");
            }
            else
            {
                await ReplyAsync("No permission!");
            }
            
        }

        [Command("item")]
        [Summary("Get the details of one item by name. Can use abbreviations or parts of the word.")]
        public async Task GetItem([Remainder] string name)
        {
            var message = await ReplyAsync("Getting data...");
            var database = new RiotData();
            //var item = database.Items.FirstOrDefault(x => x.name.ToLower().Equals(name.ToLower()));
            var itemList = database.Items.Where(x => x.name.ToLower().Equals(name.ToLower())).Include(i => i.gold).ToList();
            ItemDto item = null;
            Discord.EmbedBuilder builder = null;
            if (itemList.Count > 1)
            {
                var items = database.Items.Where(x => x.name.ToLower().Contains(name.ToLower())).ToList();
                builder = Builders.BaseBuilder("Multiple items found", "", Color.Red, null, "");
                string itemsstring = "";
                items.ForEach(x=> itemsstring += x.name +"\n");
                builder.AddField("Items", itemsstring);
                await ReplyAsync("", embed: builder.Build());
            }
            else
            {
                var items = database.Items.Include(x=> x.gold).Where(x => x.name.ToLower().Contains(name.ToLower())).ToList();
                if (items.Count == 1)
                {
                    item = items[0];
                    builder = Builders.BaseBuilder("", "", Color.DarkBlue,
                        new EmbedAuthorBuilder().WithName(item.name),
                        $"http://ddragon.leagueoflegends.com/cdn/6.24.1/img/item/{item.ItemId}.png");
                    builder.AddField("Effect", item.plaintext);
                    builder.AddField("Tooltip",
                        Regex.Replace(item.description.Replace("<br>", "\n"), "<.*?>", String.Empty));
                    builder.AddField("Cost", $"**Total: **{item.gold.total}\n" +
                                             $"**Base: **{item.gold.Base}");
                    if (!string.IsNullOrEmpty(item.requiredChampion))
                    {
                        builder.AddField("Required Champion", item.requiredChampion);
                    }
                    if (item.consumed)
                    {
                        builder.AddField("Consumable",
                            $"This item is a consumable and a play can have {item.stacks} of this item at a time.");
                    }
                    await ReplyAsync("", embed: builder.Build());
                }
                else if (items.Count > 1)
                {
                    builder = Builders.BaseBuilder("Multiple items found", "", Color.Red, null, "");
                    string itemsstring = "";
                    items.ForEach(x => itemsstring += x.name + "\n");
                    builder.AddField("Items", itemsstring);
                    await ReplyAsync("", embed: builder.Build());
                }
                else
                {
                    builder = Builders.ErrorBuilder("Item not found");
                    await ReplyAsync("", embed: builder.Build());
                }
            }
            await message.DeleteAsync();
        }

        [Command("champinit")]
        [Summary("Gets all champions from the Riot API and saves them. CAN ONLY BE USED BY BOTOWNER!")]
        public async Task ChampInit()
        {
            if (Context.User.Id == 111211693870161920)
            {
                Temp.GetChammpions();
                await ReplyAsync("Done!");
            }
            else await ReplyAsync("No permission!");

        }

        [Command("champion")]
        [Summary("Get details on a champion by name. Name does not have to be exact.")]
        public async Task Champion([Remainder] string name)
        {
            var database = new RiotData();
            var champions = database.Champions.Where(x=> x.name.ToLower().Equals(name.ToLower())).Include(c => c.spells).Include(c => c.skins).Include(c => c.info).Include(c => c.passive).ToList();
            DataLibrary.Champion champ = null;
            champ = champions.FirstOrDefault(x => x.name.ToLower().Equals(name.ToLower()));
            if (champ == null)
                champ = champions.First();
            var builder = Builders.BaseBuilder(champ.name, champ.title, Color.DarkBlue, null, $"http://ddragon.leagueoflegends.com/cdn/6.24.1/img/champion/{champ.key}.png");
            var keys = new List<string>() {"Q", "W", "E", "R"};
            string abilities = "";
            builder.AddField("Abilities", $"{champ.name} has the following spells:");
            for(int i = 0; i< 4; i++)
            {
                //abilities += $"**{keys[i]} {champ.spells[i].name}:**  {champ.spells[i].sanitizedDescription}\n";
                builder.AddField(keys[i] + " " + champ.spells[i].name + ":", $"{champ.spells[i].sanitizedDescription}");
            }
            builder.AddField("Passive", $"**{champ.passive.name}: **{champ.passive.description}");
            //builder.AddField("Abilities", abilities);
            string skins = "";
            champ.skins.ForEach(x=> skins += x.name + "\n");
            builder.AddField("Skins", skins);
            await ReplyAsync("", embed: builder.Build());
        }

        [Command("skin")]
        [Summary("View the splash art of a skin.")]
        public async Task Skin([Remainder] string name)
        {
            var database= new RiotData();
            var skins = database.Skins;
            var skinlist = skins.Where(x => x.name.ToLower().Contains(name.ToLower())).ToList();
            if (skinlist.Count() > 1)
            {
                var builder = Builders.BaseBuilder("Error: Multiple found", "", Color.Red, null, "");
                string doubes = "";
                skinlist.ForEach(x=> doubes += x.name + "\n");
                builder.AddField("Skins", doubes);
                await ReplyAsync("", embed: builder.Build());
            }
            else
            {
                var skin = skinlist[0];
                Champion champ = null;
                foreach (var databaseChampion in database.Champions.Include("skins"))
                {
                    foreach (var databaseChampionSkin in databaseChampion.skins)
                    {
                        if (databaseChampionSkin.skinId == skin.skinId)
                        {
                            champ = databaseChampion;
                        }
                    }
                }
                var builder = Builders.BaseBuilder("", "", Color.DarkBlue, null, "");
                builder.WithImageUrl($"http://ddragon.leagueoflegends.com/cdn/img/champion/splash/{champ.key}_{skin.num}.jpg");
                await ReplyAsync("", embed: builder.Build());
            }
        }

        [Command("ability")]
        [Summary("View details on a ability. Example: -lol ability Thresh Q")]
        public async Task Skill([Summary("Champion name")]string champion, [Summary("Ability used")] string ability)
        {
            var database = new RiotData();
            List<DataLibrary.Champion> champions = database.Champions.Include(c => c.spells).ThenInclude(s => s.vars).ThenInclude(s=> s.Coeff).ToList();
            DataLibrary.Champion champ = null;
            champ = champions.FirstOrDefault(x => x.name.ToLower().Equals(champion.ToLower()));
            if (champ == null)
                champ = champions.FirstOrDefault(x => x.name.ToLower().Contains(champion.ToLower()));
            var keys = new List<string>() { "Q", "W", "E", "R" };
            int index = keys.IndexOf(ability.ToUpper());
            var spell = champ.spells[index];
            var builder = Builders.BaseBuilder(spell.name, "", Color.DarkBlue,
                new EmbedAuthorBuilder().WithName(champ.name + " " + ability), $"http://ddragon.leagueoflegends.com/cdn/6.24.1/img/spell/{spell.key}.png ");
            builder.AddField("Description", spell.sanitizedDescription);
            string tooltip = spell.sanitizedTooltip;

            foreach (var spellVar in spell.vars)
            {
                tooltip = tooltip.Replace("{{ "+spellVar.key+" }}", spellVar.Coeff[0].value.ToString());
            }
            var spellburn = spell.EffectBurn.Split(',').ToList();
            for (int i = 1; i < spellburn.Count; i++)
            {
                tooltip = tooltip.Replace("{{ e" + i + " }}", spellburn[i]);
            }

            builder.AddField("Tooltip",tooltip );
            builder.AddField("Stats", $"**Resource: **{spell.costType}\n" +
                                      $"**Costs: **{spell.resource.Replace("{{ cost }}", "40")}\n" +
                                      $"**Cooldown: **{spell.cooldownBurn}");
            
            await ReplyAsync("", embed: builder.Build());
        }

        [Command("game")]
        [Summary("Get a current game that is going on. Has a delay due to how spectating works.")]
        public async Task Game(string region, [Remainder] string summonerName)
        {
            Platforms platform = (Platforms)Enum.Parse(typeof(Platforms), region.ToUpper());
            var riotClient = new RiotClient(OptionManager.RiotKey);
            var champions = new RiotData().Champions;
            var summoner = riotClient.Summoner.GetSummonerByName(summonerName, platform);
            var match = riotClient.Specate.GameBySummoner(platform, summoner.SummonerId);
            var builder = Builders.BaseBuilder("", "", Color.DarkBlue,
                new EmbedAuthorBuilder().WithName(summonerName + "'s game"), "");
            TimeSpan time = new TimeSpan(0, 0, (int) match.GameLength);
            builder.AddField($"Information", $"**Map: **{match.MapId}\n**Time: **{Math.Round(time.TotalMinutes,2)} minutes\n**Mode: **{match.GameMode}");
            for (int i = 1; i < 3; i++)
            {
                string bans1 = "";
                foreach (var matchBannedChampion in match.BannedChampions)
                {
                    if (matchBannedChampion.TeamId == i*100)
                    {
                        try
                        {
                            bans1 +=
                                champions.FirstOrDefault(x => x.ChampionId == matchBannedChampion.ChampionId).name +
                                ", ";
                        }
                        catch
                        {
                            bans1 += "None, ";
                        }
                    }
                }
                bans1 = bans1.Remove(bans1.Length - 2, 2);
                builder.AddField("Bans Team "+i,
                    bans1);
                string names = "";
                string championsNames = "";
                foreach (var currentGameParticipant in match.Participants.Where(x => x.TeamId == i*100).ToList())
                {
                    names += currentGameParticipant.SummonerName + "\n";
                    championsNames += champions.FirstOrDefault(x=> x.ChampionId == currentGameParticipant.ChampionId)?.name + "\n";
                }
                builder.AddInlineField("Summoners", names);
                builder.AddInlineField("Champion", championsNames);
            }
            await ReplyAsync("", embed: builder.Build());
        }
        [Command("summoner")]
        [Summary("Get info about a summoner account.")]
        public async Task Profile(string region, [Remainder] string summonerName)
        {
            var message = await ReplyAsync("Getting data...");
            var riotClient = new RiotClient(OptionManager.RiotKey);
            Platforms platform = RiotWrapper.Helpers.PlatformHelper.StringToPlatform(region);
            var summoner = riotClient.Summoner.GetSummonerByName(summonerName,platform);
            var leagues = riotClient.League.GetPositionDto(platform, summoner.SummonerId);
            var masteries = riotClient.Masteries.GetchampionMasteries(platform, summoner.SummonerId);
            var matches = 
            masteries = masteries.OrderByDescending(x => x.Level).ThenByDescending(x=> x.ChampionPoints).ToList();
            var builder = Builders.BaseBuilder("", "", Color.DarkBlue, new EmbedAuthorBuilder().WithName(summoner.Name),
                $"http://ddragon.leagueoflegends.com/cdn/6.24.1/img/profileicon/{summoner.ProfileIconId}.png");
            builder.AddInlineField($"Information", $"**Name: **{summoner.Name}\n**Region: **region\n**Level: **{summoner.SummonerLevel}");
            string rankings = "";
            leagues.Reverse();
            foreach (var leaguePositionDto in leagues)
            {
                rankings += $"**{RankedHelper.NormalizedQueue(leaguePositionDto.QueueType)}: **{leaguePositionDto.Tier.First().ToString().ToUpper() + leaguePositionDto.Tier.ToLower().Substring(1)} {leaguePositionDto.Rank}\n";
            }
            if (rankings == "") rankings = "Unranked";
            builder.AddInlineField($"Ranking", rankings);
            int champions = 4;
            if (champions > masteries.Count) champions = masteries.Count;
            builder.AddField("Top Mastery Champions", $"The top {champions} champions by mastery score");
            for (int i = 0; i < champions; i++)
            {
                int id = Convert.ToInt32(masteries[i].ChampionId);
                var database = new RiotData();
                var champion = database.Champions.FirstOrDefault(x=> x.ChampionId == id);
                builder.AddInlineField(champion.name, $"**Level: **{masteries[i].Level}\n**Points: **{masteries[i].ChampionPoints}");
            }
            await ReplyAsync("", embed: builder.Build());
            await message.DeleteAsync();
        }

        [Command("mastery")]
        [Summary("Get the mastery score and points by champion from a summoner. To get the Top 3 use the \"-lol summoner\" command.")]
        public async Task Mastery(string region, string summonerName, string championName)
        {
            RiotData data = new RiotData();
            RiotClient riotClient = new RiotClient(OptionManager.RiotKey);
            DataLibrary.Champion champion = null;
            Discord.EmbedBuilder builder = null;
            var championList = data.Champions.Where(x=> x.name.ToLower().Equals(championName.ToLower())).ToList();
            if (championList.Count < 1)
            {
                championList = new RiotData().Champions.Where(x => x.name.ToLower().Contains(championName.ToLower()))
                    .ToList();
            }
            champion = championList[0];
            if (champion != null)
            {
                var summoner = riotClient.Summoner.GetSummonerByName(summonerName, PlatformHelper.StringToPlatform(region));
                var masteries = riotClient.Masteries.GetchampionMasteries(PlatformHelper.StringToPlatform(region), summoner.SummonerId);
                var championMastery = masteries.FirstOrDefault(x => x.ChampionId == champion.ChampionId);
                builder = Builders.BaseBuilder($"{summoner.Name} mastery for {champion.name}", "", Color.DarkBlue, null, $"http://ddragon.leagueoflegends.com/cdn/6.24.1/img/champion/{champion.key}.png");
                builder.AddInlineField("Level", championMastery.Level);
                builder.AddInlineField("Points", championMastery.ChampionPoints);
            }
            else
            {
                builder = Builders.ErrorBuilder("Champion was not found");
            }

            await ReplyAsync("", embed: builder.Build());
        }
    }
}

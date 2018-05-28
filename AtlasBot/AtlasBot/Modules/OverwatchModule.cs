using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBot.EmbedBuilder;
using OverwatchHandler;

namespace DiscordBot.Modules
{
    [Group("Overwatch")]
    class OverwatchModule : ModuleBase
    {
        [Command("Hero")]
        [Summary("Get information about a hero by name.")]
        public async Task GetHero([Remainder] string name)
        {
            var hero = RequestHandler.GetHeroByName(name);
            string subroles = "";
            hero.sub_roles.ForEach(x => subroles+= x.name + ", ");
            if (subroles.Length > 0)
            subroles = subroles.Remove(subroles.Length - 2, 2);
            var builder = Builders.BaseBuilder(hero.name, "", Color.LightOrange, null, "");
            builder.AddField("Information", $"**Name: **{hero.name}\n" +
                                            $"**Main Role: **{hero.role.name}\n" +
                                            $"**Sub Roles: **{subroles}");
            string lore = "";
            if (!string.IsNullOrEmpty(hero.real_name)) lore += $"**Real Name: **{hero.real_name}\n";
            if (!string.IsNullOrEmpty(hero.affiliation)) lore += $"**Affiliation: **{hero.affiliation}\n";
            if (!string.IsNullOrEmpty(hero.base_of_operations)) lore += $"**Base of Operations: **{hero.base_of_operations}\n";
            if (hero.age != null) lore += $"**Age: **{hero.age}\n";
            if (hero.height != null) lore += $"**Height: **{hero.height}\n";
            builder.AddField("Lore", lore);
            builder.AddField("Stats",
                $"**Health: **{hero.health}\n" +
                $"**Armor: **{hero.armor}\n" +
                $"**Shield: **{hero.shield}");
            string abilityInfo = "";
            foreach (var overwatchAbility in hero.abilities)
            {
                if (overwatchAbility.is_ultimate)
                {
                    abilityInfo += "***Ultimate***\n";
                }
                abilityInfo += $"**{overwatchAbility.name}**: {overwatchAbility.description}\n";
            }
            builder.AddField("Abilities", abilityInfo);
            await ReplyAsync("", embed: builder.Build());
        }

        [Command("Profile")]
        [Summary("Get information about a users profile by name and region." +
                 "\nCurrently only works for pc users!")]
        public async Task GetProfile(string region, [Remainder] string name)
        {
            var profile = RequestHandler.GetProfileByName(region, name);
            var builder = Builders.BaseBuilder("", "", Color.Blue, new EmbedAuthorBuilder().WithIconUrl(profile.icon).WithName(profile.name), profile.ratingIcon);
            builder.AddField("Information",
                $"**Name: **{profile.name}\n" +
                $"**Prestige: **{profile.prestige}\n" +
                $"**Level: **{profile.level}\n" +
                $"**Rating: **{profile.rating}\n" +
                $"**Total Games Won: **{profile.gamesWon}\n" +
                $"**QuickPlay Games Won: **{profile.quickPlayStats.games.won}\n" +
                $"**Competitive:**\n" +
                $"- Games Played: {profile.competitiveStats.games.played}\n" +
                $"- Games Won: {profile.competitiveStats.games.won}\n");
            var cpHerolist = profile.competitiveStats.careerStats.Where(x => x.Value.game.timePlayed != "--").ToDictionary(x=> x.Key, x=> x.Value);
            var orderedList = cpHerolist.OrderByDescending(x => x.Value.game.gamesWon).ToDictionary(x => x.Key, x => x.Value);
            var count = 3;
            if (orderedList.Count() < count) count = orderedList.Count();
            builder.AddField("Top 3 Competitive Heroes", "Results may not be 100% accurate");
            using (var enumerator = orderedList.GetEnumerator())
            {

                enumerator.MoveNext(); //Skip AllHeroes
                for (int i = 0; i < count; i++)
                {
                    enumerator.MoveNext();
                    var hero = enumerator.Current;
                    builder.AddInlineField(FirstCharToUpper(hero.Key),
                        $"Playtime: {hero.Value.game.timePlayed}\n" +
                        $"Eliminations: {hero.Value.combat.eliminations}\n" +
                        $"Solo Kills: {hero.Value.combat.soloKills}\n" +
                        $"Deaths: {hero.Value.deaths.deaths}\n" +
                        $"Weapon Accuracy: {hero.Value.combat.weaponAccuracy}\n");

                }
            }
            builder.AddField("Top 3 QuickPlay Heros", "Results may not be 100% accurate.");
            var qpHerolist = profile.quickPlayStats.careerStats.Where(x => x.Value.game.timePlayed != "--").ToDictionary(x => x.Key, x => x.Value);
            var ordered = qpHerolist.OrderByDescending(x => x.Value.game.gamesWon).ToDictionary(x => x.Key, x => x.Value);
            using(var enumerator = ordered.GetEnumerator())
            {
                enumerator.MoveNext(); //Skip AllHeroes
                for (int i = 0; i < count; i++)
                {
                    enumerator.MoveNext();
                    var hero = enumerator.Current;
                    builder.AddInlineField(FirstCharToUpper(hero.Key),
                        $"Playtime: {hero.Value.game.timePlayed}\n" +
                        $"Eliminations: {hero.Value.combat.eliminations}\n" +
                        $"Solo Kills: {hero.Value.combat.soloKills}\n" +
                        $"Deaths: {hero.Value.deaths.deaths}\n" +
                        $"Weapon Accuracy: {hero.Value.combat.weaponAccuracy}\n");
                }
            }
            await ReplyAsync("", embed: builder.Build());
        }
        public static string FirstCharToUpper(string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using AtlasBot.EmbedBuilder;
using SpeedRunCom;

namespace AtlasBot.Modules
{
    [Group("Speedrun")]
    class SpeedrunModule : ModuleBase
    {
        [Command("game")]
        public async Task GetGame([Remainder] string gameName)
        {
            var handler = new RequestHandler();
            var game = handler.LookupGame(gameName);
            if (game == null)
                return;
            var gameobj = game.data[0];
            var builder = Builders.BaseBuilder("", "", Color.DarkerGrey, null, "");
            string names = "";
            bool first = true;
            foreach (var gameobjName in gameobj.names)
            {
                if (first)
                {
                    builder.Title = gameobjName.Value;
                    first = false;
                }
                names += gameobjName.Key + ": " + gameobjName.Value + "\n";
            }
            
            string categories = "";
            gameobj.categories.data.ForEach(x=>categories += x.name+"\n");
            builder.AddInlineField($"**Names:**", names);
            builder.AddInlineField("**Categories**", categories);
            //            builder.AddInlineField("Categories",categories);
            foreach (var gameobjAsset in gameobj.assets)
            {
                if (gameobjAsset.Key == "icon")
                {
                    builder.WithThumbnailUrl(gameobjAsset.Value.uri);
                    break;
                }
                
            }
            string platforms = "";
            foreach (var gameobjPlatform in gameobj.platforms.data)
            {
                platforms += $"**{gameobjPlatform.name}:** {gameobjPlatform.released}\n";
            }
            builder.AddInlineField("Platforms", platforms);
            string moderators = "";
            foreach (var moderator in gameobj.moderators.data)
            {
                moderators += moderator.names.Values.First() + "\n";
            }
            builder.AddInlineField("**Moderators**", moderators);
            await ReplyAsync("", embed: builder.Build());
        }
        [Command("leaderboard")]
        public async Task GetLeaderboard(string game, string category)
        {
            var leaderboard = new RequestHandler().GetLeaderboard(game, category.Replace("%", "")).data;
            if (leaderboard != null)
            {
                var builder = Builders.BaseBuilder(leaderboard.game.data.names["international"],
                    "Leaderboard of " + leaderboard.category.data.name, Color.Blue, null, null);
                string runs = "";
                for (int i = 0; i < leaderboard.runs.Count; i++)
                {
                    runs +=
                        $"**{i+1}**: {leaderboard.players.data.FirstOrDefault(x => x.id == leaderboard.runs[i].run.players[0].id).names["international"]}, {leaderboard.runs[i].run.times.primary.Replace("PT", "").Replace("H", ":").Replace("M", ":").Replace("S", "")}\n";
                }
                builder.AddInlineField("Leaderboard", runs);
                if(leaderboard.category.data.rules.Length < 1024)
                    builder.AddInlineField("Rules", leaderboard.category.data.rules);
                builder.WithThumbnailUrl(leaderboard.game.data.assets["icon"].uri);
                builder.WithUrl(leaderboard.weblink);
                await ReplyAsync("", embed: builder.Build());
            }

        }

        [Command("wr")]
        public async Task GetWorldRecord(string game, string category)
        {
            var leaderboard = new RequestHandler().GetWorldRecord(game, category.Replace("%", "")).data;
            var builder = Builders.BaseBuilder("World record of " + leaderboard.game.data.names["international"] + " " + leaderboard.category.data.name,""
                , Color.Blue, null, null);
            builder.AddInlineField("Run info",
                $"**Time: **{leaderboard.runs[0].run.times.primary.Replace("PT", "").Replace("H", ":").Replace("M", ":").Replace("S", "")}\n" +
                $"**Runner: **{leaderboard.players.data[0].names["international"]}\n" +
                $"**Video: **{leaderboard.runs[0].run.videos.links[0].uri}\n" +
                $"**Comment: \n**{leaderboard.runs[0].run.comment.Replace("\r\n\r\n", "\n")}");
            builder.WithUrl(leaderboard.runs[0].run.weblink);
            builder.WithThumbnailUrl(leaderboard.game.data.assets["icon"].uri);
            await ReplyAsync("", embed: builder.Build());
        }

        [Command("User")]
        public async Task GetUserData([Remainder] string name)
        {
            var message = await ReplyAsync("Gathering data...");
            try
            {
                var user = new RequestHandler().GetUser(name).data;
                var builder = Builders.BaseBuilder(user.names["international"], "", Color.Blue, null, null);
                builder.AddInlineField("Information",
                    $"**Name:** {user.names["international"]}\n" +
                    $"**Country:** {user.location.country.names["international"]}");
                string links = "";
                if (user.twitch != null)
                    links += user.twitch.uri + "\n";
                if (user.twitter != null)
                    links += user.twitter.uri + "\n";
                if (user.hitbox != null)
                    links += user.hitbox + "\n";
                if (user.speedrunslive != null)
                    links += user.speedrunslive.uri + "\n";
                if (user.youtube != null)
                    links += user.youtube.uri + "\n";
                if (!string.IsNullOrEmpty(links))
                    builder.AddInlineField("Links", links);
                builder.WithUrl(user.weblink);
                var wrRuns = new RequestHandler().GetWorldRecordsPerUser(user.id).OrderBy(x=>x.game.data.names["international"]).ToList();
                string worldrecords = "";
                for (int i = 0; i < wrRuns.Count; i++)
                {
                    if(wrRuns[i].level?.data == null)
                        worldrecords +=
                            $"**{wrRuns[i].game.data.names["international"]} {wrRuns[i].category.data.name}: **{ConvertToTime(wrRuns[i].run.times.primary)}\n";
                    else
                        worldrecords +=
                            $"**{wrRuns[i].game.data.names["international"]} (IL) {wrRuns[i].level.data.name}: **{ConvertToTime(wrRuns[i].run.times.primary)}\n";
                }
                if (!string.IsNullOrEmpty(worldrecords))
                    builder.AddInlineField("World Records", worldrecords);
                var recentRuns = new RequestHandler().GetLatestRunsPerUser(user.id);
                string runs = "";
                for (int i = 0; i < 10; i++)
                {
                    if(recentRuns[i].level?.data == null)
                        runs +=
                            $"**{recentRuns[i].game.data.names["international"]} {recentRuns[i].category.data.name} {PlaceConverter.Ordinal(recentRuns[i].place)} place:** " +
                            $"{/*recentRuns[i].run.times.primary.Replace("PT", "").Replace("H", ":").Replace("M", ":").Replace("S", "")*/ ConvertToTime(recentRuns[i].run.times.primary)}\n";
                    else
                        runs +=
                            $"**{recentRuns[i].game.data.names["international"]} (IL) {recentRuns[i].level.data.name} {PlaceConverter.Ordinal(recentRuns[i].place)} place:** {ConvertToTime(recentRuns[i].run.times.primary)}\n";
                }
                if (!string.IsNullOrEmpty(runs))
                    builder.AddInlineField("Recent PBs", runs);
                await message.DeleteAsync();
                await ReplyAsync("", embed: builder.Build());
            }
            catch
            {
                await message.DeleteAsync();
                await ReplyAsync("User not found");
            }

        }

        [Command("runs")]
        public async Task GetRunsUser(string game, string username)
        {
            var requester = new RequestHandler();
            var message = await ReplyAsync("Gathering Data...");
            try
            {
                var user = requester.GetUser(username).data;
                var runs = requester.GetRunsPerUserPerGame(user.id, game);
                var builder = Builders.BaseBuilder(user.names["international"],
                    "Runs done in game " + runs[0].game.data.names["international"], Color.Blue, null,
                    runs[0].game.data.assets["icon"].uri);
                string runText = "";
                foreach (var run in runs)
                {
                    if(run.level?.data == null)
                        runText +=
                            $"**{run.category.data.name} {PlaceConverter.Ordinal(run.place)} place:** {ConvertToTime(run.run.times.primary)}\n";
                    else
                        runText +=
                            $"**(IL) {run.level.data.name} {PlaceConverter.Ordinal(run.place)} place:** {ConvertToTime(run.run.times.primary)}\n";
                }
                builder.AddInlineField("Runs", runText);
                await message.DeleteAsync();
                await ReplyAsync("", embed: builder.Build());
            }
            catch
            {
                await message.DeleteAsync();
                await ReplyAsync("User or Game not found");
            }
        }

        public string ConvertToTime(string timeString)
        {
            string[] characters = {"PT", "H", "M", "S"};
            foreach (var character in characters)
            {
                timeString = timeString.Replace(character, ":");
            }
            List<string> chars = new List<string>(timeString.Split(":"));
            for(int i = 0; i < chars.Count; i++)
            {
                if (chars[i].Length == 1 && i!=0)
                {
                    chars[i] = "0" + chars[i];
                }
            }
            chars.RemoveAt(chars.Count-1);
            chars.RemoveAt(0);
            return chars.Aggregate((a, b) => a + ":" +b);
        }
    }
}

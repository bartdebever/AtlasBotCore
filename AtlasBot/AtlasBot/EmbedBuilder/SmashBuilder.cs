using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Static_Data;
using Discord;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmashHandler;
using SmashHandler.DataTypes;

namespace AtlasBot.EmbedBuilder
{
    public static class SmashBuilder
    {
        public static Discord.EmbedBuilder UserInfo(string username)
        {
            RootObject root = RequestHandler.GetUserByName(username);
            User user = root.user;
            Discord.EmbedBuilder builder = Builders.BaseBuilder("Link to " + Names.SmashLadder + " Profile", "All information known about **" + user.username + "**",
                ColorPicker.SmashModule,
                new EmbedAuthorBuilder().WithName(Names.SmashLadder)
                    .WithUrl("http://www.smashladder.com"), "");
            builder.WithThumbnailUrl("https://www.smashladder.com/images/subhypepikachu-logo.png");
            if (user.selected_flair != null)
            {
                builder.WithAuthor(new EmbedAuthorBuilder().WithName(Names.SmashLadder)
                    .WithUrl("http://www.smashladder.com").WithIconUrl("http:" + user.selected_flair.url));
            }
            string location = "";
            if (!string.IsNullOrEmpty(user.location.Locality)) location += user.location.Locality + ", ";
            if (!string.IsNullOrEmpty(user.location.State)) location += user.location.State + ", ";
            if (!string.IsNullOrEmpty(user.location.Country.name)) location += user.location.Country.name;
            string status = "Offline";
            string sub = "";
            if (user.is_online!=null) status = "Online";
            if (user.is_subscribed != null) sub = "**User is subscribed!**\n";
            builder.AddField(new EmbedFieldBuilder().WithName("Profile").WithValue(
                "**Name: **" + user.username + "\n" +
                "**Member Since: **" + user.member_since.full.ToLongDateString()+ "\n" +
                "**Location: **" + location+ "\n" +
                "**Status message: **" + user.away_message + "\n" +
                "**Total matches played: **" + user.total_matches_played +"\n"+
                "**Status: **" + status+"\n"+sub
                ));
            var filteredgames = user.ladder_information.AllGames.Where(x => x != null).ToList();
            try
            {
                filteredgames = filteredgames.Where(x => x.league.stats.RankedPlayed != 0).ToList();
            }
            catch
            {
                //No ranked games played
            }
            foreach (var game in filteredgames)
                {
                    try
                    {
                        var characters = "";
                        var count = 3;
                        if (game.characters.Count < count) count = game.characters.Count;
                        if (count != 0)
                        {
                            characters = "**Characters:**\n";
                            for (int i = 0; i < count; i++)
                            {
                                characters += "**  " + game.characters[i].name + ": **" + game.characters[i].percent + "%\n";
                            }
                        }
                        var rank = "**Ranked: **Unranked\n";
                        if (!string.IsNullOrEmpty(game.league.Tier))
                        {
                            rank = "**Ranked: **" + game.league.Tier + " " + game.league.Division + "\n";
                        }
                        builder.AddField(new EmbedFieldBuilder().WithName(game.name).WithValue(
                            "**Total ranked games played: **" + game.league.stats.RankedPlayed + "\n" +
                            rank+
                            characters
                        ));
                }
                    catch
                    {
                        
                    }

                }

            if (root.now_playing != null)
            {
                string type = "Friendlies";
                if (root.now_playing.is_ranked)
                {
                    type = "Ranked";
                }
                
                string rankp1 = "Unranked";
                try
                {
                    var games1 = root.now_playing.player1.ladder_information.AllGames;
                    games1 = games1.Where(x => x != null).ToList();
                    SmashHandler.DataTypes.Game gamep1 = games1.Single(x => x.id == root.now_playing.ladder.id);
                    if (!string.IsNullOrEmpty(gamep1.league.Tier)) rankp1 = gamep1.league.Tier + " " + gamep1.league.Division;
                }
                catch { }
                string rankp2 = "Unranked";
                try
                {
                    var games2 = root.now_playing.player2.ladder_information.AllGames;
                    games2 = games2.Where(x => x != null).ToList();
                    SmashHandler.DataTypes.Game gamep2 = games2.Single(x => x.id == root.now_playing.ladder.id);
                    if (!string.IsNullOrEmpty(gamep2.league.Tier)) rankp2 = gamep2.league.Tier + " " + gamep2.league.Division;
                }
                catch { }
                builder.AddField(new EmbedFieldBuilder().WithName("Currently Playing").WithValue(
                    "**" + root.now_playing.ladder_name + " " + type + "**: \n" +
                    "Using " + root.now_playing.preferred_build.name+"\n"+
                    root.now_playing.player1.username + " " +"("+rankp1+")" + " vs " + root.now_playing.player2.username + " (" + rankp2+")"));
            }
            builder.WithUrl(user.profile_url);
            return builder;
        }
    }
}

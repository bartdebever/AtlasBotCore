using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;
using DataLibrary.Discord.Implemented;
using DataLibrary.Static_Data;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace AtlasBot.EmbedBuilder
{
    public static class Builders
    {
//        public static Embed CurrentUserEmbed(ICommandContext Context)
//        {
//            Mock database = DatabaseManager.GetMock();
//            DiscordUser atlasAccount = null;
//            try
//            {
//                atlasAccount =
//                    database.Users.FirstOrDefault(x => (x as DiscordUser).Discordid == (long)Context.User.Id);
//                
//            }
//            catch
//            {
//                //Log user not registed
//            }
//            Discord.EmbedBuilder eb = BaseBuilder("", "", ColorPicker.UserModule,
//                new EmbedAuthorBuilder().WithName("Information about " + Context.User.Username),
//                Context.User.GetAvatarUrl());
//            if (atlasAccount != null)
//            {
//                eb.Description = "Displaying user information for the " + Names.Systemname + " account";
//                eb.AddField(new EmbedFieldBuilder().WithName(Names.Systemname + " Information").WithValue(
//                    "**Name:** " + atlasAccount.Name + "\n"+
//                    "**Account created:** " + atlasAccount.CreationDate.ToLongDateString()));
//            }
//            else
//            {
//                eb.AddField(new EmbedFieldBuilder()
//                    .WithValue("User is not registed, use -user register to register now.")
//                    .WithName(Names.Systemname + " Account"));
//            }
//            //eb.WithUrl("http://placeholder.com/user/id/111020301023");
//            string discordInformation = "";
//            try
//            {
//                var user = Context.User as IGuildUser;
//                discordInformation += "**Joined at: **" + user.JoinedAt.Value.Date.ToLongDateString() + "\n";
//            }
//            catch
//            {
//                //Log User not in guild
//            }
//            discordInformation += "**Status:** " + Context.User.Status + "\n";
//
//            if (Context.User.Game != null)
//            {
//                discordInformation += "**Currently Playing: **" + Context.User.Game.Value.Name + "\n";
//            }
//            eb.AddField(new EmbedFieldBuilder().WithName("Discord information").WithValue(discordInformation));
//            //if (atlasAccount != null)
//            //{
//            //    if (atlasAccount.Summoners.Count > 0)
//            //    {
//            //        string summoners = "";
//            //        foreach (var summoner in atlasAccount.Summoners)
//            //        {
//            //            summoners += summoner.Region + ": " + summoner.SummonerId; //TODO Make this a Tier
//            //        }
//            //        eb.AddField(new EmbedFieldBuilder().WithName("Summoner Information").WithValue(summoners));
//            //    }
//            //    else
//            //    {
//            //        eb.AddField(new EmbedFieldBuilder().WithName("Summoner Information")
//            //            .WithValue("This user has no summoners."));
//            //    }
//            //}
//            if (atlasAccount != null)
//            {
//                string accountinfo = "User does not have accounts linked\nUser **-HELPCOMMAND** to get started.";
//                if (atlasAccount.SmashAccount.Username != null && (bool)atlasAccount.SmashAccount.IsVerified)
//                {
//                    accountinfo = "**" + Names.SmashLadder + " account:**\n" + atlasAccount.SmashAccount.Username + " "+
//                                   atlasAccount.SmashAccount.Rank;
//                }
//                eb.AddField("Accounts", accountinfo);
//            }
//
//            return eb.Build();
//        }

//        public static Embed CurrentServerEmbed(IGuild guild)
//        {
//            DiscordServer server;
//            var database = DatabaseManager.GetMock();
//            try
//            {
//                server = database.Servers.FirstOrDefault(x => x.ServerId == guild.Id);
//            }
//            catch
//            {
//                server = null;
//            }
//            
//            Discord.EmbedBuilder builder = BaseBuilder("", "Information about this server known to " + Names.BotName, ColorPicker.ServerModule, new EmbedAuthorBuilder().WithName(guild.Name), guild.IconUrl);
//            builder.AddField(new EmbedFieldBuilder().WithName("Discord Information")
//                .WithValue("**Name:** " + guild.Name + "\n"
//                           + "**Users:** " + (guild as SocketGuild).Users.Count + "\n"
//                           + "**Created at:** " + guild.CreatedAt.DateTime.ToLongDateString() + "\n"
//                           + "**Owner:** " + guild.GetOwnerAsync().Result.Username));
//            if (server == null)
//            {
//                builder.AddField(new EmbedFieldBuilder().WithName(Names.Systemname + " Information")
//                    .WithValue(
//                        "Server is not linked to an account. Let the owner use -server register *<Tier>* to start"));
//            }
//            else
//            {
//                builder.AddField(new EmbedFieldBuilder().WithName(Names.Systemname + " Information").WithValue(
//                    "**Name: **" + server.Name+"\n"+
//                    "**Description: **"+ server.Description+"\n"+
//                    "**Joined at: **" + server.JoinDateTime.ToLongDateString()+"\n"+
//                    "**Votes: **" + server.Votes));
//            }
//            return builder.Build();
//        }
//
//        public static Embed ServerList(string filter)
//        {
//            Discord.EmbedBuilder builder = BaseBuilder("", "All servers known ordered by votes.", ColorPicker.ServerModule, new EmbedAuthorBuilder().WithName(Names.Systemname + " server list"), null);
//            if (string.IsNullOrEmpty(filter)) //No parameter is given and we should display the full server list
//            {
//                List<DiscordServer> servers = DatabaseManager.GetMock().Servers.ToList();
//                //Add servers from other sources
//                var orderedServers = servers.OrderBy(x => x.Votes).ToList();
//                int maxservers = 5; //Maximal servers to display
//                if (maxservers > orderedServers.Count()) maxservers = orderedServers.Count;
//
//                for (int i = 0; i < maxservers; i++)
//                {
//
//                    builder.AddField(new EmbedFieldBuilder().WithName(orderedServers[i].Name)
//                        .WithValue("**Votes:** " + orderedServers[i].Votes + "\n" +
//                                   "**Description: **" + orderedServers[i].Description));
//                }
//            }
//            return builder.Build();
//        }
        //Base Builder
        public static Discord.EmbedBuilder BaseBuilder(string title, string description, Color color,
            EmbedAuthorBuilder authorBuilder, string thumbnailurl)
        {
            Discord.EmbedBuilder builder = new Discord.EmbedBuilder().WithColor(color).WithFooter(Names.BotName).WithCurrentTimestamp();
            if (!string.IsNullOrEmpty(description)) builder.WithDescription(description);
            if (!string.IsNullOrEmpty(title)) builder.WithTitle(title);
            if (authorBuilder != null) builder.WithAuthor(authorBuilder);
            if (!string.IsNullOrEmpty(thumbnailurl)) builder.WithThumbnailUrl(thumbnailurl);
            return builder;
        }
        //Failed Response
        public static Discord.EmbedBuilder ErrorBuilder(string exception)
        {
            return ErrorBuilder(exception, null);
        }

        public static Discord.EmbedBuilder ErrorBuilder(string exception, Exception ex)
        {
            Discord.EmbedBuilder builder = BaseBuilder("", "Well this is awkward, I made a mistake", ColorPicker.FailedResponse,
                new EmbedAuthorBuilder().WithName("Error"), null);
            builder.AddField(new EmbedFieldBuilder().WithName("**Error details**").WithValue(exception));
            if (ex != null)
            {
                builder.AddField(new EmbedFieldBuilder().WithName("Do not worry!")
                    .WithValue("This error has already been sent to Bort, he will work on this soon I promise!"));
                //TODO ErrorHandler.SendErrorBort(exception);
            }
            return builder;
        }
    }
}

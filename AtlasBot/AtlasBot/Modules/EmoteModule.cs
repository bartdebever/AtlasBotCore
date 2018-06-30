using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlasBot.Modules;
using AtlasBot.Preconditions;
using DataLibrary;
using DataLibrary.Static_Data;
using Discord;
using Discord.Commands;
using AtlasBot.EmbedBuilder;
using Microsoft.EntityFrameworkCore;

namespace AtlasBot.Modules
{
    [RequireBotCommander]
    [Group("emote")]
    [RequireTeamLiquid]
    [HiddenModule]
    public class EmoteModule : ModuleBase
    {
        [Command("Add")]
        public async Task AddEmote(string emoji, string roleName)
        {
            var db = new DatabaseContext();
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.Equals(roleName));
            var server = db.Servers.Include(x => x.Options).ThenInclude(x=>x.RoleEmotes).FirstOrDefault(x => x.ServerId == (long)Context.Guild.Id);
            if (role != null && server != null)  
            {
                var obj = new RoleEmote();
                obj.DiscordRole = (long)role.Id;
                
                var name = emoji.Replace(":", "");
                Console.WriteLine(name);
                Console.WriteLine(Context.Guild.Emotes.First().Name);
                var emote = Context.Guild.Emotes.FirstOrDefault(x => name.Contains(x.Id.ToString()));
                obj.Emote = (long)emote.Id;
                server.Options.RoleEmotes.Add(obj);
                db.Servers.Update(server);
                db.SaveChanges();
                IUserMessage message = null;
                foreach (var textChannel in Context.Guild.GetTextChannelsAsync().Result)
                {
                    try
                    {
                        message = (IUserMessage) await textChannel.GetMessageAsync(
                            (ulong) server.Options.RoleEmoteMessageId);
                        if (message != null)
                            break;
                    }
                    catch { }
                }
                if (message != null)
                {
                    ServerContainer.DeleteCache();
                    await ReplyAsync($"{emoji} was been added for role " + role.Name);
                    await message.AddReactionAsync(emote);
                }
                    
            }
        }
        [Command("list")]
        public async Task List()
        {
            var db = new DatabaseContext();
            var server = db.Servers.Include(x => x.Options).ThenInclude(x => x.RoleEmotes).FirstOrDefault(x => x.ServerId == (long)Context.Guild.Id);
            if (server != null)
            {
                string reply = "";
                foreach (var optionsRoleEmote in server.Options.RoleEmotes)
                {
                    var role = Context.Guild.GetRole((ulong) optionsRoleEmote.DiscordRole);
                    var emote = Context.Guild.Emotes.FirstOrDefault(x => x.Id == (ulong) optionsRoleEmote.Emote);
                    reply += role.Name + ": " + emote + "\n";
                }
                await ReplyAsync(reply);
            }
        }
        [Command("Select")]
        public async Task SelectMessage(string id)
        {
            var db = new DatabaseContext();
            var messageId = Convert.ToUInt64(id);
            var server = db.Servers.Include(x => x.Options).FirstOrDefault(x => x.ServerId == (long)Context.Guild.Id);
            if (server == null)
            {
                await ReplyAsync("Please use -s server register to register your server first!");
            }
            else
            {
                server.Options.RoleEmoteMessageId = (long)messageId;
                db.Servers.Update(server);
                db.SaveChanges();
                await ReplyAsync("Saved selected message");
            }

        }

        [Command("AddRoles")]
        public async Task AddRoles()
        {
            var db = new DatabaseContext();
            var server = db.Servers.Include(x => x.Options).ThenInclude(x => x.RoleEmotes).FirstOrDefault(x => x.ServerId == (long)Context.Guild.Id);
            if (server != null)
            {
                var channels = Context.Guild.GetTextChannelsAsync().Result;
                IMessage message = null;
                foreach (var textChannel in channels) //Can't look for the message by Id so need to search all channels...
                {
                    try //Can't download messages in a channel we don't have permission in, will throw an exception
                    {
                        message = await textChannel.GetMessageAsync((ulong) server.Options.RoleEmoteMessageId);
                        if (message == null) continue;
                        var reactionList = ((IUserMessage) message).Reactions;
                        foreach (var reaction in reactionList) //Go through all reactions posted on the message
                        {
                            var users = await ((IUserMessage) message).GetReactionUsersAsync(reaction.Key.Name);  //Get all users that reacted with this emote
                            if (!(reaction.Key is GuildEmote emote)) continue;                                    //Make sure it isn't some random emote
                            var roleId = server.Options.RoleEmotes.FirstOrDefault(x => x.Emote == (long) emote.Id); //Find the role that belongs to this emote
                            if (roleId == null) continue;
                            var role = Context.Guild.GetRole((ulong) roleId.DiscordRole); //Get the role from the server
                            if (role == null) continue;
                            foreach (var user in users) //Go through all users that reacted with the emote
                            {
                                if(user is IGuildUser guildUser && !guildUser.RoleIds.Contains(role.Id)) //Check if the user does not have the role
                                    await guildUser.AddRoleAsync(role); //Add the role to the user!
                            }
                        }

                        break;
                    }
                    catch
                    {
                        return;
                    }
                }
                if (message is IUserMessage userMessage)
                {
                    foreach (var reaction in userMessage.Reactions)
                    {
                        
                    }
                }
            }

        }

    }
}

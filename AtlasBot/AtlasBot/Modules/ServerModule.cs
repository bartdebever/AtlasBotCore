using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AtlasBot.Preconditions;
using DataLibrary;
using DataLibrary.Discord.Implemented;
using DataLibrary.Static_Data;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBot.EmbedBuilder;
using Microsoft.EntityFrameworkCore;

namespace DiscordBot.Modules
{
    [Group("Server")]
    [Summary("TODO")]
    [HiddenModule]
    [RequireTeamLiquid]
    [RequireBotCommander]
    public class ServerModule : ModuleBase
    {
        [RequireInServer]
        [Command("register")]
        public async Task Register()
        {
            var db = new DatabaseContext();
            if (db.Servers.FirstOrDefault(x => x.ServerId == (long) Context.Guild.Id) == null)
            {
                var server = new DiscordSavedServer()
                {
                    ServerId = (long) Context.Guild.Id,
                    Options = new Options(),
                };
                server.Options.ModulesEnabled = new List<DiscordModule>();
                foreach (var module in DiscordManager.Commands.Modules)
                {
                    server.Options.ModulesEnabled.Add(new DiscordModule(module.Name));
                }
                db.Servers.Add(server);
                db.SaveChanges();
                await ReplyAsync("Server has been registered!");
            }
            else
                await ReplyAsync("You are already registered");
        }

        [RequireInServer]
        [Command("module")]
        public async Task ToggleModule([Remainder] string moduleName)
        {
            var db = new DatabaseContext();
            var server = db.Servers.Include(x => x.Options).ThenInclude(x=>x.ModulesEnabled).FirstOrDefault(x => x.ServerId == (long) Context.Guild.Id);
            if (server != null)
            {
                var module = server.Options.ModulesEnabled.FirstOrDefault(x=>x.Name == moduleName);
                if(module!=null)
                {
                    server.Options.ModulesEnabled.Remove(module);
                    module.Enabled = !module.Enabled;
                    server.Options.ModulesEnabled.Add(module);
                    db.Servers.Update(server);
                    db.SaveChanges();
                    await ReplyAsync("Toggled module");
                }
                else
                {
                    await ReplyAsync("Module not found");
                }
            }
            else
                await ReplyAsync("Server is not registered, please register using -s server register");
        }

        [RequireInServer]
        [Command("list")]
        public async Task ListModules()
        {
            var db = new DatabaseContext();
            var server = db.Servers.Include(x => x.Options).ThenInclude(x=>x.ModulesEnabled).FirstOrDefault(x => x.ServerId == (long) Context.Guild.Id);
            if (server != null)
            {
                string list = "";
                foreach (var module in server.Options.ModulesEnabled)
                {
                    list += module.Name + ": " + module.Enabled + "\n";
                }
                await ReplyAsync(list);
            }
        }
    }
}

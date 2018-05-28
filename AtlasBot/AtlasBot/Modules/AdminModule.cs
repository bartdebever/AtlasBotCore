using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AtlasBot.Preconditions;
using DataLibrary.Static_Data;
using Discord;
using Discord.Commands;

namespace AtlasBot.Modules
{
    [Group("Admin")]
    [HiddenModule]
    [RequireBotOwner]
    public class AdminModule : ModuleBase
    {
        [Command("Game")]
        public async Task ChangeGame([Remainder] string game)
        {
            if (!string.IsNullOrEmpty(game))
            {
                await DiscordManager.Client.SetGameAsync(game, "atlasbot.net", StreamType.Twitch);
                await ReplyAsync("Set game to \"" + game + "\"");
            }
        }

        [Command("Servers")]
        public async Task GetServerCount()
        {
            var serverCount = DiscordManager.Client.Guilds.Count;
            await ReplyAsync($"Currently on {serverCount} servers!");
        }

        [Command("Users")]
        public async Task GetUserCount()
        {
            var userCount = 0;
            foreach (var guild in DiscordManager.Client.Guilds)
            {
                userCount += guild.MemberCount;
            }
            await ReplyAsync($"Currently {userCount} users using AtlasBot");
        }

        [Command("ServerList")]
        public async Task GetServerList()
        {
            var servers = DiscordManager.Client.Guilds;
            string serverList = "";
            foreach (var socketGuild in servers)
            {
                serverList += socketGuild.Name + " - " + socketGuild.Owner.Username + "\n";
            }
            await ReplyAsync(serverList);
        }
    }
}


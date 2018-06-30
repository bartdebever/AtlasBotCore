using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace AtlasBot.Modules
{
    [Group("ssbu")]
    [Alias("Smashuuuuuu", "smash5", "smush","smitch", "smashu", "5mash", "sma5h")]
    [Summary("All commands for the Super Smash Bros Ultimate Game")]
    public class SmashUltimateModule : ModuleBase
    {
        [Command("Characters")]
        public async Task GetCharacters()
        {
            
        }

        [Command("Stages")]
        public async Task GetAllStages()
        {
            
        }
    }
}

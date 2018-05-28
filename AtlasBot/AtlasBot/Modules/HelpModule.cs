using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AtlasBot.Attributes;
using AtlasBot.Preconditions;
using DataLibrary.Static_Data;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordBot.EmbedBuilder;

namespace DiscordBot.Modules
{
    [Group("help")]
    public class HelpModule : ModuleBase
    {
        [Command("")]
        [Summary("Shows all the commands available.")]
        public async Task GetHelp([Optional][Remainder] string command)
        {
            if (!string.IsNullOrEmpty(command))
                await GetHelpCommand(command);
            else
            {
                var builder = Builders.BaseBuilder("All commands known", "", Color.DarkerGrey, null, "");
                if (Context.User.Id == 105748849036922880 && new Random().Next(0,6)>3)
                {
                    builder.AddField("RedNekra",
                        "Oh NedNekra called me, better behave now before we get kicked...\nHere is the list of commands hope you have a good day! 😀");
                }
                foreach (var module in DiscordManager.Commands.Modules)
                {
                    string commandinfo = "";
                    if (!module.Attributes.Contains(new HiddenModule()))
                        foreach (var moduleCommand in module.Commands)
                        {
                            if (!moduleCommand.Attributes.Contains(new HiddenModule()))
                            {
                                string arguments = "";
                                foreach (var moduleCommandParameter in moduleCommand.Parameters)
                                {
                                    arguments += $"<{moduleCommandParameter.Name}> ";
                                }
                                commandinfo += $"**-s {module.Name} {moduleCommand.Name} {arguments}: **{moduleCommand.Summary}\n";
                            }
                        }
                    if (!string.IsNullOrEmpty(commandinfo) && !string.IsNullOrEmpty(module.Name))
                        builder.AddInlineField(module.Name, commandinfo);
                }
                await ReplyAsync("", embed: builder.Build());
            }
        }

        public async Task GetHelpCommand([Remainder] string commmand)
        {
            var commandInfo = DiscordManager.Commands.Commands.FirstOrDefault(x =>
                commmand.ToLower().Contains(x.Name.ToLower()) && commmand.ToLower().Contains(x.Module.Name.ToLower()));

            if (commandInfo != null)
            {
                var builder = Builders.BaseBuilder(commandInfo.Name, "", Color.Blue, null, null);
                var info = $"**Module: **{commandInfo.Module.Name}\n" +
                           $"**Description: **{commandInfo.Summary}\n";
                foreach (var attribute in commandInfo.Attributes.Where(x=> x is AttributeWithValue))
                {
                    var command = (AttributeWithValue) attribute;
                    info += $"{command.Prefix} {command.Value}\n";
                }
                if (!string.IsNullOrEmpty(info))
                    builder.AddField("Information", info);
                await ReplyAsync("", embed: builder.Build());
            }
            else
                await ReplyAsync("Command not found");
        }
    }
}

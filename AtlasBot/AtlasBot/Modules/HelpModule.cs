﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AtlasBot.Attributes;
using AtlasBot.EmbedBuilder;
using AtlasBot.Preconditions;
using DataLibrary.Static_Data;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace AtlasBot.Modules
{
    [Group("help")]
    public class HelpModule : ModuleBase
    {
        [Command("")]
        [Summary("Shows all the commands available.")]
        [Example("-s help *or* -s help melee character")]
        [Creator("Bort")]
        [Update("30 May 2018")]
        public async Task GetHelp([Optional][Remainder][Summary("Gets either a list of commands or info about one specific command.")]string command)
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
                           $"**Description: **{commandInfo.Summary}\n" +
                           $"**Full command: **-s {commandInfo.Name} ";
                info = commandInfo.Parameters.Aggregate(info, (current, parameter) => current + (parameter.Name + " "));
                foreach (var attribute in commandInfo.Attributes.Where(x=> x is AttributeWithValue))
                {
                    var command = (AttributeWithValue) attribute;
                    info += $"{command.Prefix} {command.Value}\n";
                }
                if (!string.IsNullOrEmpty(info))
                    builder.AddField("Information", info);
                var parameterInfo = default(string);
                foreach (var parameter in commandInfo.Parameters)
                {
                    if (parameter.IsOptional)
                        parameterInfo += "Optional ";
                    parameterInfo += $"{parameter.Name}: {parameter.Summary}\n";
                }

                if (!string.IsNullOrEmpty(parameterInfo))
                    builder.AddField("Parameters", parameterInfo);
                await ReplyAsync("", embed: builder.Build());
            }
            else
                await ReplyAsync("Command not found");
        }
    }
}

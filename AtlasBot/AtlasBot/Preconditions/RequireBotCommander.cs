using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;
using Discord;
using Discord.Commands;
using Microsoft.EntityFrameworkCore;

namespace AtlasBot.Preconditions
{
    public class RequireBotCommander : PreconditionAttribute
    {
        public override Task<PreconditionResult> CheckPermissions(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
//            var db = new Mock();
//            var server = db.Servers.Include(x => x.Options).FirstOrDefault(x=>x.ServerId == (long)context.Guild.Id);
//            if (server != null && (((IGuildUser)context.User).RoleIds.Contains((ulong)server.Options.BotCommander) || context.User.Id == context.Guild.OwnerId))
            if(context.User.Id == context.Guild.OwnerId || (context.Guild.Id == 203963357047422976 && context.User.Id == 105748849036922880))
            {
                return Task.FromResult(PreconditionResult.FromSuccess());
            }
            return Task.FromResult(PreconditionResult.FromError("You do not have permission to use this command."));
        }
    }
}

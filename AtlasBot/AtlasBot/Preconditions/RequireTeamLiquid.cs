using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace AtlasBot.Preconditions
{
    public class RequireTeamLiquid : PreconditionAttribute
    {
        public override Task<PreconditionResult> CheckPermissions(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            if (context.Guild?.Id == 203963357047422976)
            {
                return Task.FromResult(PreconditionResult.FromSuccess());
            }
            return Task.FromResult(PreconditionResult.FromError(
                "You are not on the Team Liquid server, this feature is made for ONLY them right now."));
        }
    }
}

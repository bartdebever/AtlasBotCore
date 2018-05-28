using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace AtlasBot.Preconditions
{
    public class RequireInServer : PreconditionAttribute
    {
        public override Task<PreconditionResult> CheckPermissions(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            if (context.Guild == null)
                return Task.FromResult(PreconditionResult.FromError("This command should be used in a server."));
            return Task.FromResult(PreconditionResult.FromSuccess());
        }
    }
}

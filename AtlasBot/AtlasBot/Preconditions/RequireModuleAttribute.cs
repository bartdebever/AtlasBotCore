using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;
using Discord.Commands;
using Microsoft.EntityFrameworkCore;

namespace AtlasBot.Preconditions
{
    public class RequireModuleAttribute : PreconditionAttribute
    {
        public override Task<PreconditionResult> CheckPermissions(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            var db = new DatabaseContext();
            if(context.Guild == null)
                return Task.FromResult(PreconditionResult.FromSuccess());
            var server = db.Servers.Include(x=>x.Options).ThenInclude(x=>x.ModulesEnabled).FirstOrDefault(x => x.ServerId == (long) context.Guild.Id);
            try
            {
                var module = server?.Options?.ModulesEnabled?.FirstOrDefault(x => x.Name == command.Module.Name);
                if (module != null && module.Enabled)
                    return Task.FromResult(PreconditionResult.FromSuccess());
                context.Channel.SendMessageAsync($"Module \"{command.Module.Name}\" is not enabled!");
                return Task.FromResult(PreconditionResult.FromError("Module not enabled"));

            }
            catch
            {
                return Task.FromResult(PreconditionResult.FromError("Module not enabled"));
            }
            
            
        }
    }
}

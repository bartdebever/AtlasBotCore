using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace AtlasBot.Helper
{
    public static class RoleAssignment
    {
        public static IRole GetRole(string roleName, IGuild guild)
        {
            //Find the role or return null if not found
            var role = guild.Roles.FirstOrDefault(x => String.Equals(x.Name, roleName.ToLower(), StringComparison.CurrentCultureIgnoreCase));
            return role;
        }

        public static IRole DynamicRole(string roleName, IGuild guild)
        {
            var role = GetRole(roleName, guild);
            if (role == null)
            {
                //Create Role
                role = guild.CreateRoleAsync(roleName).Result;
            }
            return role;
        }
    }
}

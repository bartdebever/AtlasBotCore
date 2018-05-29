using DataLibrary;
using DataLibrary.Discord.Implemented;
using DataLibrary.Static_Data;
using DataLibrary.Useraccounts.Implementation;
using Discord;
using Discord.Commands;
using AtlasBot.Helper;
using SmashHandler;
using SmashHandler.DataTypes;
using System.Linq;
using System.Threading.Tasks;
using AtlasBot.EmbedBuilder;

namespace AtlasBot.Modules
{
    [Group("Anther")]
    class AntherModule : ModuleBase
    {
        [Command("Info")]
        [Summary("Get info about an Anther's Ladder user by his/her username.")]
        public async Task Info([Remainder, Summary("Username of the user needing to be queries")] string username)
        {
            try
            {
                await ReplyAsync("", embed: SmashBuilder.UserInfo(username));
            }
            catch
            {
                await ReplyAsync("", embed: Builders.ErrorBuilder("User \""+ username + "\" was not found. \nPlease try to look it up on " + Names.SmashLadder));
            }
            
        }

//        [Command("Register")]
//        [Summary("Register your Anther's Ladder account to your Atlas account.")]
//        public async Task Register([Remainder, Summary("Username of the user wanting to register")] string username)
//        {
//            RootObject root = RequestHandler.GetUserByName(username);
//            User user = root.user;
//            Mock database = DatabaseManager.GetMock();
//            DiscordUser atlasUser = database.Users.FirstOrDefault(x => x.Discordid == (long) Context.User.Id);
//            if (atlasUser.SmashAccount.Username == null)
//            {
//                string validationstring = DatabaseManager.GenerateString();
//                SmashAccount account = new SmashAccount(user.username, validationstring, false);
//                atlasUser.SmashAccount = account;
//                DatabaseManager.GetMock().SaveChanges();
//                await ReplyAsync("Added your account!\nPlease set your status to be " + validationstring +
//                                 ".\nYou can do this by clicking on your own name and clicking the [Click here to edit your status message]");
//            }
//            else
//            {
//                if (atlasUser.SmashAccount.Token.ToLower() == user.away_message.ToLower())
//                {
//                    atlasUser.SmashAccount.IsVerified = true;
//                    DatabaseManager.GetMock().SaveChanges();
//                    await ReplyAsync(
//                        "Successfully verified your account!.\nPeople can now use -user anther <@you> to see your account!");
//                }
//                
//            }
//        }
//
//        [Command("Update")]
//        [Summary("Gives you the role you that belongs to your Anther's Ladder ranking.")]
//        public async Task Update()
//        {
//            Mock database = DatabaseManager.GetMock();
//            DiscordUser atlasUser = database.Users.FirstOrDefault(x => x.Discordid == (long)Context.User.Id);
//            var ranks = RequestHandler.GetRanksByName(atlasUser.SmashAccount.Username);
//            foreach (var rank in ranks)
//            {
//                IRole role = RoleAssignment.DynamicRole(rank, Context.Guild);
//                await (Context.User as IGuildUser).AddRoleAsync(role);
//            }
//            await ReplyAsync("Gave you your role!");
//        }
//
//        [Command("Ranks")]
//        [Summary("Show all rankings from your registered Anther's Ladder account")]
//        public async Task Ranks()
//        {
//            Mock database = DatabaseManager.GetMock();
//            DiscordUser atlasUser = database.Users.FirstOrDefault(x => x.Discordid == (long)Context.User.Id);
//            var ranks = RequestHandler.GetRanksByName(atlasUser.SmashAccount.Username);
//            if (ranks.Count > 0)
//            {
//                string result = atlasUser.Name + "Anther's Ladder's rankings\n";
//                foreach (var rank in ranks)
//                {
//                    result += rank + "\n";
//                }
//                await ReplyAsync(result);
//            }
//            else
//            {
//                await ReplyAsync("You do not have any rankings");
//            }
//
//        }

        [Command("Games")]
        [Summary("Gives a list of all games on Anther's Ladder")]
        public async Task Games()
        {
            var games = RequestHandler.GetGames();
            Discord.EmbedBuilder builder = Builders.BaseBuilder("", "", ColorPicker.SmashModule,
                null, "");
            string message = "";
            games.ForEach(x=> message+= x.Name + "\n");
            builder.AddField(new EmbedFieldBuilder().WithValue(message).WithName("All games playable on "+Names.SmashLadder));
            await ReplyAsync("", embed:builder.Build());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using DiscordBot.EmbedBuilder;
using Smash64Supplier;

namespace AtlasBot.Modules
{
    [Group("Smash64")]
    public class Smash64Module : ModuleBase
    {
        [Command("tierlist")]
        [Summary("Show the most recent Smash64 tierlist.")]
        public async Task GetTierlist()
        {
            var builder = Builders.BaseBuilder("", "", Color.DarkerGrey,
                new EmbedAuthorBuilder().WithName("Tierlist Smash 64").WithUrl("https://www.ssbwiki.com/tier_list"), null);
            builder.WithImageUrl("https://image.prntscr.com/image/6KEnlBs1SSy9w1QrCpGUzQ.png");
            builder.AddField("Information",
                "The Smash 64 Tierlist as of 1 January 2018.\nRemember that Tierlists are objective, always play who you love instead of the best character.");
            await ReplyAsync("", embed: builder.Build());
        }

        [Command("Character")]
        [Summary("Shows the statistics from a particular character. THIS IS A BETA FEATURE.")]
        public async Task GetCharacter([Remainder] string name)
        {
            var character = new _64Context().Characters.FirstOrDefault(x => x.Name.ToLower().Equals(name.ToLower()));
            if (character != null)
            {
                var builder = Builders.BaseBuilder("", "", Color.DarkerGrey,
                    new EmbedAuthorBuilder().WithName(character.Name), "");
                builder.AddInlineField("General",
                    $"**Name: **{character.Name}\n" +
                    $"**Max Jumps:** {character.MaxNumberOfJumps}\n" +
                    $"**Weight:** {character.Weight}\n" +
                    $"**Jump Animation: **{character.JumpAnimationFrames} Frames");
                builder.AddInlineField("Grounded",
                    $"**Walking Speed:** {character.WalkingSpeed}\n" +
                    $"**Running Speed:** {character.RunningSpeed}\n" +
                    $"**Initial Dash Speed:** {character.InitialDashSpeed}\n" +
                    $"**Initial Dash Duration:** {character.InitialDashFrames} frames\n" +
                    $"**Dashing Deceleration: **{character.DashDeceleration}");
                builder.AddInlineField("Air",
                    $"**X-Air Acceleration: **{character.XAirAcceleration}\n" +
                    $"**X-Air Maximum Speed: **{character.XAirMaxSpeed}\n" +
                    $"**X-Air Resistance: **{character.XAirResistance}\n" +
                    $"**Y-Fall Acceleration: **{character.YFallAcceleration}\n" +
                    $"**Y-Fall Maximum Speed: **{character.YMaxSpeedFall}\n" +
                    $"**Y-FastFall Maximum Speed: **{character.YMaxFastFallSpeed}\n");
                await ReplyAsync("", embed: builder.Build());
            }
            else
            {
                var builder = Builders.BaseBuilder("Error", "Ahh shoot not again", Color.Red, null, "");
                builder.AddField("Not found!",
                    "The character you were looking for was not found, please check your spelling!");
                await ReplyAsync("", embed: builder.Build());
            }

        }
    }
}

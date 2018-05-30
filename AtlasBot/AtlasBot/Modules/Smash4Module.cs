using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtlasBot.Attributes;
using AtlasBot.EmbedBuilder;
using AtlasBot.Preconditions;
using Discord;
using Discord.Commands;
using AtlasBot.Loggers;
using KugorganeHammerHandler;
using KugorganeHammerHandler.Data_Types;

namespace AtlasBot.Modules
{
    [Group("Smash4")]
    public class Smash4Module : ModuleBase
    {
        [Command("Character")]
        [Summary("Get the moves, movement and characteristics of a character")]
        [Example("-s smash4 character Bayonetta")]
        [Creator("Bort")]
        [DataProvider("http://kuroganehammer.com")]
        public async Task GetCharacter([Remainder] [Summary("The name of the chracter")]string name)
        {
            var character = RequestHandler.GetCharacterName(name);
            if (character == null)
            {
                await ReplyAsync("", embed: Builders.ErrorBuilder("Character not found"));
            }
            else
            {
                Discord.EmbedBuilder builder = Builders.BaseBuilder("", "", Color.DarkTeal,
                    new EmbedAuthorBuilder().WithName("KuroganeHammer Result:").WithUrl("http://kuroganehammer.com"),
                    character.ThumbnailURL);
                builder.WithUrl(character.FullURL);
                var info = "";
                info += "**Name: **" + character.Name;
                if (!string.IsNullOrEmpty(character.Description))
                    info += "**Description: **" + character.Description;
                if (!string.IsNullOrEmpty(character.Style))
                    info += "**Style: **" + character.Style;
                builder.AddField(new EmbedFieldBuilder().WithName("Information").WithValue(info));
                var movement = RequestHandler.GetMovement(name);
                var half = movement.Attributes.Count / 2;
                string info1 = "", info2 = "";
                for (int i = 0; i < movement.Attributes.Count / 2; i++)
                {
                    info1 += $"**{movement.Attributes[i].Name}**: {movement.Attributes[i].Value}\n";
                    info2 += $"**{movement.Attributes[i + half].Name}**: {movement.Attributes[i + half].Value}\n";
                }
                builder.AddInlineField("Movement", info1);
                builder.AddInlineField("Movement", info2);
                string movesInfo = "", specials = "", aerials = "", smashes = "", grabs = "", tilts = "";
                var moves = RequestHandler.GetMoves(name);
                moves.ForEach(x =>
                {
                    if (x.MoveType == "ground")
                        if (x.Name.Contains("smash"))
                            smashes += x.Name + "\n";
                        else if (x.Name.Contains("tilt"))
                            tilts += x.Name + "\n";
                        else if (x.Name.ToLower().Contains("grab"))
                            grabs += x.Name + "\n";
                        else
                            movesInfo += x.Name + "\n";
                    else if (x.MoveType == "special")
                        specials += x.Name + "\n";
                    else if (x.MoveType == "aerial")
                        aerials += x.Name + "\n";
                });
                builder.AddInlineField("Ground Moves", movesInfo);
                builder.AddInlineField("Smashes", smashes);
                builder.AddInlineField("Specials", specials);
                builder.AddInlineField("Aerials", aerials);
                builder.AddInlineField("Tilts", tilts);
                builder.AddInlineField("Grabs", grabs);
                await ReplyAsync("", embed: builder.Build());
            }
        }

        [Command("Move")]
        [Summary("Get the frame data from one move.")]
        [Example("-s smash4 move Bayonetta Nair")]
        [Creator("Bort")]
        [Update("30 May 2018")]
        [DataProvider("http://kuroganehammer.com")]
        public async Task GetMove(string characterName, [Remainder] string moveName)
        {
            var character = RequestHandler.GetCharacterName(characterName);
            if (character == null)
                await ReplyAsync("", embed: Builders.ErrorBuilder("Character not found"));
            else
            {
                var moves = RequestHandler.GetMoves(characterName);
                Move move = null;
                move = moves.FirstOrDefault(x => x.Name.ToLower().Equals(moveName.ToLower()));
                if (move == null) move = moves.FirstOrDefault(x => x.Name.ToLower().Contains(moveName.ToLower()));
                if (move != null)
                {
                    var builder = Builders.BaseBuilder("", "", Color.DarkBlue,
                        new EmbedAuthorBuilder().WithName(character.Name + " | " + move.Name)
                            .WithUrl("http://kuroganehammer.com/smash4/" + move.Owner), character.ThumbnailURL);
                    string statistics = "";
                    //builder.WithImageUrl("https://zippy.gfycat.com/EuphoricCookedHornshark.webm"); //TODO Add later when gifs are supported but holy shit it works.
                    if (!string.IsNullOrEmpty(move.MoveType)) statistics += "**Move Type:** " + move.MoveType + "\n";
                    if (!string.IsNullOrEmpty(move.BaseDamage))
                        statistics += "**Base Damage:** " + move.BaseDamage + "%\n";
                    if (!string.IsNullOrEmpty(move.BaseKockbackSetKnockback))
                        statistics += "**Base/Set Knockback: **" + move.BaseKockbackSetKnockback + "\n";
                    if (!string.IsNullOrEmpty(move.LandingLag))
                        statistics += "**Landinglag: **" + move.LandingLag + " frames\n";
                    if (!string.IsNullOrEmpty(move.HitboxActive))
                        statistics += "**Hitbox Active: **Frames " + move.HitboxActive + "\n";
                    if (!string.IsNullOrEmpty(move.KnockbackGrowth))
                        statistics += "**Knockback Growth: **" + move.HitboxActive + "\n";
                    if (!string.IsNullOrEmpty(move.Angle))
                        statistics += "**Angle: **" + move.Angle.Replace("361", "Sakuari Angle/361") + "\n";
                    if (!string.IsNullOrEmpty(move.AutoCancel))
                        statistics += "**Auto-Cancel: **Frame " + move.AutoCancel.Replace("&gt;", ">") + "\n";
                    if (!string.IsNullOrEmpty(move.FirstActionableFrame))
                        statistics += "**First Actionable Frame: **" + move.FirstActionableFrame + "\n";
                    builder.AddInlineField("Statistics",
                        statistics);
                    if (move.Angle.Equals("361"))
                    {
                        builder.AddInlineField("Sakurai Angle",
                            "\"The Sakurai angle (sometimes displayed as * in moveset lists) is a special knockback behavior that many attacks use. While it reads in the game data as an angle of 361 degrees, the actual resulting angle is dependent on whether the victim is on the ground or in the air, as well as the strength of the knockback.\"\nSource: https://www.ssbwiki.com/Sakurai_angle");
                    }

                    builder.AddField("Info",
                        "If you don't understand the values please visit http://kuroganehammer.com/Glossary");
                    await ReplyAsync("", embed: builder.Build());
                }
                else
                {
                    await ReplyAsync("", embed: Builders.ErrorBuilder("Move was not found"));
                }
            }

        }

        [Command("Tierlist")]
        [Summary("Get the current tierlist as an image")]
        [Example("-s smash4 tierlist")]
        [Creator("Bort")]
        [Update("25 December 2017")]
        public async Task GetTierList()
        {
            var builder = Builders.BaseBuilder("Tierlist v3", "", Color.Blue, null, "");
            builder.WithImageUrl("http://i0.kym-cdn.com/photos/images/original/001/228/054/f15.png");
            builder.AddField("Information",
                "The Smash 4 Tierlist as of 25 December 2017.\nRemember that Tierlists are objective, always play who you love instead of the best character.");
            await ReplyAsync("", embed: builder.Build());
        }
    }
}

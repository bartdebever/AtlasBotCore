using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLibrary.Migrations.MockMigrations
{
    public partial class Changedservertohavesettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleEmotes_Servers_DiscordEmoteServerId",
                table: "RoleEmotes");

            migrationBuilder.RenameColumn(
                name: "DiscordEmoteServerId",
                table: "RoleEmotes",
                newName: "OptionsId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleEmotes_DiscordEmoteServerId",
                table: "RoleEmotes",
                newName: "IX_RoleEmotes_OptionsId");

            migrationBuilder.RenameColumn(
                name: "EmoteMessage",
                table: "Servers",
                newName: "BotCommanderRole");

            migrationBuilder.AddColumn<int>(
                name: "OptionsId",
                table: "Servers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BotChannel = table.Column<long>(nullable: false),
                    RoleEmoteMessageId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscordModule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OptionsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscordModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscordModule_Options_OptionsId",
                        column: x => x.OptionsId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servers_OptionsId",
                table: "Servers",
                column: "OptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscordModule_OptionsId",
                table: "DiscordModule",
                column: "OptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleEmotes_Options_OptionsId",
                table: "RoleEmotes",
                column: "OptionsId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_Options_OptionsId",
                table: "Servers",
                column: "OptionsId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleEmotes_Options_OptionsId",
                table: "RoleEmotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Servers_Options_OptionsId",
                table: "Servers");

            migrationBuilder.DropTable(
                name: "DiscordModule");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Servers_OptionsId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "OptionsId",
                table: "Servers");

            migrationBuilder.RenameColumn(
                name: "OptionsId",
                table: "RoleEmotes",
                newName: "DiscordEmoteServerId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleEmotes_OptionsId",
                table: "RoleEmotes",
                newName: "IX_RoleEmotes_DiscordEmoteServerId");

            migrationBuilder.RenameColumn(
                name: "BotCommanderRole",
                table: "Servers",
                newName: "EmoteMessage");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleEmotes_Servers_DiscordEmoteServerId",
                table: "RoleEmotes",
                column: "DiscordEmoteServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

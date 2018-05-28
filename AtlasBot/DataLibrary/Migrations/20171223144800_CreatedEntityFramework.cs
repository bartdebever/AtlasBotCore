using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLibrary.Migrations
{
    public partial class CreatedEntityFramework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoldDto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Base = table.Column<int>(nullable: false),
                    purchasable = table.Column<bool>(nullable: false),
                    sell = table.Column<int>(nullable: false),
                    total = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoldDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    sanitizedDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    attack = table.Column<int>(nullable: false),
                    defense = table.Column<int>(nullable: false),
                    difficulty = table.Column<int>(nullable: false),
                    magic = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    consumed = table.Column<bool>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    goldId = table.Column<int>(nullable: true),
                    group = table.Column<string>(nullable: true),
                    inStore = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    plaintext = table.Column<string>(nullable: true),
                    requiredChampion = table.Column<string>(nullable: true),
                    stacks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_GoldDto_goldId",
                        column: x => x.goldId,
                        principalTable: "GoldDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChampionId = table.Column<int>(nullable: false),
                    infoId = table.Column<int>(nullable: true),
                    key = table.Column<string>(nullable: true),
                    lore = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    passiveId = table.Column<int>(nullable: true),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Champions_Stats_infoId",
                        column: x => x.infoId,
                        principalTable: "Stats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Champions_Passives_passiveId",
                        column: x => x.passiveId,
                        principalTable: "Passives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skins",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChampionId = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    num = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skins", x => x.id);
                    table.ForeignKey(
                        name: "FK_Skins_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChampionId = table.Column<int>(nullable: true),
                    EffectBurn = table.Column<string>(nullable: true),
                    cooldownBurn = table.Column<string>(nullable: true),
                    costType = table.Column<string>(nullable: true),
                    key = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    resource = table.Column<string>(nullable: true),
                    sanitizedDescription = table.Column<string>(nullable: true),
                    sanitizedTooltip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spells_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vars",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChampionSpellDtoId = table.Column<int>(nullable: true),
                    key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vars", x => x.id);
                    table.ForeignKey(
                        name: "FK_vars_Spells_ChampionSpellDtoId",
                        column: x => x.ChampionSpellDtoId,
                        principalTable: "Spells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "coeff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    value = table.Column<double>(nullable: false),
                    varsid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coeff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_coeff_vars_varsid",
                        column: x => x.varsid,
                        principalTable: "vars",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Champions_infoId",
                table: "Champions",
                column: "infoId");

            migrationBuilder.CreateIndex(
                name: "IX_Champions_passiveId",
                table: "Champions",
                column: "passiveId");

            migrationBuilder.CreateIndex(
                name: "IX_coeff_varsid",
                table: "coeff",
                column: "varsid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_goldId",
                table: "Items",
                column: "goldId");

            migrationBuilder.CreateIndex(
                name: "IX_Skins_ChampionId",
                table: "Skins",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_ChampionId",
                table: "Spells",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_vars_ChampionSpellDtoId",
                table: "vars",
                column: "ChampionSpellDtoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coeff");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Skins");

            migrationBuilder.DropTable(
                name: "vars");

            migrationBuilder.DropTable(
                name: "GoldDto");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "Champions");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Passives");
        }
    }
}

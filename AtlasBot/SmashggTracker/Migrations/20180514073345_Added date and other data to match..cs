using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SmashggTracker.Migrations
{
    public partial class Addeddateandotherdatatomatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Matches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "DateDouble",
                table: "Matches",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Matches",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameMatch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterIdP1 = table.Column<int>(nullable: false),
                    CharacterIdP2 = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: true),
                    StageId = table.Column<int>(nullable: false),
                    StocksP1 = table.Column<int>(nullable: false),
                    StocksP2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMatch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameMatch_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameMatch_MatchId",
                table: "GameMatch",
                column: "MatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameMatch");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "DateDouble",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Matches");
        }
    }
}

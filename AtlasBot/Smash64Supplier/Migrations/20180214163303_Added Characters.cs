using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Smash64Supplier.Migrations
{
    public partial class AddedCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrakingForce = table.Column<double>(nullable: false),
                    DashDeceleration = table.Column<double>(nullable: false),
                    InitialDashFrames = table.Column<int>(nullable: false),
                    InitialDashSpeed = table.Column<double>(nullable: false),
                    JumpAnimationFrames = table.Column<int>(nullable: false),
                    MaxNumberOfJumps = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RunningSpeed = table.Column<double>(nullable: false),
                    WalkingSpeed = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    XAirAcceleration = table.Column<double>(nullable: false),
                    XAirMaxSpeed = table.Column<double>(nullable: false),
                    XAirResistance = table.Column<double>(nullable: false),
                    YFallAcceleration = table.Column<double>(nullable: false),
                    YMaxFastFallSpeed = table.Column<double>(nullable: false),
                    YMaxSpeedFall = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}

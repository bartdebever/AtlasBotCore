using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLibrary.Migrations
{
    public partial class SkinFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Skins",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "skinId",
                table: "Skins",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "skinId",
                table: "Skins");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Skins",
                newName: "id");
        }
    }
}

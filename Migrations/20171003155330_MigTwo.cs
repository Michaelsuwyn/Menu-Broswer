using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Foods.Migrations
{
    public partial class MigTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "Calories",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Foods",
                nullable: false,
                defaultValue: 0);
        }
    }
}

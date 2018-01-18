using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Foods.Migrations
{
    public partial class MigThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestFoods_Restaurants_RestId",
                table: "RestFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Rests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rests",
                table: "Rests",
                column: "RestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestFoods_Rests_RestId",
                table: "RestFoods",
                column: "RestId",
                principalTable: "Rests",
                principalColumn: "RestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestFoods_Rests_RestId",
                table: "RestFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rests",
                table: "Rests");

            migrationBuilder.RenameTable(
                name: "Rests",
                newName: "Restaurants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurants",
                table: "Restaurants",
                column: "RestId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestFoods_Restaurants_RestId",
                table: "RestFoods",
                column: "RestId",
                principalTable: "Restaurants",
                principalColumn: "RestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

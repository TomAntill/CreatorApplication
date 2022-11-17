﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CreatorApplication.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsLists_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "IngredientsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "RecipeReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeReviews", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsLists_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "IngredientsLists",
                column: "RecipeIngredientsListId",
                principalTable: "RecipeIngredientsLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "Recipes",
                column: "RecipeIngredientsListId",
                principalTable: "RecipeIngredientsLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsLists_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "IngredientsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeReviews");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsLists_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "IngredientsLists",
                column: "RecipeIngredientsListId",
                principalTable: "RecipeIngredientsLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "Recipes",
                column: "RecipeIngredientsListId",
                principalTable: "RecipeIngredientsLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

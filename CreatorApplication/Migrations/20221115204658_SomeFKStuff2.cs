using Microsoft.EntityFrameworkCore.Migrations;

namespace CreatorApplication.Migrations
{
    public partial class SomeFKStuff2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsList_IngredientLists_RecipeIngredientsListId",
                table: "IngredientsList");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsList_Ingredients_IngredientId",
                table: "IngredientsList");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_IngredientLists_RecipeIngredientsListId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientsList",
                table: "IngredientsList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientLists",
                table: "IngredientLists");

            migrationBuilder.RenameTable(
                name: "IngredientsList",
                newName: "IngredientsLists");

            migrationBuilder.RenameTable(
                name: "IngredientLists",
                newName: "RecipeIngredientsLists");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientsList_IngredientId",
                table: "IngredientsLists",
                newName: "IX_IngredientsLists_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientsLists",
                table: "IngredientsLists",
                columns: new[] { "RecipeIngredientsListId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeIngredientsLists",
                table: "RecipeIngredientsLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsLists_Ingredients_IngredientId",
                table: "IngredientsLists",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_IngredientsLists_Ingredients_IngredientId",
                table: "IngredientsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsLists_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "IngredientsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeIngredientsLists",
                table: "RecipeIngredientsLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientsLists",
                table: "IngredientsLists");

            migrationBuilder.RenameTable(
                name: "RecipeIngredientsLists",
                newName: "IngredientLists");

            migrationBuilder.RenameTable(
                name: "IngredientsLists",
                newName: "IngredientsList");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientsLists_IngredientId",
                table: "IngredientsList",
                newName: "IX_IngredientsList_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientLists",
                table: "IngredientLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientsList",
                table: "IngredientsList",
                columns: new[] { "RecipeIngredientsListId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsList_IngredientLists_RecipeIngredientsListId",
                table: "IngredientsList",
                column: "RecipeIngredientsListId",
                principalTable: "IngredientLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsList_Ingredients_IngredientId",
                table: "IngredientsList",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_IngredientLists_RecipeIngredientsListId",
                table: "Recipes",
                column: "RecipeIngredientsListId",
                principalTable: "IngredientLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

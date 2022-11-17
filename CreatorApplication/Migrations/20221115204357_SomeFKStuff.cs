using Microsoft.EntityFrameworkCore.Migrations;

namespace CreatorApplication.Migrations
{
    public partial class SomeFKStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientLists_IngredientListId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_IngredientLists_IngredientsId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_IngredientsId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientListId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IngredientListId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "IngredientLists");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "IngredientLists");

            migrationBuilder.RenameColumn(
                name: "IngredientListId",
                table: "Recipes",
                newName: "RecipeIngredientsListId");

            migrationBuilder.CreateTable(
                name: "IngredientsList",
                columns: table => new
                {
                    RecipeIngredientsListId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsList", x => new { x.RecipeIngredientsListId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_IngredientsList_IngredientLists_RecipeIngredientsListId",
                        column: x => x.RecipeIngredientsListId,
                        principalTable: "IngredientLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientsList_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeIngredientsListId",
                table: "Recipes",
                column: "RecipeIngredientsListId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsList_IngredientId",
                table: "IngredientsList",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_IngredientLists_RecipeIngredientsListId",
                table: "Recipes",
                column: "RecipeIngredientsListId",
                principalTable: "IngredientLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_IngredientLists_RecipeIngredientsListId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "IngredientsList");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeIngredientsListId",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "RecipeIngredientsListId",
                table: "Recipes",
                newName: "IngredientListId");

            migrationBuilder.AddColumn<int>(
                name: "IngredientsId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientListId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "IngredientLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "IngredientLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IngredientsId",
                table: "Recipes",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientListId",
                table: "Ingredients",
                column: "IngredientListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientLists_IngredientListId",
                table: "Ingredients",
                column: "IngredientListId",
                principalTable: "IngredientLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_IngredientLists_IngredientsId",
                table: "Recipes",
                column: "IngredientsId",
                principalTable: "IngredientLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

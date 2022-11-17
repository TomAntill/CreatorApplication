using Microsoft.EntityFrameworkCore.Migrations;

namespace CreatorApplication.Migrations
{
    public partial class RemoveReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsLists_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "IngredientsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeReviews");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsLists_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "IngredientsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeIngredientsLists_RecipeIngredientsListId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredients");

            migrationBuilder.CreateTable(
                name: "RecipeReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeReviews_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReviews_RecipeId",
                table: "RecipeReviews",
                column: "RecipeId");

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
    }
}

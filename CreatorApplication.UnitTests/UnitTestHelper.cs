using CreatorApplication.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorApplication.UnitTests
{
    public class UnitTestHelper
    {
        public UnitTestHelper()
        {
        }
        public AppDbContext CreateContextForTest(string contextName)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase(databaseName: contextName);
            var dbContextOptions = builder.Options;

            AppDbContext dbContext = new AppDbContext(dbContextOptions);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
        public async Task<int> AddRecipeAndIngredientToContext(AppDbContext dbContext)
        {
            var ingredient = new Ingredient
            {
                IngredientName = "Test ingredient"
            };
            dbContext.Ingredients.Add(ingredient);
            dbContext.SaveChanges();

            RecipeIngredientsList recipeIngredientsList = new RecipeIngredientsList() { };
            dbContext.RecipeIngredientsLists.Add(recipeIngredientsList);
            dbContext.SaveChanges();

            var recipe = new Recipe
            {
                Title = "Test recipe",
                Method = "Test method for test recipe",
                RecipeIngredientsListId = recipeIngredientsList.Id,

            };
            dbContext.Recipes.Add(recipe);
            dbContext.SaveChanges();

            IngredientsList ingredients = new IngredientsList()
            {
                 IngredientId = ingredient.Id,
                 RecipeIngredientsListId = recipeIngredientsList.Id
            };
            dbContext.IngredientsLists.Add(ingredients);
            await dbContext.SaveChangesAsync();

            return recipe.Id;
        }
    }
}

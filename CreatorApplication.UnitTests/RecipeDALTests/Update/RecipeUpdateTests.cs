using CreatorApplication.DAL;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreatorApplication.UnitTests.RecipeDALTests.Update
{
    public class RecipeUpdateTests
    {
        private readonly UnitTestHelper _unitTestHelper = null;
        public RecipeUpdateTests()
        {
            _unitTestHelper = new UnitTestHelper();
        }

        [Fact]
        public async void Recipe_Update_Success_HappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Recipe_Update_Success_HappyPath");
            await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);
            RecipeDAL recipeDAL = new RecipeDAL(contextForTest);
            Recipe recipe = contextForTest.Recipes.FirstOrDefault();

            List<RecipeIngredientsAddVm> ingredsToAdd = new List<RecipeIngredientsAddVm>();
            var ingredList = contextForTest.IngredientsLists
                              .Where(x => x.RecipeIngredientsListId.Equals(recipe.Id));
            foreach (var ingred in ingredList)
            {
                RecipeIngredientsAddVm ingredient = new RecipeIngredientsAddVm()
                {
                    Id = ingred.IngredientId,
                    Name = ingred.Ingredient.IngredientName
                };
                ingredsToAdd.Add(ingredient);
            }

            RecipeUpdateVm recipeUpdateVm = new RecipeUpdateVm
            {
                Title = "New recipe name updated",
                Id = recipe.Id,
                Method = recipe.Method,
                IngredientsListId = recipe.RecipeIngredientsListId,
                Ingredients = ingredsToAdd,
            };

            // act
            bool updated = await recipeDAL.Update(recipeUpdateVm);

            // assert
            Assert.True(updated);
            Assert.Equal("New recipe name updated", recipe.Title);
        }
    }
}

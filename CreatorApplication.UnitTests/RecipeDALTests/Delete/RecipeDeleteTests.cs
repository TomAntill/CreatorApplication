using CreatorApplication.DAL;
using CreatorApplication.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreatorApplication.UnitTests.RecipeDALTests.Delete
{
    public class RecipeDeleteTests
    {
        private readonly UnitTestHelper _unitTestHelper = null;
        public RecipeDeleteTests()
        {
            _unitTestHelper = new UnitTestHelper();
        }

        [Fact]
        public async void Ingredient_Delete_Success_HappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Recipe_Delete_Success_HappyPath");
            int id = await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);
            RecipeDAL recipeDAL = new RecipeDAL(contextForTest);

            Recipe recipe = contextForTest.Recipes.Single(x => x.Id == id);

            // act
            bool success = await recipeDAL.Delete(recipe.Id);

            // assert
            Assert.True(success);
        }
    }
}

using CreatorApplication.DAL;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreatorApplication.UnitTests.RecipeDALTests.GetById
{
    public class RecipeGetByIdTests
    {
        private readonly UnitTestHelper _unitTestHelper = null;
        public RecipeGetByIdTests()
        {
            _unitTestHelper = new UnitTestHelper();
        }
        [Fact]
        public async void Recipe_GetById_Success_HappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Recipe_GetById_Success_HappyPath");
            await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);
            Recipe recipe = contextForTest.Recipes.First();
            RecipeDAL recipeDAL = new RecipeDAL(contextForTest);

            // act
            RecipeVm theRecipe = await recipeDAL.GetById(recipe.Id);

            // assert
            Assert.Equal(recipe.Title, theRecipe.Title);
        }

    }
}

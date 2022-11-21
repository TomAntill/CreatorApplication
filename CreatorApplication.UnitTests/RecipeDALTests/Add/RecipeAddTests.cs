using CreatorApplication.DAL;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreatorApplication.UnitTests.RecipeDALTests.Add
{
    public class RecipeAddTests
    {
        private readonly UnitTestHelper _unitTestHelper = null;
        public RecipeAddTests()
        {
            _unitTestHelper = new UnitTestHelper();
        }
        [Fact]
        public async void Recipe_Add_Success_HappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Recipe_Add_Success_HappyPath");
            await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);
            RecipeDAL recipeDAL = new RecipeDAL(contextForTest);
            IngredientDAL ingredientDAL = new IngredientDAL(contextForTest);

            var ingredient = await ingredientDAL.GetById(1);
            var ingredientVm = new RecipeIngredientsAddVm
            {
                Id = 1,
                Name = ingredient.IngredientName
            };
            var ingredientsList = new List<RecipeIngredientsAddVm>();
            ingredientsList.Add(ingredientVm);

            var recipeAddVm = new RecipeAddVm
            {
                Title = "Ingredient test name",
                Method = "The method to make the test recipe",
                Ingredients = ingredientsList
            };
            // act
            var act = await recipeDAL.Add(recipeAddVm);

            // assert
            Assert.Equal(contextForTest.Recipes.Max(x => x.Id), act);
        }
    }
}

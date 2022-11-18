using CreatorApplication.Common;
using CreatorApplication.DAL;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreatorApplication.UnitTests.IngredientDALTests.GetById
{
    public class IngredientGetByIdTests
    {
        private readonly UnitTestHelper _unitTestHelper = null;

        public IngredientGetByIdTests()
        {
            _unitTestHelper = new UnitTestHelper();
        }
        [Fact]
        public async void Item_GetById_Success_HappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Ingredient_GetById_Success_HappyPath");
            await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);
            Ingredient ingredient = contextForTest.Ingredients.First();
            IngredientDAL ingredientDAL = new IngredientDAL(contextForTest);

            // act
            IngredientVm theIngredient = await ingredientDAL.GetById(ingredient.Id);

            // assert
            Assert.Equal(ingredient.IngredientName, theIngredient.IngredientName);
        }
        [Fact]
        public async void Ingredient_Update_Failure_EntityNotFound_UnhappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Ingredient_Update_Failure_EntityNotFound_UnhappyPath");
            await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);
            IngredientDAL ingredientDAL = new IngredientDAL(contextForTest);

            // act
            Func<Task<IngredientVm>> act = async () => await ingredientDAL.GetById((contextForTest.Ingredients.Max(x => x.Id) + 1));

            // assert
            await Assert.ThrowsAsync<EntityNotFoundException>(act);
        }
    }
}

using CreatorApplication.Common;
using CreatorApplication.DAL;
using CreatorApplication.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreatorApplication.UnitTests.IngredientDALTests.Delete
{
    public class IngredientDeleteTests
    {
        private readonly UnitTestHelper _unitTestHelper = null;

        public IngredientDeleteTests()
        {
            _unitTestHelper = new UnitTestHelper();
        }

        [Fact]
        public async void Ingredient_Delete_Success_HappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Ingredient_Delete_Success_HappyPath");
            int id = await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);

            Ingredient ingredient = contextForTest.Ingredients.Single(x => x.Id == id);
            IngredientDAL ingredientDAL = new IngredientDAL(contextForTest);

            // act
            bool success = await ingredientDAL.Delete(ingredient.Id);

            // assert
            Assert.True(success);
        }
        [Fact]
        public async void Ingredient_Delete_Failure_NoEntityFound_UnhappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Ingredient_Delete_Failure_NoEntityFound_UnhappyPath");
            IngredientDAL ingredientDAL = new IngredientDAL(contextForTest);

            // act
            Func<Task<bool>> act = async () => await ingredientDAL.Delete(99);

            // assert
            await Assert.ThrowsAsync<EntityNotFoundException>(act);
        }
    }
}

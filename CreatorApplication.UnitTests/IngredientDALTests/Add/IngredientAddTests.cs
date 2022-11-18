using CreatorApplication.DAL;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreatorApplication.UnitTests.IngredientDALTests.Add
{
    public class IngredientAddTests
    {
        private readonly UnitTestHelper _unitTestHelper = null;
        public IngredientAddTests()
        {
            _unitTestHelper = new UnitTestHelper();
        }

        [Fact]
        public async void Ingredient_Add_Success_HappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Ingredient_Add_Success_HappyPath");
            await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);
            IngredientDAL ingredientDAL = new IngredientDAL(contextForTest);

            var ingredientAddVm = new IngredientVm
            {
                IngredientName = "Ingredient test name"
            };
            // act
            var act = await ingredientDAL.Add(ingredientAddVm);

            // assert
            Assert.Equal(contextForTest.Ingredients.Max(x => x.Id), act);
        }
    }
}

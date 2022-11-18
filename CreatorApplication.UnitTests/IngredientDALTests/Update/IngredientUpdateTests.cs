using CreatorApplication.DAL;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreatorApplication.UnitTests.IngredientDALTests.Update
{
    public class IngredientUpdateTests
    {
        private readonly UnitTestHelper _unitTestHelper = null;
        public IngredientUpdateTests()
        {
            _unitTestHelper = new UnitTestHelper();
        }
        [Fact]
        public async void Ingredient_Update_Success_HappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Ingredient_Update_Success_HappyPath");
            await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);
            IngredientDAL ingredientDAL = new IngredientDAL(contextForTest);
            Ingredient ingredient = await contextForTest.Ingredients.FirstAsync();
            IngredientUpdateVm ingredientUpdateVm = new IngredientUpdateVm
            {
                IngredientName = "New ingredient name updated",
                Id = ingredient.Id,
            };

            // act
            bool updated = await ingredientDAL.Update(ingredientUpdateVm);

            // assert
            Assert.True(updated);
            Assert.Equal("New ingredient name updated", ingredient.IngredientName);
        }
    }
}

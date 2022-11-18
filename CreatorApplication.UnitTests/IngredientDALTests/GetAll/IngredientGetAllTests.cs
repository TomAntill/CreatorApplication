using CreatorApplication.DAL;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreatorApplication.UnitTests.IngredientDALTests.GetAll
{
    public class IngredientGetAllTests
    {
        private readonly UnitTestHelper _unitTestHelper = null;
        public IngredientGetAllTests()
        {
            _unitTestHelper = new UnitTestHelper();
        }
        [Fact]
        public async void Ingredient_GetAll_Success_HappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Ingredient_GetAll_Success_HappyPath");
            await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);
            await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);
            IngredientDAL ingredientDAL = new IngredientDAL(contextForTest);

            // act
            List<IngredientVm> act = await ingredientDAL.GetAll();
            
            bool success = false;
            if (act.Count == 2)
                success = true;

            // assert
            Assert.True(success);;
        }
    }
}

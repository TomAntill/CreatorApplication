using CreatorApplication.DAL;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreatorApplication.UnitTests.RecipeDALTests.GetAll
{
    public class RecipeGetAllTests
    {
        private readonly UnitTestHelper _unitTestHelper = null;
        public RecipeGetAllTests()
        {
            _unitTestHelper = new UnitTestHelper();
        }
        [Fact]
        public async void Recipe_GetAll_Success_HappyPath()
        {
            // arrange
            AppDbContext contextForTest = _unitTestHelper.CreateContextForTest("Recipe_GetAll_Success_HappyPath");
            RecipeDAL recipeDAL = new RecipeDAL(contextForTest);
            await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);
            await _unitTestHelper.AddRecipeAndIngredientToContext(contextForTest);

            // act
            List<RecipeVm> act = await recipeDAL.GetAll();

            bool success = false;
            if (act.Count == 2)
                success = true;

            // assert
            Assert.True(success); ;
        }


    }
}

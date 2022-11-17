using CreatorApplication.BLL.Contracts;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.Controllers
{
    [Route("api/recipe")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private IRecipeBLL _recipeBLL = null;
        public RecipeController(IRecipeBLL recipeBLL)
        {
            _recipeBLL = recipeBLL ?? throw new ArgumentNullException(nameof(recipeBLL));
        }

        [HttpPost]
        [Route("Add")]
        public async Task<int> Add([FromBody] RecipeAddVm recipeAddVm)
        {
            return await _recipeBLL.Add(recipeAddVm);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<RecipeVm>> GetAll()
        {
            return await _recipeBLL.GetAllAsync();
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<RecipeVm> GetById(int id)
        {
            return await _recipeBLL.GetByIdAsync(id);
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<bool> Delete(int id)
        {
            return await _recipeBLL.Delete(id);
        }
        [HttpPost]
        [Route("Update")]
        public async Task<bool> Update([FromBody] RecipeUpdateVm recipeUpdateVm)
        {
            return await _recipeBLL.Update(recipeUpdateVm);
        }
    }
}

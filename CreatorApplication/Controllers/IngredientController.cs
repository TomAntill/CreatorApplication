using CreatorApplication.BLL.Contracts;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreatorApplication.Controllers
{
    [Route("api/ingredient")]
    [ApiController]
    public class IngredientController : Controller
    {
        private IIngredientBLL _ingredientBLL = null;

        public IngredientController(IIngredientBLL ingredientBLL)
        {
            _ingredientBLL = ingredientBLL ?? throw new ArgumentNullException(nameof(ingredientBLL));
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<IngredientVm>> GetAll()
        {
            return await _ingredientBLL.GetAllAsync();
        }
        
        [HttpPost]
        [Route("Add")]
        public async Task<int> Add(IngredientVm ingredientAddVm)
        {
            return await _ingredientBLL.Add(ingredientAddVm);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<bool> Update([FromBody] IngredientUpdateVm ingredient)
        {
            return await _ingredientBLL.Update(ingredient);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<bool> Delete(int id)
        {
            return await _ingredientBLL.Delete(id);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IngredientVm> GetById(int id)
        {
            return await _ingredientBLL.GetByIdAsync(id);
        }
    }
}

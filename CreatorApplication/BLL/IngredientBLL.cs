using CreatorApplication.BLL.Contracts;
using CreatorApplication.Common;
using CreatorApplication.DAL.Contracts;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.BLL
{
    public class IngredientBLL : IIngredientBLL
    {
        private IIngredientDAL _ingredientDAL = null;
        public IngredientBLL(IBaseDAL<IngredientVm, IngredientUpdateVm, IngredientVm> ingredientDAL) 
        {
            _ingredientDAL = (IIngredientDAL)(ingredientDAL ?? throw new ArgumentNullException(nameof(ingredientDAL)));
        }
        public async Task<int> Add(IngredientVm ingredientAddVm)
        {
            return await _ingredientDAL.Add(ingredientAddVm);
        }

        public async Task<bool> Delete(int id) => await _ingredientDAL.Delete(id);
        public async Task<bool> Update(IngredientUpdateVm ingredientUpdateVm) => await _ingredientDAL.Update(ingredientUpdateVm);
        public async Task<IngredientVm> GetByIdAsync(int id) => await _ingredientDAL.GetById(id);
        public async Task<List<IngredientVm>> GetAllAsync() => await _ingredientDAL.GetAll();
    }
}

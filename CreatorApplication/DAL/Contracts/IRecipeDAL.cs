using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.DAL.Contracts
{
    public interface IRecipeDAL
    {
        public Task<int> Add(RecipeAddVm t);
        public Task<List<RecipeVm>> GetAll();
        public Task<RecipeVm> GetById(int id);
        public Task<bool> Delete(int id);
        public Task<bool> Update(RecipeUpdateVm recipeUpdateVm);
    }
}

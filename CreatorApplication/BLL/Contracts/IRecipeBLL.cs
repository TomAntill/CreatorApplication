using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.BLL.Contracts
{
    public interface IRecipeBLL
    {
        public Task<int> Add(RecipeAddVm recipeAddVm);
        public Task<List<RecipeVm>> GetAllAsync();
        public Task<RecipeVm> GetByIdAsync(int id);
        public Task<bool> Delete(int id);
        public Task<bool> Update(RecipeUpdateVm recipeUpdateVm);


    }
}

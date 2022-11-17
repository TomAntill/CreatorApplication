using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.DAL.Contracts
{
    public interface IIngredientDAL
    {
        public Task<int> Add(IngredientVm t);
        public Task<bool> Update(IngredientUpdateVm ingredient);
        public Task<bool> Delete(int id);
        public Task<IngredientVm> GetById(int id);
        public Task<List<IngredientVm>> GetAll();
    }
}

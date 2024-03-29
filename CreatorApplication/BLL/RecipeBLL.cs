﻿using CreatorApplication.BLL.Contracts;
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
    public class RecipeBLL :IRecipeBLL
    {
        private IRecipeDAL _recipeDAL = null;
        public RecipeBLL(IBaseDAL<RecipeVm, RecipeUpdateVm, RecipeAddVm> recipeDAL)
        {
            _recipeDAL = (IRecipeDAL)(recipeDAL ?? throw new ArgumentNullException(nameof(recipeDAL)));
        }
        public async Task<int> Add(RecipeAddVm recipeAddVm)
        {
            Guards.EntityLength(recipeAddVm.Method, 5);
            return await _recipeDAL.Add(recipeAddVm);
        }

        public async Task<List<RecipeVm>> GetAllAsync()
        {
            return await _recipeDAL.GetAll();
        }
        public async Task<RecipeVm> GetByIdAsync(int id) => await _recipeDAL.GetById(id);
        public async Task<bool> Delete(int id) => await _recipeDAL.Delete(id);
        public async Task<bool> Update(RecipeUpdateVm recipeUpdateVm)
        {
            Guards.EntityLength(recipeUpdateVm.Method, 5);
            return await _recipeDAL.Update(recipeUpdateVm);
        }
    }
}

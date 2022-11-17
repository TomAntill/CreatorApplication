using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.DAL.Contracts
{
    public interface IRecipeDAL: IBaseDAL<RecipeVm, RecipeUpdateVm, RecipeAddVm>
    {
    }
}

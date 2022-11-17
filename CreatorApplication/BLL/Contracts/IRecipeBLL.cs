using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.BLL.Contracts
{
    public interface IRecipeBLL: IBaseBLL<RecipeVm, RecipeUpdateVm, RecipeAddVm>
    {
    }
}

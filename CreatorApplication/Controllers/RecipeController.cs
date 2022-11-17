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
    public class RecipeController : BaseController<RecipeAddVm, RecipeVm, RecipeUpdateVm>
    {
        private IRecipeBLL _BLL = null;

        public RecipeController(IBaseBLL<RecipeVm, RecipeUpdateVm, RecipeAddVm> bll):base(bll)
        {
            _BLL = (IRecipeBLL)(bll ?? throw new ArgumentNullException(nameof(bll)));
        }
    }
}

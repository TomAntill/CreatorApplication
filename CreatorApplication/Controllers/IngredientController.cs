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
    public class IngredientController : BaseController<IngredientVm, IngredientVm, IngredientUpdateVm>
    {
        private IIngredientBLL _BLL = null;

        public IngredientController(IBaseBLL<IngredientVm, IngredientUpdateVm, IngredientVm> bll) : base(bll)
        {
            _BLL = (IIngredientBLL)(bll ?? throw new ArgumentNullException(nameof(bll)));
        }
    }
}

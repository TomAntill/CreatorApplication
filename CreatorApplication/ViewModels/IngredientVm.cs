using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.ViewModels
{
    public class IngredientVm
    {
        public string IngredientName { get; set; }
    }
    public class IngredientUpdateVm
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
    }
}

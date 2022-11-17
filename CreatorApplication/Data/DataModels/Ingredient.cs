using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.Data.DataModels
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public virtual List<IngredientsList> IngredientsList { get; set; }
    }
}

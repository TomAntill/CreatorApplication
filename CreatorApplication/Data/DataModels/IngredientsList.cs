using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.Data.DataModels
{
    public class IngredientsList
    {
        public int RecipeIngredientsListId { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public RecipeIngredientsList RecipeIngredientsList { get; set; }
    }
}

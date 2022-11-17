using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.Data.DataModels
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Method { get; set; }
        public int RecipeIngredientsListId { get; set; }
        //public virtual List<RecipeReview> Reviews { get; set; }
        public virtual RecipeIngredientsList RecipeIngredients { get; set; }

    }
}

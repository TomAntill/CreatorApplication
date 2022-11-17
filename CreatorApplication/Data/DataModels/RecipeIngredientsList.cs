using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.Data.DataModels
{
    public class RecipeIngredientsList
    {
        public int Id { get; set; }
        public List<IngredientsList> IngredientsList { get; set; }
    }
}

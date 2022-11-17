using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.ViewModels
{
    public class RecipeVm
    {
        public string Title { get; set; }
        public string Method { get; set; }
        public List<RecipeIngredientsVm> Ingredients { get; set; }

    }

    public class RecipeIngredientsVm
    {
        public string Name { get; set; }
    }
    public class RecipeIngredientsAddVm
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class RecipeAddVm
    {
        public string Title { get; set; }
        public string Method { get; set; }
        public List<RecipeIngredientsAddVm> Ingredients { get; set; }

    }
    public class RecipeUpdateVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Method { get; set; }
        public int IngredientsListId { get; set; }
        public List<RecipeIngredientsAddVm> Ingredients { get; set; }

    }
}

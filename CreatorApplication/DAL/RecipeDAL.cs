using CreatorApplication.DAL.Contracts;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.DAL
{
    public class RecipeDAL : IRecipeDAL
    {
        private AppDbContext _appDbContext = null;

        public RecipeDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));

        }
        public async Task<int> Add(RecipeAddVm recipeAddVm)
        {
            RecipeIngredientsList recipeIngredientsList = new RecipeIngredientsList() { };
            _appDbContext.RecipeIngredientsLists.Add(recipeIngredientsList);
            _appDbContext.SaveChanges();

            Recipe recipe = new Recipe()
            {
                Title = recipeAddVm.Title,
                Method = recipeAddVm.Method,
                RecipeIngredientsListId = recipeIngredientsList.Id,
            };
            _appDbContext.Recipes.Add(recipe);

            foreach (var ingred in recipeAddVm.Ingredients)
            {
                IngredientsList ingredients = new IngredientsList()
                {
                    IngredientId = ingred.Id,
                    RecipeIngredientsListId = recipeIngredientsList.Id
                };
                _appDbContext.IngredientsLists.Add(ingredients);
            }

            await _appDbContext.SaveChangesAsync();
            return recipe.Id;
        }
        public async Task<List<RecipeVm>> GetAll()
        {
            List<RecipeVm> recipeVms = new List<RecipeVm>();
            List<Recipe> entities = await _appDbContext.Recipes
                .Include(i => i.RecipeIngredients)
                .ThenInclude(ti => ti.IngredientsList)
                .ThenInclude(ti => ti.Ingredient)
                .ToListAsync();
            foreach (Recipe entity in entities)
            {
                RecipeVm recipeVm = new RecipeVm()
                {
                    Method = entity.Method,
                    Title = entity.Title,
                    Ingredients = entity.RecipeIngredients.IngredientsList
                    .Select(s => new RecipeIngredientsVm { Name = s.Ingredient.IngredientName })
                    .ToList()
                };
                recipeVms.Add(recipeVm);
            }
            return recipeVms;
        }
        public async Task<RecipeVm> GetById(int id)
        {
            Recipe entity = await _appDbContext.Recipes
                .Include(i => i.RecipeIngredients)
                .ThenInclude(ti => ti.IngredientsList)
                .ThenInclude(ti => ti.Ingredient)
                .FirstOrDefaultAsync(x => x.Id == id);
                
            RecipeVm recipeVm = new RecipeVm()
            {
                Method = entity.Method,
                Title = entity.Title,
                Ingredients = entity.RecipeIngredients.IngredientsList
                .Select(s => new RecipeIngredientsVm { Name = s.Ingredient.IngredientName })
                .ToList()
            };
            return recipeVm;
        }
        public async Task<bool> Delete(int id)
        {

            Recipe entity = _appDbContext.Recipes.Include(i => i.RecipeIngredients)
                                                 .ThenInclude(ti => ti.IngredientsList)
                                                 .ThenInclude(ti => ti.Ingredient)
                                                 .FirstOrDefault(x => x.Id == id);

            //find recipeingredientslist id
            RecipeIngredientsList recipeIngredientsList = _appDbContext.RecipeIngredientsLists
                                                                       .FirstOrDefault(x => x.Id == entity.RecipeIngredientsListId);

            //find ingredientlist Id
            var ilids = _appDbContext.IngredientsLists
                                    .Where(x => x.RecipeIngredientsListId.Equals(recipeIngredientsList.Id));

            foreach (var entry in ilids)
            {
                _appDbContext.IngredientsLists.Remove(entry);
            }
            _appDbContext.Recipes.Remove(entity);
            _appDbContext.RecipeIngredientsLists.Remove(recipeIngredientsList);

            int deleted = await _appDbContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<bool> Update(RecipeUpdateVm recipeUpdateVm)
        {
            Recipe entity = _appDbContext.Recipes
                .FirstOrDefault(x => x.Id == recipeUpdateVm.Id);

            entity.Title = recipeUpdateVm.Title;
            entity.Method = recipeUpdateVm.Method;

            var ingredList = _appDbContext.IngredientsLists
                                          .Where(x => x.RecipeIngredientsListId.Equals(recipeUpdateVm.Id));

            foreach(var ingred in ingredList)
            {
                _appDbContext.IngredientsLists.Remove(ingred);
            }

            foreach (var ingred in recipeUpdateVm.Ingredients)
            {
                IngredientsList ingredients = new IngredientsList()
                {
                    IngredientId = ingred.Id,
                    RecipeIngredientsListId = recipeUpdateVm.IngredientsListId
                };
                _appDbContext.IngredientsLists.Add(ingredients);
            }

            int updated = await _appDbContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}

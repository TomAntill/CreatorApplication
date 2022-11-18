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
    public class IngredientDAL :IIngredientDAL
    {
        private AppDbContext _appDbContext = null;

        public IngredientDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public async Task<int> Add(IngredientVm ingredientVm)
        {
            Ingredient ingredient = new Ingredient()
            {
                IngredientName = ingredientVm.IngredientName,
            };
            _appDbContext.Ingredients.Add(ingredient);
            Common.Guards.EntityIsNotNull<IngredientVm>(ingredientVm, ingredient.Id);
            await _appDbContext.SaveChangesAsync();
            return ingredient.Id;
        }
        public async Task<bool> Delete(int id)
        {
            Ingredient entity = _appDbContext.Ingredients.FirstOrDefault(x => x.Id == id);
            Common.Guards.EntityIsNotNull<Ingredient>(entity, id);
            _appDbContext.Ingredients.Remove(entity);
            int deleted = await _appDbContext.SaveChangesAsync();
            return deleted > 0;
        }
        public async Task<bool> Update(IngredientUpdateVm ingredientUpdateVm)
        {
            Ingredient entity = await _appDbContext.Ingredients.FirstOrDefaultAsync(x => x.Id == ingredientUpdateVm.Id);
            Common.Guards.EntityIsNotNull<IngredientUpdateVm>(entity, ingredientUpdateVm.Id);

            entity.IngredientName = ingredientUpdateVm.IngredientName;
            int updated = await _appDbContext.SaveChangesAsync();
            return updated > 0;
        }
        public async Task<IngredientVm> GetById(int id)
        {
            Ingredient entity = await _appDbContext.Ingredients.FirstOrDefaultAsync(x => x.Id == id);
            Common.Guards.EntityIsNotNull<IngredientVm>(entity, id);

            IngredientVm itemVm = new IngredientVm()
            {
                IngredientName = entity.IngredientName,
            };
            return itemVm;
        }
        public async Task<List<IngredientVm>> GetAll()
        {
            List<IngredientVm> itemVms = new List<IngredientVm>();
            List<Ingredient> entities = await _appDbContext.Ingredients.ToListAsync();
            foreach (Ingredient entity in entities)
            {
                IngredientVm itemVm = new IngredientVm()
                {
                    IngredientName = entity.IngredientName,
                };
                itemVms.Add(itemVm);
            }
            return itemVms;
        }
    }
}

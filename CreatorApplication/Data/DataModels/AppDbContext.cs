using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication.Data.DataModels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredientsList> RecipeIngredientsLists { get; set; }
        public DbSet<IngredientsList> IngredientsLists { get; set; }
        public DbSet<RecipeReview> RecipeReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => new { e.Id });

            });

            modelBuilder.Entity<RecipeIngredientsList>(entity =>
            {
                entity.HasKey(e => new { e.Id })
                ;
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.HasOne(d => d.RecipeIngredients)
                    .WithOne()
                    .HasForeignKey<Recipe>(d => d.RecipeIngredientsListId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<IngredientsList>(entity =>
            {
                entity.HasKey(e => new { e.RecipeIngredientsListId, e.IngredientId });
                entity.HasOne(d => d.RecipeIngredientsList)
                    .WithMany(wm => wm.IngredientsList)
                    .HasForeignKey(d => d.RecipeIngredientsListId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Ingredient)
                .WithMany(wm => wm.IngredientsList)
                .HasForeignKey(d => d.IngredientId);
            });
        }
    }
}

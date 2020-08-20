using Microsoft.EntityFrameworkCore;
using RecipeMicroserviceAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeIngredient>().HasKey(ri => new { ri.RecipeId, ri.IngredientId });
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<PreparationStep> PreparationSteps { get; set; }
        public DbSet<MyCookbook> Cookbooks { get; set; }
    }
}

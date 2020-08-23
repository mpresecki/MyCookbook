using RecipeMicroserviceAPI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Business.Services
{
    public interface IRecipeService
    {
        Task<List<RecipeListModel>> GetAllRecipesAsync(long userId, long? skillLevelId, long? categoryId, bool areUserRecipes = false);

        Task<RecipeModel> GetRecipeByIdAsync(long id);

        Task InsertRecipeAsync(RecipeInsertModel recipe);

        Task UpdateRecipeAsync(RecipeInsertModel recipe);

        Task DeleteRecipeAsync(long id);

        Task<List<RecipeCategoryModel>> GetAllCategoriesAsync();

        Task<List<SkillLevelModel>> GetAllSkillsAsync();

        Task<List<UnitModel>> GetAllUnitsAsync();
    }
}

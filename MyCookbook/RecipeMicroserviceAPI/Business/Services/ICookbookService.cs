using RecipeMicroserviceAPI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Business.Services
{
    public interface ICookbookService
    {
        Task<List<CookbookModel>> GetCookbookRecipesByUserAsync(long userId);

        Task<Boolean> IsRecipeSavedByUserAsync(long userId, long recipeId);

        Task InsertCookbookRecipeAsync(CookbookInsertModel cookbookRecipe);

        Task DeleteCookbookRecipeAsync(long recipeId, long userId);
    }
}

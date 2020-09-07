using MealMicroserviceAPI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealMicroserviceAPI.Business.Services
{
    public interface IMealService
    {
        Task<List<MealsByDayModel>> GetMealsByUserAsync(long userId, string accessToken);

        Task InsertMealAsync(MealInsertModel meal);

        Task UpdateMealAsync(MealUpdateModel meal);

        Task DeleteMealAsync(long id);

        Task DeleteMealsByRecipeAsync(long recipeId);
    }
}

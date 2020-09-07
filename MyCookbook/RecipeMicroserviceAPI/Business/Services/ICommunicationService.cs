using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeMicroserviceAPI.Business.Models;

namespace RecipeMicroserviceAPI.Business.Services
{
    public interface ICommunicationService
    {
        Task<UserModel> CheckUserAsync(long userId, string accessToken);

        Task<bool> DeleteMealsAsync(long recipeId, string accessToken);
    }
}

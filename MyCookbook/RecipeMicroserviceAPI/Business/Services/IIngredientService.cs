using RecipeMicroserviceAPI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Business.Services
{
    public interface IIngredientService
    {
        Task<List<IngredientModel>> GetAllIngredientsAsync(string name = "", bool exactMatch = false);

        Task<IngredientModel> GetIngredientByIdAsync(long id);

        Task InsertIngredientAsync(IngredientInsertModel ingredient);

        Task UpdateIngredientAsync(IngredientModel ingredient);

        Task DeleteIngredientAsync(long id);
    }
}

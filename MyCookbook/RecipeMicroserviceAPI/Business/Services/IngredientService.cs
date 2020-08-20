using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RecipeMicroserviceAPI.Business.Models;
using RecipeMicroserviceAPI.Data;
using RecipeMicroserviceAPI.Data.Entities;
using RecipeMicroserviceAPI.Data.Repositories;

namespace RecipeMicroserviceAPI.Business.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IMapper _mapper;

        private readonly IRepository<Ingredient> _repository;

        private readonly IDatabaseScope _databaseScope;

        public IngredientService(IMapper mapper, IRepository<Ingredient> repository, IDatabaseScope databaseScope)
        {
            _mapper = mapper;
            _repository = repository;
            _databaseScope = databaseScope;
        }

        public async Task<List<IngredientModel>> GetAllIngredientsAsync(string name = "", bool exactMatch = false)
        {
            var ingredientsQuery = _repository.GetAll();
            if (name != String.Empty && name != null) {
                if (exactMatch)
                {
                    ingredientsQuery = ingredientsQuery.Where(i => i.Name.Equals(name));
                }
                else
                {
                    ingredientsQuery = ingredientsQuery.Where(i => i.Name.Equals(name) || i.Name.Contains(name));
                }
            }

            var ingredients = await ingredientsQuery
                .AsNoTracking()
                .ProjectTo<IngredientModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return ingredients;
        }

        public async Task<IngredientModel> GetIngredientByIdAsync(long id)
        {
            var ingredient = await _repository
                .GetAll()
                .Where(i => i.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            ingredient.RejectNotFound();
            
            return _mapper.Map<IngredientModel>(ingredient);
        }

        public async Task InsertIngredientAsync(IngredientInsertModel ingredient)
        {
            var newIngredient = _mapper.Map<Ingredient>(ingredient);
            await _repository.InsertAsync(newIngredient);
        }

        public async Task UpdateIngredientAsync(IngredientModel ingredient)
        {
            var ingredientEntity = _mapper.Map<Ingredient>(ingredient);
            await _repository.UpdateAsync(ingredientEntity);
        }
        public async Task DeleteIngredientAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RecipeMicroserviceAPI.Business.Models;
using RecipeMicroserviceAPI.Data.Entities;
using RecipeMicroserviceAPI.Data.Repositories;

namespace RecipeMicroserviceAPI.Business.Services
{
    public class CookbookService : ICookbookService
    {
        private readonly IMapper _mapper;

        private readonly IRepository<MyCookbook> _repository;

        public CookbookService(IMapper mapper, IRepository<MyCookbook> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<CookbookModel>> GetCookbookRecipesByUserAsync(long userId)
        {
            var userCookbook = await _repository.GetAll()
                .Where(c => c.UserId == userId)
                .AsNoTracking()
                .ProjectTo<CookbookModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            foreach (var recipe in userCookbook)
            {
                recipe.Recipe.IsSaved = true;
            }
            return userCookbook;
        }

        public async Task<Boolean> IsRecipeSavedByUserAsync(long userId, long recipeId)
        {
            var userCookbookId = await _repository.GetAll()
                .Where(c => c.UserId == userId && c.RecipeId == recipeId)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

            if (userCookbookId > 0)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public async Task InsertCookbookRecipeAsync(CookbookInsertModel cookbookRecipe)
        {
            var newCookbookRecipe = _mapper.Map<MyCookbook>(cookbookRecipe);
            await _repository.InsertAsync(newCookbookRecipe);
        }

        public async Task DeleteCookbookRecipeAsync(long recipeId, long userId)
        {
            var cookbookRecipeId = await _repository.GetAll()
                .Where(c => c.RecipeId == recipeId && c.UserId == userId)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

            await _repository.DeleteAsync(cookbookRecipeId);
        }
    }
}

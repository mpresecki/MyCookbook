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
    public class RecipeService : IRecipeService
    {
        private readonly IMapper _mapper;

        private readonly IRepository<Recipe> _repository;

        private readonly IRepository<PreparationStep> _preparationStepRepository;

        private readonly RecipeContext _context;

        private readonly ICookbookService _cookbookService;

        public RecipeService(IMapper mapper, 
            IRepository<Recipe> repository, IRepository<PreparationStep> prepStepRepository,
            RecipeContext context,
            ICookbookService cookbookService)
        {
            _mapper = mapper;
            _repository = repository;
            _preparationStepRepository = prepStepRepository;
            _context = context;
            _cookbookService = cookbookService;
        }

        public async Task<List<RecipeListModel>> GetAllRecipesAsync(long userId, long? skillLevelId, long? categoryId, bool areUserRecipes = false)
        {
            var recipesQuery = _repository.GetAll().AsNoTracking();

            if (areUserRecipes)
            {
                recipesQuery.Where(r => r.UserId == userId);
            }
            else
            {
                recipesQuery.Where(r => r.IsPublic == true);
            }

            if (skillLevelId.HasValue)
            {
                recipesQuery.Where(r => r.SkillLevelId == skillLevelId);
            }
            if (categoryId.HasValue)
            {
                recipesQuery.Where(r => r.RecipeCategoryId == categoryId);
            }

            var recipes = await recipesQuery
                .AsNoTracking()
                .ProjectTo<RecipeListModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            foreach (var recipe in recipes)
            {
                recipe.IsSaved = await _cookbookService.IsRecipeSavedByUserAsync(userId, recipe.Id);
            }
            return recipes;
        }

        public async Task<RecipeModel> GetRecipeByIdAsync(long id)
        {
            var recipe = await _repository.GetAll()
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Include(r => r.PreparationSteps)
                .Include(r => r.RecipeCategory)
                .Include(r => r.SkillLevel)
                .Include(r => r.RecipeIngredients)
                .AsNoTracking()
                .ProjectTo<RecipeModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            recipe.PreparationSteps = recipe.PreparationSteps.OrderBy(p => p.StepNumber).ToList();
            return recipe;
        }

        public async Task InsertRecipeAsync(RecipeInsertModel recipe)
        {
            var newRecipe = _mapper.Map<Recipe>(recipe);
            await _repository.InsertAsync(newRecipe);
        }

        public async Task UpdateRecipeAsync(RecipeInsertModel recipe)
        {
            var recipeEntity = await _repository.GetAll()
                .Where(r => r.Id == recipe.Id)
                .Include(r => r.RecipeIngredients)
                .Include(r => r.PreparationSteps)
                .FirstOrDefaultAsync();
            await UpdateRecipeIngredients(recipe, recipeEntity);
            await UpdatePreparationSteps(recipe, recipeEntity);
            await _repository.UpdateAsync(recipeEntity);
        }
        

        public async Task DeleteRecipeAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        private async Task UpdateRecipeIngredients(RecipeInsertModel recipe, Recipe recipeEntity)
        {
            var ingredients = recipe.RecipeIngredients;
            var dbIngredients = recipeEntity.RecipeIngredients;

            var ingredientRemoveList = dbIngredients
                .Where(dbr => !ingredients.Select(r => r.IngredientId).ToList().Contains(dbr.IngredientId))
                .ToList();
            var ingredientAddList = recipe.RecipeIngredients
                .Where(r => !dbIngredients.Select(dbr => dbr.IngredientId).ToList().Contains(r.IngredientId))
                .ToList();
            var ingredientUpdateList = recipe.RecipeIngredients
                .Where(r => dbIngredients.Select(dbr => dbr.IngredientId).ToList().Contains(r.IngredientId))
                .ToList();

            foreach (var item in ingredientUpdateList)
            {
                var recipeIngredient = new RecipeIngredient
                {
                    IngredientId = item.IngredientId,
                    RecipeId = recipe.Id,
                    UnitId = item.UnitId,
                    Quantity = item.Quantity
                };
                _context.Update(recipeIngredient);
                await _context.SaveChangesAsync();
                _context.Entry(recipeIngredient).State = EntityState.Detached;
                recipeEntity.RecipeIngredients.Add(recipeIngredient);
            }

            foreach (var item in ingredientRemoveList)
            {
                recipeEntity.RecipeIngredients.Remove(item);
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }

            foreach (var item in ingredientAddList)
            {
                var recipeIngredient = new RecipeIngredient
                {
                    IngredientId = item.IngredientId,
                    RecipeId = recipe.Id,
                    UnitId = item.UnitId,
                    Quantity = item.Quantity
                };
                _context.Add(recipeIngredient);
                await _context.SaveChangesAsync();
                recipeEntity.RecipeIngredients.Add(recipeIngredient);
            }
        }

        private async Task UpdatePreparationSteps(RecipeInsertModel recipe, Recipe recipeEntity)
        {
            var prepSteps = recipe.PreparationSteps;
            var dbPrepSteps = recipeEntity.PreparationSteps;

            var stepsRemoveList = dbPrepSteps
                .Where(dbp => prepSteps.Where(p => p.StepNumber == dbp.StepNumber && p.StepText == dbp.StepText).Count() == 0)
                .ToList();
            var stepsAddList = recipe.PreparationSteps
                .Where(p => dbPrepSteps.Where(dbp => dbp.StepNumber == p.StepNumber && dbp.StepText == p.StepText).Count() == 0)
                .ToList();


            foreach (var item in stepsRemoveList)
            {
                recipeEntity.PreparationSteps.Remove(item);
                await _preparationStepRepository.DeleteAsync(item.Id);
            }

            foreach (var item in stepsAddList)
            {
                var preparationStep = new PreparationStep
                {
                    RecipeId = recipe.Id,
                    StepNumber = item.StepNumber,
                    StepText = item.StepText
                };
                _context.Add(preparationStep);
                await _context.SaveChangesAsync();
                recipeEntity.PreparationSteps.Add(preparationStep);
            }
        }
    }
}

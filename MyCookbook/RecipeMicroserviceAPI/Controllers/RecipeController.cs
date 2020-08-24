using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroserviceAPI.Business.Models;
using RecipeMicroserviceAPI.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;

namespace RecipeMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _service;
        private readonly ICommunicationService _communicationService;

        public RecipeController(IRecipeService service, ICommunicationService communicationService)
        {
            _service = service;
            _communicationService = communicationService;
        }

        [HttpGet]
        public async Task<List<RecipeListModel>> GetRecipesAsync(long userId, long? skillLevelId, long? categoryId, bool areUserRecipes = false)
        {
            return await _service.GetAllRecipesAsync(userId, skillLevelId, categoryId, areUserRecipes);
        }

        [HttpGet]
        [Route("{recipeId:long}")]
        public async Task<RecipeModel> GetRecipeByIdAsync(long recipeId)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString();
            var recipe = await _service.GetRecipeByIdAsync(recipeId, accessToken);

            return recipe;
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipeAsync(RecipeInsertModel recipe)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString();
            var user = await _communicationService.CheckUserAsync(recipe.UserId, accessToken);
            if (user != null && user.Email != String.Empty)
            {
                await _service.InsertRecipeAsync(recipe);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task UpdateRecipeAsync(RecipeInsertModel recipe)
        {
            await _service.UpdateRecipeAsync(recipe);
        }

        [HttpDelete]
        [Route("{recipeId:long}")]
        public async Task DeleteRecipeAsync(long recipeId)
        {
            await _service.DeleteRecipeAsync(recipeId);
        }

        [HttpGet]
        [Route("categories")]
        public async Task<List<RecipeCategoryModel>> GetRecipeCategoriesAsync()
        {
            return await _service.GetAllCategoriesAsync();
        }

        [HttpGet]
        [Route("skills")]
        public async Task<List<SkillLevelModel>> GetSkillLevelsAsync()
        {
            return await _service.GetAllSkillsAsync();
        }

        [HttpGet]
        [Route("units")]
        public async Task<List<UnitModel>> GetUnitsAsync()
        {
            return await _service.GetAllUnitsAsync();
        }
    }
}
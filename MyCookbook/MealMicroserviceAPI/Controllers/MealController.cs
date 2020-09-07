using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealMicroserviceAPI.Business.Models;
using MealMicroserviceAPI.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace MealMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MealController : ControllerBase
    {
        private readonly IMealService _service;

        public MealController(IMealService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<MealsByDayModel>> GetMealsByUserAsync(long userId)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString();
            return await _service.GetMealsByUserAsync(userId, accessToken);
        }

        [HttpPost]
        public async Task AddMealAsync(MealInsertModel meal)
        {
            await _service.InsertMealAsync(meal);
        }

        [HttpPut]
        public async Task UpdateMealAsync(MealUpdateModel meal)
        {
            await _service.UpdateMealAsync(meal);
        }

        [HttpDelete]
        [Route("{mealId:long}")]
        public async Task DeleteMealAsync(long mealId)
        {
            await _service.DeleteMealAsync(mealId);
        }

        [HttpDelete]
        public async Task DeleteMealsByRecipeAsync(long recipeId)
        {
            await _service.DeleteMealsByRecipeAsync(recipeId);
        }
    }
}
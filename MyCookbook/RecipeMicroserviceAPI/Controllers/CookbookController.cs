using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroserviceAPI.Business.Models;
using RecipeMicroserviceAPI.Business.Services;

namespace RecipeMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CookbookController : ControllerBase
    {
        private readonly ICookbookService _service;

        public CookbookController(ICookbookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<CookbookModel>> GetCookbookRecipesByUserAsync(long userId)
        {
            return await _service.GetCookbookRecipesByUserAsync(userId);
        }

        [HttpPost]
        public async Task InsertCookbookRecipeAsync(CookbookInsertModel cookbook)
        {
            await _service.InsertCookbookRecipeAsync(cookbook);
        }

        [HttpDelete]
        public async Task DeleteCookbookRecipeAsync(long recipeId, long userId)
        {
            await _service.DeleteCookbookRecipeAsync(recipeId, userId);
        }
    }
}
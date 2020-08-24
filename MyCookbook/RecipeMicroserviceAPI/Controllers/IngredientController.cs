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
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<IngredientModel>> GetIngredientsAsync([FromQuery]string name = "", [FromQuery]bool exactMatch = false)
        {
            return await _service.GetAllIngredientsAsync(name, exactMatch);
        }

        [HttpGet]
        [Route("{ingredientId:long}")]
        public async Task<IngredientModel> GetIngredientByIdAsync(long ingredientId)
        {
            return await _service.GetIngredientByIdAsync(ingredientId);
        }

        [HttpPost]
        public async Task AddIngredientAsync(IngredientInsertModel ingredient)
        {
            await _service.InsertIngredientAsync(ingredient);
        }

        [HttpPut]
        public async Task UpdateIngredientAsync(IngredientModel ingredient)
        {
            await _service.UpdateIngredientAsync(ingredient);
        }

        [HttpDelete]
        [Route("{ingredientId:long}")]
        public async Task DeleteIngredientAsync(long ingredientId)
        {
            await _service.DeleteIngredientAsync(ingredientId);
        }
    }
}
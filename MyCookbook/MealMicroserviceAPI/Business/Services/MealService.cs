using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MealMicroserviceAPI.Business.Models;
using MealMicroserviceAPI.Data.Entities;
using MealMicroserviceAPI.Data.Repositories;
using MealMicroserviceAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MealMicroserviceAPI.Business.Services
{
    public class MealService : IMealService
    {
        private readonly IRepository<Meal> _repository;

        private readonly IMapper _mapper;

        private readonly IHttpClientFactory _clientFactory;

        private readonly IConfiguration _configuration;

        private readonly AppSettings _appSettings;

        public MealService(IRepository<Meal> repository, IMapper mapper, IHttpClientFactory factory,
            IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _clientFactory = factory;
            _configuration = configuration;

            // konfigurira app postavke
            _appSettings = new AppSettings();
            _configuration.GetSection("AppSettings").Bind(_appSettings);
        }

        public async Task<List<MealsByDayModel>> GetMealsByUserAsync(long userId, string accessToken)
        {
            var daysAhead = 14;
            var lastDate = DateTime.Now.Date.AddDays(daysAhead);
            var meals = await _repository.GetAll()
                .Where(m => m.UserId == userId
                    && m.MealDay >= DateTime.Now.Date && m.MealDay < lastDate)
                .AsNoTracking()
                .ProjectTo<MealModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var mealsDict = new Dictionary<DateTime, List<MealModel>>();
            foreach (var meal in meals)
            {
                meal.RecipeName = await GetRecipeNameAsync(meal.RecipeId, accessToken);
                mealsDict.TryGetValue(meal.MealDay, out List<MealModel> mealsOnDay);
                if (mealsOnDay != null)
                {
                    mealsOnDay.Add(meal);
                }
                else
                {
                    mealsDict.Add(meal.MealDay, new List<MealModel>());
                    mealsDict.GetValueOrDefault(meal.MealDay).Add(meal);
                }
            }

            List<MealsByDayModel> mealsByDay = new List<MealsByDayModel>();
            foreach (var key in mealsDict.Keys)
            {
                MealsByDayModel m = new MealsByDayModel();
                m.Day = key;
                m.Meals = mealsDict.GetValueOrDefault(key);
                mealsByDay.Add(m);
            }
            return mealsByDay;
        }

        public async Task InsertMealAsync(MealInsertModel meal)
        {
            var newMeal = _mapper.Map<Meal>(meal);
            await _repository.InsertAsync(newMeal);
        }

        public async Task UpdateMealAsync(MealUpdateModel meal)
        {
            var mealEntity = _mapper.Map<Meal>(meal);
            await _repository.UpdateAsync(mealEntity);
        }

        public async Task DeleteMealAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        private async Task<string> GetRecipeNameAsync(long id, string accessToken)
        {
            var uri = _appSettings.RecipeAPI + "/" + id;
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "Request-Recipe");
            request.Headers.Add("Authorization", accessToken);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var recipe = await JsonSerializer.DeserializeAsync<RecipeModel>(responseStream);
                return recipe.Name;
            }
            else
            {
                return String.Empty;
            }
        }
    }
}

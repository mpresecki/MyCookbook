using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RecipeMicroserviceAPI.Business.Models;
using RecipeMicroserviceAPI.Helpers;

namespace RecipeMicroserviceAPI.Business.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IHttpClientFactory _clientFactory;

        private readonly IConfiguration _configuration;

        private readonly AppSettings _appSettings;

        public CommunicationService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;

            // konfigurira app postavke
            _appSettings = new AppSettings();
            _configuration.GetSection("AppSettings").Bind(_appSettings);
        }

        public async Task<UserModel> CheckUserAsync(long userId, string accessToken)
        {
            var uri = _appSettings.UserAPI + "/" + userId;
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "Request-User");
            request.Headers.Add("Authorization", accessToken);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            UserModel user;
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                user = await JsonSerializer.DeserializeAsync<UserModel>(responseStream);
            }
            else
            {
                user = null;
            }

            return user;
        }

        public async Task<bool> DeleteMealsAsync(long recipeId, string accessToken)
        {
            var uri = _appSettings.MealAPI + "?recipeId=" + recipeId;
            var request = new HttpRequestMessage(HttpMethod.Delete, uri);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "Request-User");
            request.Headers.Add("Authorization", accessToken);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

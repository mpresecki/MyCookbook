using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RecipeMicroserviceAPI.Business.Models;

namespace RecipeMicroserviceAPI.Business.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CommunicationService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<UserModel> CheckUserAsync(long userId, string accessToken)
        {
            var uri = "http://localhost:57844/api/User/" + userId;
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
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PayCoin.Client.Client;
using PayCoin.Client.Models;

namespace PayCoin.Client.Services
{
    public class ProviderService : IProviderService
    {
        private readonly HttpClient _httpClient;

        public ProviderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Provider> AddProvider(Provider provider)
        {
            try
            {
                var providerJson = new StringContent(JsonSerializer.Serialize(provider), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/Providers", providerJson);

                if(response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<Provider>(responseBody, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
                }

                return null;    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public async Task DeleteProvider(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/Providers/{id}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

        public async Task<IEnumerable<Provider>> GetAllProviders()
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Providers");
           return await JsonSerializer.DeserializeAsync<IEnumerable<Provider>>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Provider> GetProvider(int id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Providers/{id}");
            return await JsonSerializer.DeserializeAsync<Provider>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateProvider(Provider provider)
        {
            try
            {
                var providerJson = new StringContent(JsonSerializer.Serialize(provider), Encoding.UTF8, "application/json");

                var url = $"api/Providers/{provider.ProviderId}";

                var response = await _httpClient.PutAsync(url, providerJson);

                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
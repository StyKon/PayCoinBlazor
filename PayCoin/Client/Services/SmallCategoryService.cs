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
    public class SmallCategoryService : ISmallCategoryService
    {
        private readonly HttpClient _httpClient;

        public SmallCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SmallCategory> AddSmallCategory(SmallCategory smallCategory)
        {
            try
            {
                var categoryJson = new StringContent(JsonSerializer.Serialize(smallCategory), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/SmallCategories", categoryJson);

                if(response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<SmallCategory>(responseBody, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
                }

                return null;    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }
        public async Task<IEnumerable<SmallCategory>> GetByChildCategory(int id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/SmallCategories/GetByChildCategory/{id}");
            return await JsonSerializer.DeserializeAsync<IEnumerable<SmallCategory>>
                     (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task DeleteSmallCategory(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/SmallCategories/{id}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

        public async Task<IEnumerable<SmallCategory>> GetAllSmallCategorys()
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/SmallCategories");
           return await JsonSerializer.DeserializeAsync<IEnumerable<SmallCategory>>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<SmallCategory> GetSmallCategory(int id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/SmallCategories/{id}");
            return await JsonSerializer.DeserializeAsync<SmallCategory>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateSmallCategory(SmallCategory smallCategory)
        {
            try
            {
                var smallcategoryJson = new StringContent(JsonSerializer.Serialize(smallCategory), Encoding.UTF8, "application/json");

                var url = $"api/SmallCategories/{smallCategory.SmallCategoryId}";

                var response = await _httpClient.PutAsync(url, smallcategoryJson);

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
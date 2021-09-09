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
    public class ChildCategoryService : IChildCategoryService
    {
        private readonly HttpClient _httpClient;

        public ChildCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChildCategory> AddChildCategory(ChildCategory childCategory)
        {
            try
            {
                var categoryJson = new StringContent(JsonSerializer.Serialize(childCategory), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/ChildCategories", categoryJson);

                if(response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<ChildCategory>(responseBody, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
                }

                return null;    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public async Task DeleteChildCategory(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/ChildCategories/{id}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

        public async Task<IEnumerable<ChildCategory>> GetAllChildCategorys()
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/ChildCategories");
           return await JsonSerializer.DeserializeAsync<IEnumerable<ChildCategory>>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<ChildCategory>> GetByCategory(int id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/ChildCategories/GetByCategory/{id}");
            return await JsonSerializer.DeserializeAsync<IEnumerable<ChildCategory>>
                     (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ChildCategory> GetChildCategory(int id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/ChildCategories/{id}");
            return await JsonSerializer.DeserializeAsync<ChildCategory>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateChildCategory(ChildCategory childCategory)
        {
            try
            {
                var childcategoryJson = new StringContent(JsonSerializer.Serialize(childCategory), Encoding.UTF8, "application/json");

                var url = $"api/ChildCategories/{childCategory.ChildCategoryId}";

                var response = await _httpClient.PutAsync(url, childcategoryJson);

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
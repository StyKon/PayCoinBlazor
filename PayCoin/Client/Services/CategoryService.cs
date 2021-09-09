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
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                var categoryJson = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/Categories", categoryJson);

                if(response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<Category>(responseBody, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
                }

                return null;    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public async Task DeleteCategory(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/Categories/{id}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

        public async Task<IEnumerable<Category>> GetAllCategorys()
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Categories");
           return await JsonSerializer.DeserializeAsync<IEnumerable<Category>>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Category> GetCategory(int id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Categories/{id}");
            return await JsonSerializer.DeserializeAsync<Category>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateCategory(Category category)
        {
            try
            {
                var categoryJson = new StringContent(JsonSerializer.Serialize(category), Encoding.UTF8, "application/json");

                var url = $"api/Categories/{category.CategoryId}";

                var response = await _httpClient.PutAsync(url, categoryJson);

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
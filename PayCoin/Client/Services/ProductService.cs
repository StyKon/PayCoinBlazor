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
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                var categoryJson = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/Products", categoryJson);

                if(response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<Product>(responseBody, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
                }

                return null;    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public async Task DeleteProduct(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/Products/{id}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

        public async Task<IEnumerable<Product>> GetActiveProductForProvider(long providerid)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Products/GetActiveProductForProvider/{providerid}");
            return await JsonSerializer.DeserializeAsync<IEnumerable<Product>>
                     (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Products");
           return await JsonSerializer.DeserializeAsync<IEnumerable<Product>>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Product> GetProduct(int id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Products/{id}");
            return await JsonSerializer.DeserializeAsync<Product>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateProduct(Product product)
        {
            try
            {
                var productJson = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

                var url = $"api/Products/{product.ProductId}";

                var response = await _httpClient.PutAsync(url, productJson);

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
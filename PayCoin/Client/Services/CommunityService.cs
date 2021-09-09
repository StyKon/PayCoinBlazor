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
    public class CommunityService : ICommunityService
    {
        private readonly HttpClient _httpClient;

        public CommunityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Community> AddCommunity(Community community)
        {
            try
            {
                var communityJson = new StringContent(JsonSerializer.Serialize(community), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/Communities", communityJson);

                if(response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<Community>(responseBody, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
                }

                return null;    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public async Task DeleteCommunity(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/Communities/{id}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

        public async Task<IEnumerable<Community>> GetAllCommunitys()
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Communities");
           return await JsonSerializer.DeserializeAsync<IEnumerable<Community>>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Community> GetCommunity(int id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Communities/{id}");
            return await JsonSerializer.DeserializeAsync<Community>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateCommunity(Community community)
        {
            try
            {
                var communityJson = new StringContent(JsonSerializer.Serialize(community), Encoding.UTF8, "application/json");

                var url = $"api/Communities/{community.CommunityId}";

                var response = await _httpClient.PutAsync(url, communityJson);

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
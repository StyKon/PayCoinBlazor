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
    public class CouponService : ICouponService
    {
        private readonly HttpClient _httpClient;

        public CouponService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Coupon> AddCoupon(Coupon coupon)
        {
            try
            {
                var couponJson = new StringContent(JsonSerializer.Serialize(coupon), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/Coupons", couponJson);

                if(response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStreamAsync();

                    return await JsonSerializer.DeserializeAsync<Coupon>(responseBody, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
                }

                return null;    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public async Task DeleteCoupon(int id)
        {
            try
            {
                await _httpClient.DeleteAsync($"api/Coupons/{id}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

        public async Task<IEnumerable<Coupon>> GetActiveCouponForCommunity(long communityid)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Coupons/GetActiveCouponForCommunity/{communityid}");
            return await JsonSerializer.DeserializeAsync<IEnumerable<Coupon>>
                     (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Coupon>> GetAllCoupons()
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Coupons");
           return await JsonSerializer.DeserializeAsync<IEnumerable<Coupon>>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Coupon> GetCoupon(int id)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Coupons/{id}");
            return await JsonSerializer.DeserializeAsync<Coupon>
                    (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<Coupon>> GetUsedCouponForProvider(long providerid)
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/Coupons/GetUsedCouponForProvider/{providerid}");
            return await JsonSerializer.DeserializeAsync<IEnumerable<Coupon>>
                     (apiResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public async Task UpdateCoupon(Coupon coupon)
        {
            try
            {
                var couponJson = new StringContent(JsonSerializer.Serialize(coupon), Encoding.UTF8, "application/json");

                var url = $"api/Coupons/{coupon.CouponId}";

                var response = await _httpClient.PutAsync(url, couponJson);

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
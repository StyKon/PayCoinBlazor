using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using PayCoin.Client.Requests;
using PayCoin.Client.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PayCoin.Client.Client
{

    public class UserClient
    {
        [Inject]
        public  ILocalStorageService _localStorageService { get; set; }
        public HttpClient Client { get; }
        public UserClient(HttpClient client)
        {
            
            Client = client;
            Client.BaseAddress = new Uri("https://localhost:5001/");
           /* Debug.WriteLine("hi every one");
            Debug.WriteLine(GetTokenAsync().Result);
            try
            {
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", GetTokenAsync().Result);

             }
            catch (Exception e)
            {
                // Do something with e, please.
            }*/
          
        }
        public async Task<string> GetTokenAsync ()
        {
            var user = await _localStorageService.GetItemAsync<LoginResult>("user");
            return user.AccessToken;
        }
    }
}

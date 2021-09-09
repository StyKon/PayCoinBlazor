using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using PayCoin.Client.Requests;
using System.Net.Http;
using System.Net.Http.Headers;
using Blazored.LocalStorage;

namespace PayCoin.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private  ILocalStorageService _localStorageService;

        public LoginResult User { get; private set; }
        public AuthenticationService(IHttpService httpService,ILocalStorageService localStorageService) 
        {
            _httpService = httpService;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItemAsync<LoginResult>("user");
        }

        public async Task Login(string Phone, string Password)
        {
            User = await _httpService.Post<LoginResult>("https://localhost:5001/api/Authentication/signin", new { Phone, Password });
            await _localStorageService.SetItemAsync("user", User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItemAsync("user");
        }

        public string GetToken()
        {
            return "";

        }
    }
}
using Blazored.LocalStorage;
using PayCoin.Client.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Client.Services
{
    public class FKSERVICES
    {
        private ILocalStorageService _localStorageService;
        public FKSERVICES(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public async Task<LoginResult> GetTokenAsync()
        {
            var auth = await _localStorageService.GetItemAsync<LoginResult>("user");
            return auth;
        }
    }
}

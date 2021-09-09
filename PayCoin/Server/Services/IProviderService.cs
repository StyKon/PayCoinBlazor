using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Services
{
    public interface IProviderService
    {
        bool IsAnExistingProvider(string Phone);
        Task<bool> IsValidProviderCredentials(string Phone, string password);
        Task<Provider> GetProvider(string Phone, string Password);
    }
}

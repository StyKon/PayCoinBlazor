using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PayCoin.Server.Data;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Services
{
    public class ProviderService : IProviderService
    {
        private readonly ILogger<ProviderService> _logger;
        private readonly PayCoinContext _context;

        public ProviderService(ILogger<ProviderService> logger, PayCoinContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Provider> GetProvider(string Phone, string Password)
        {
            var auth = await _context.Provider
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
            return auth;
        }

        public bool IsAnExistingProvider(string Phone)
        {
            var auth =  _context.Provider.Find(Phone);
            if (auth != null)
                return true;
            else
                return false;

        }

        public async Task<bool> IsValidProviderCredentials(string Phone, string Password)
        {
            _logger.LogInformation($"Validating provider [{Phone}]");
            if (string.IsNullOrWhiteSpace(Phone))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            var auth = await _context.Provider
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
           
            if (auth != null)
                return true;   
            else
                return false;


        }

    }
}

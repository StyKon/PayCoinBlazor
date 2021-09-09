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
    public class CommunityService : ICommunityService
    {
        private readonly ILogger<CommunityService> _logger;
        private readonly PayCoinContext _context;

        public CommunityService(ILogger<CommunityService> logger, PayCoinContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Community> GetCommunity(string Phone, string Password)
        {
            var auth = await _context.Community
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
            return auth;
        }

        public bool IsAnExistingCommunity(string Phone)
        {
            var auth =  _context.Community.Find(Phone);
            if (auth != null)
                return true;
            else
                return false;

        }

        public async Task<bool> IsValidCommunityCredentials(string Phone, string Password)
        {
            _logger.LogInformation($"Validating community [{Phone}]");
            if (string.IsNullOrWhiteSpace(Phone))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            var auth = await _context.Community
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
           
            if (auth != null)
                return true;   
            else
                return false;


        }

    }
}

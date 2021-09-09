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
    public class AdminService : IAdminService
    {
        private readonly ILogger<AdminService> _logger;
        private readonly PayCoinContext _context;

        public AdminService(ILogger<AdminService> logger, PayCoinContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Admin> GetAdmin(string Phone, string Password)
        {
            var auth = await _context.Admin
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
            return auth;
        }

        public bool IsAnExistingAdmin(string Phone)
        {
            var auth =  _context.Admin.Find(Phone);
            if (auth != null)
                return true;
            else
                return false;

        }

        public async Task<bool> IsValidAdminCredentials(string Phone, string Password)
        {
            _logger.LogInformation($"Validating admin [{Phone}]");
            if (string.IsNullOrWhiteSpace(Phone))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            var auth = await _context.Admin
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
           
            if (auth != null)
                return true;   
            else
                return false;


        }

    }
}

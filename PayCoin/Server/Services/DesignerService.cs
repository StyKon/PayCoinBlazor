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
    public class DesignerService : IDesignerService
    {
        private readonly ILogger<DesignerService> _logger;
        private readonly PayCoinContext _context;

        public DesignerService(ILogger<DesignerService> logger, PayCoinContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Designer> GetDesigner(string Phone, string Password)
        {
            var auth = await _context.Designer
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
            return auth;
        }

        public bool IsAnExistingDesigner(string Phone)
        {
            var auth =  _context.Designer.Find(Phone);
            if (auth != null)
                return true;
            else
                return false;

        }

        public async Task<bool> IsValidDesignerCredentials(string Phone, string Password)
        {
            _logger.LogInformation($"Validating designer [{Phone}]");
            if (string.IsNullOrWhiteSpace(Phone))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            var auth = await _context.Designer
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
           
            if (auth != null)
                return true;   
            else
                return false;


        }

    }
}

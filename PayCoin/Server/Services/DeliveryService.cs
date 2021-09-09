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
    public class DeliveryService : IDeliveryService
    {
        private readonly ILogger<DeliveryService> _logger;
        private readonly PayCoinContext _context;

        public DeliveryService(ILogger<DeliveryService> logger, PayCoinContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Delivery> GetDelivery(string Phone, string Password)
        {
            var auth = await _context.Delivery
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
            return auth;
        }

        public bool IsAnExistingDelivery(string Phone)
        {
            var auth =  _context.Delivery.Find(Phone);
            if (auth != null)
                return true;
            else
                return false;

        }

        public async Task<bool> IsValidDeliveryCredentials(string Phone, string Password)
        {
            _logger.LogInformation($"Validating delivery [{Phone}]");
            if (string.IsNullOrWhiteSpace(Phone))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            var auth = await _context.Delivery
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
           
            if (auth != null)
                return true;   
            else
                return false;


        }

    }
}

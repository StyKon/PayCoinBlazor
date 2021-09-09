using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Services
{
    public interface IDeliveryService
    {
        bool IsAnExistingDelivery(string Phone);
        Task<bool> IsValidDeliveryCredentials(string Phone, string password);
        Task<Delivery> GetDelivery(string Phone, string Password);
    }
}

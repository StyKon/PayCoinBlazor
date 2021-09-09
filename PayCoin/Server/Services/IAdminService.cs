using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Services
{
    public interface IAdminService
    {
        bool IsAnExistingAdmin(string Phone);
        Task<bool> IsValidAdminCredentials(string Phone, string password);
        Task<Admin> GetAdmin(string Phone, string Password);
    }
}

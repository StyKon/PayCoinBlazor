using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Services
{
    public interface ICommunityService
    {
        bool IsAnExistingCommunity(string Phone);
        Task<bool> IsValidCommunityCredentials(string Phone, string password);
        Task<Community> GetCommunity(string Phone, string Password);
    }
}

using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Services
{
    public interface IDesignerService
    {
        bool IsAnExistingDesigner(string Phone);
        Task<bool> IsValidDesignerCredentials(string Phone, string password);
        Task<Designer> GetDesigner(string Phone, string Password);
    }
}

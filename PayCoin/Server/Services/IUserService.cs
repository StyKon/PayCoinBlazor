using Microsoft.AspNetCore.Mvc;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Services
{
    public interface IUserService
    {
        bool IsAnExistingUser(string Phone);
        Task<bool> IsValidUserCredentials(string Phone, string password);
        Task<User> GetUser(string Phone, string Password);
        Task<ActionResult<User>> SignUp(User user);
    }
}

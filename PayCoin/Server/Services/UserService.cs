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
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly PayCoinContext _context;

        public UserService(ILogger<UserService> logger, PayCoinContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<User> GetUser(string Phone, string Password)
        {
            var auth = await _context.User
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
            
            return auth;
        }

        public bool IsAnExistingUser(string Phone)
        {
            var auth =  _context.User.Find(Phone);
            if (auth != null)
                return true;
            else
                return false;

        }

        public async Task<bool> IsValidUserCredentials(string Phone, string Password)
        {
            _logger.LogInformation($"Validating user [{Phone}]");
            if (string.IsNullOrWhiteSpace(Phone))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            var auth = await _context.User
             .FirstOrDefaultAsync(x => (x.Phone == Phone) &&
                                     (x.Password == Password));
           
            if (auth != null)
                return true;   
            else
                return false;


        }
        public async Task<ActionResult<User>> SignUp(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

    }
}

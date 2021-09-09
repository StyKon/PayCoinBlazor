using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PayCoin.Server.Data;
using PayCoin.Server.Infrastructure;
using PayCoin.Server.Models;
using PayCoin.Server.Requests;
using PayCoin.Server.Services;

namespace PayCoin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        //private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;
        

        public AuthenticationController(IUserService userService, IJwtAuthManager jwtAuthManager, PayCoinContext context)
        {
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
           
        }
        

        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _userService.IsValidUserCredentials(request.Phone, request.Password))
            {
                return Unauthorized();
            }

            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var User = _userService.GetUser(request.Phone, request.Password);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Phone),
                new Claim("UserId", Convert.ToString(User.Result.UserId)),
                new Claim("Username", User.Result.FirstName + ' '+ User.Result.LastName),
                new Claim("Phone", User.Result.Phone)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.Phone, claims, DateTime.Now);
            // _logger.LogInformation($"User [{request.Email}] logged in the system.");
            return Ok(new LoginResult
            {
                UserId = User.Result.UserId,
                Phone = request.Phone,
                UserName = User.Result.FirstName + ' ' + User.Result.LastName,
                FirstName = User.Result.FirstName,
                LastName = User.Result.LastName,
                Email = User.Result.Email,
                Photo=User.Result.Photo,
                Cin=User.Result.Cin,
                Adresse=User.Result.Adresse,
                City=User.Result.City,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult<User>> SignUp(User user)
        {
            await _userService.SignUp(user);
            return user;
        }

        [HttpGet("user")]
        [Authorize(Policy = "ShouldBeOnlyUser")]
        public ActionResult GetCurrentUser()
        {
            return Ok(new LoginResult
            {

                Phone = User.Identity.Name
            });
        }

        [HttpPost("logout")]
        [Authorize(Policy = "ShouldBeOnlyUser")]
        public ActionResult Logout()
        {
            var Phone = User.Identity.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserPhone(Phone);
          //  _logger.LogInformation($"User [{Firstname}] logged out the system.");
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize(Policy = "ShouldBeOnlyUser")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var Phone = User.Identity.Name;
             //   _logger.LogInformation($"User [{Firstname}] is trying to refresh JWT token.");

                if (string.IsNullOrWhiteSpace(request.RefreshToken))
                {
                    return Unauthorized();
                }

                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var jwtResult = _jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);
             //   _logger.LogInformation($"User [{Firstname}] has refreshed JWT token.");
                return Ok(new LoginResult
                {
                    Phone = Phone,

                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
            }
            catch (SecurityTokenException e)
            {
                return Unauthorized(e.Message); // return 401 so that the client side can redirect the user to login page
            }
        }
    }
}

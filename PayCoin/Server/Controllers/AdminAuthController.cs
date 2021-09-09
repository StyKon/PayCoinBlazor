using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PayCoin.Server.Data;
using PayCoin.Server.Infrastructure;
using PayCoin.Server.Requests;
using PayCoin.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PayCoin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
       private readonly IAdminService _adminService;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly ILogger<AdminAuthController> _logger;
        public AdminAuthController(ILogger<AdminAuthController> logger, IAdminService adminService, IJwtAuthManager jwtAuthManager, PayCoinContext context)
        {
            _logger = logger;
            _adminService = adminService;
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

            if (!await _adminService.IsValidAdminCredentials(request.Phone, request.Password))
            {
                return Unauthorized();
            }

            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Admin = _adminService.GetAdmin(request.Phone, request.Password);
            _logger.LogInformation($"Validating admin [{Admin.Result.LastName}]");
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Phone),
                new Claim("AdminId", Convert.ToString(Admin.Result.AdminId)),
                new Claim("Username", Admin.Result.FirstName + ' '+ Admin.Result.LastName),
                new Claim("Phone", Admin.Result.Phone)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.Phone, claims, DateTime.Now);
            // _logger.LogInformation($"User [{request.Email}] logged in the system.");
            return Ok(new AdminLoginResult
            {
                Phone = request.Phone,
                AdminId = Admin.Result.AdminId,
                UserName = Admin.Result.FirstName + ' ' + Admin.Result.LastName,
                FirstName=Admin.Result.FirstName,
                LastName=Admin.Result.LastName,
                Email=Admin.Result.Email,
                Photo=Admin.Result.Photo,
                Cin=Admin.Result.Cin,
                Adresse=Admin.Result.Adresse,
                City=Admin.Result.City,
                Role = Admin.Result.Role,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
        [HttpGet("admin")]
        [Authorize(Policy = "ShouldBeOnlyAdminOrEditor")]
        public ActionResult GetCurrentAdmin()
        {
            return Ok(new AdminLoginResult
            {
                Phone = User.Identity.Name
            });
        }
       
        [HttpPost("logout")]
        [Authorize(Policy = "ShouldBeOnlyAdminOrEditor")]
        public ActionResult Logout()
        {
            var Phone = User.Identity.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserPhone(Phone);
            //  _logger.LogInformation($"User [{Firstname}] logged out the system.");
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize(Policy = "ShouldBeOnlyAdminOrEditor")]
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

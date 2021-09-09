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
    public class CommunityAuthController : ControllerBase
    {
       private readonly ICommunityService _communityService;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly ILogger<CommunityAuthController> _logger;
        public CommunityAuthController(ILogger<CommunityAuthController> logger, ICommunityService communityService, IJwtAuthManager jwtAuthManager, PayCoinContext context)
        {
            _logger = logger;
            _communityService = communityService;
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

            if (!await _communityService.IsValidCommunityCredentials(request.Phone, request.Password))
            {
                return Unauthorized();
            }

            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Community = _communityService.GetCommunity(request.Phone, request.Password);
            _logger.LogInformation($"Validating community [{Community.Result.LastName}]");
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Phone),
                new Claim("CommunityId", Convert.ToString(Community.Result.CommunityId)),
                new Claim("Username", Community.Result.FirstName + ' '+ Community.Result.LastName),
                new Claim("Phone", Community.Result.Phone)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.Phone, claims, DateTime.Now);
            // _logger.LogInformation($"User [{request.Email}] logged in the system.");
            return Ok(new CommunityLoginResult
            {
                Phone = request.Phone,
                CommunityId = Community.Result.CommunityId,
                UserName = Community.Result.FirstName + ' ' + Community.Result.LastName,
                FirstName= Community.Result.FirstName,
                LastName= Community.Result.LastName,
                Email= Community.Result.Email,
                Photo= Community.Result.Photo,
                Cin= Community.Result.Cin,
                Adresse= Community.Result.Adresse,
                City= Community.Result.City,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
        [HttpGet("community")]
        [Authorize(Policy = "ShouldBeOnlyCommunity")]
        public ActionResult GetCurrentCommunity()
        {
            return Ok(new CommunityLoginResult
            {
                Phone = User.Identity.Name
            });
        }
       
        [HttpPost("logout")]
        [Authorize(Policy = "ShouldBeOnlyCommunity")]
        public ActionResult Logout()
        {
            var Phone = User.Identity.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserPhone(Phone);
            //  _logger.LogInformation($"User [{Firstname}] logged out the system.");
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize(Policy = "ShouldBeOnlyCommunity")]
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

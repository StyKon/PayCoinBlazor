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
    public class ProviderAuthController : ControllerBase
    {
       private readonly IProviderService _providerService;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly ILogger<ProviderAuthController> _logger;
        public ProviderAuthController(ILogger<ProviderAuthController> logger, IProviderService providerService, IJwtAuthManager jwtAuthManager, PayCoinContext context)
        {
            _logger = logger;
            _providerService = providerService;
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

            if (!await _providerService.IsValidProviderCredentials(request.Phone, request.Password))
            {
                return Unauthorized();
            }

            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Provider = _providerService.GetProvider(request.Phone, request.Password);
            _logger.LogInformation($"Validating provider [{Provider.Result.LastName}]");
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Phone),
                new Claim("ProviderId", Convert.ToString(Provider.Result.ProviderId)),
                new Claim("Username", Provider.Result.FirstName + ' '+ Provider.Result.LastName),
                new Claim("Phone", Provider.Result.Phone)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.Phone, claims, DateTime.Now);
            // _logger.LogInformation($"User [{request.Email}] logged in the system.");
            return Ok(new ProviderLoginResult
            {
                Phone = request.Phone,
                ProviderId = Provider.Result.ProviderId,
                UserName = Provider.Result.FirstName + ' ' + Provider.Result.LastName,
                FirstName= Provider.Result.FirstName,
                LastName= Provider.Result.LastName,
                Email= Provider.Result.Email,
                Logo= Provider.Result.Logo,
                Cin= Provider.Result.Cin,
                Mc=Provider.Result.Mc,
                Adresse= Provider.Result.Adresse,
                City= Provider.Result.City,
                CompanyName=Provider.Result.CompanyName,
                Slug=Provider.Result.Slug,
                Phone2=Provider.Result.Phone2,
                Lat = Provider.Result.Lat,
                Long=Provider.Result.Long,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
        [HttpGet("provider")]
        [Authorize(Policy = "ShouldBeOnlyProvider")]
        public ActionResult GetCurrentProvider()
        {
            return Ok(new ProviderLoginResult
            {
                Phone = User.Identity.Name
            });
        }
       
        [HttpPost("logout")]
        [Authorize(Policy = "ShouldBeOnlyProvider")]
        public ActionResult Logout()
        {
            var Phone = User.Identity.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserPhone(Phone);
            //  _logger.LogInformation($"User [{Firstname}] logged out the system.");
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize(Policy = "ShouldBeOnlyProvider")]
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

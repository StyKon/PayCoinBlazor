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
    public class DesignerAuthController : ControllerBase
    {
       private readonly IDesignerService _designerService;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly ILogger<DesignerAuthController> _logger;
        public DesignerAuthController(ILogger<DesignerAuthController> logger, IDesignerService designerService, IJwtAuthManager jwtAuthManager, PayCoinContext context)
        {
            _logger = logger;
            _designerService = designerService;
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

            if (!await _designerService.IsValidDesignerCredentials(request.Phone, request.Password))
            {
                return Unauthorized();
            }

            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Designer = _designerService.GetDesigner(request.Phone, request.Password);
            _logger.LogInformation($"Validating designer [{Designer.Result.LastName}]");
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Phone),
                new Claim("DesignerId", Convert.ToString(Designer.Result.DesignerId)),
                new Claim("Username", Designer.Result.FirstName + ' '+ Designer.Result.LastName),
                new Claim("Phone", Designer.Result.Phone)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.Phone, claims, DateTime.Now);
            // _logger.LogInformation($"User [{request.Email}] logged in the system.");
            return Ok(new DesignerLoginResult
            {
                Phone = request.Phone,
                DesignerId = Designer.Result.DesignerId,
                UserName = Designer.Result.FirstName + ' ' + Designer.Result.LastName,
                FirstName= Designer.Result.FirstName,
                LastName= Designer.Result.LastName,
                Email= Designer.Result.Email,
                Photo= Designer.Result.Photo,
                Cin= Designer.Result.Cin,
                Adresse= Designer.Result.Adresse,
                City= Designer.Result.City,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
        [HttpGet("designer")]
        [Authorize(Policy = "ShouldBeOnlyDesigner")]
        public ActionResult GetCurrentDesigner()
        {
            return Ok(new DesignerLoginResult
            {
                Phone = User.Identity.Name
            });
        }
       
        [HttpPost("logout")]
        [Authorize(Policy = "ShouldBeOnlyDesigner")]
        public ActionResult Logout()
        {
            var Phone = User.Identity.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserPhone(Phone);
            //  _logger.LogInformation($"User [{Firstname}] logged out the system.");
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize(Policy = "ShouldBeOnlyDesigner")]
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

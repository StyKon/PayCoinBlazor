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
    public class DeliveryAuthController : ControllerBase
    {
       private readonly IDeliveryService _deliveryService;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly ILogger<DeliveryAuthController> _logger;
        public DeliveryAuthController(ILogger<DeliveryAuthController> logger, IDeliveryService deliveryService, IJwtAuthManager jwtAuthManager, PayCoinContext context)
        {
            _logger = logger;
            _deliveryService = deliveryService;
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

            if (!await _deliveryService.IsValidDeliveryCredentials(request.Phone, request.Password))
            {
                return Unauthorized();
            }

            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Delivery = _deliveryService.GetDelivery(request.Phone, request.Password);
            _logger.LogInformation($"Validating provider [{Delivery.Result.LastName}]");
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,request.Phone),
                new Claim("DeliveryId", Convert.ToString(Delivery.Result.DeliveryId)),
                new Claim("Username", Delivery.Result.FirstName + ' '+ Delivery.Result.LastName),
                new Claim("Phone", Delivery.Result.Phone)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.Phone, claims, DateTime.Now);
            // _logger.LogInformation($"User [{request.Email}] logged in the system.");
            return Ok(new DeliveryLoginResult
            {
                Phone = request.Phone,
                DeliveryId = Delivery.Result.DeliveryId,
                UserName = Delivery.Result.FirstName + ' ' + Delivery.Result.LastName,
                FirstName= Delivery.Result.FirstName,
                LastName= Delivery.Result.LastName,
                Email= Delivery.Result.Email,
                Logo= Delivery.Result.Logo,
                Cin= Delivery.Result.Cin,
                Mc= Delivery.Result.Mc,
                Adresse= Delivery.Result.Adresse,
                City= Delivery.Result.City,
                CompanyName= Delivery.Result.CompanyName,
                Slug= Delivery.Result.Slug,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
        [HttpGet("delivery")]
        [Authorize(Policy = "ShouldBeOnlyDelivery")]
        public ActionResult GetCurrentDelivery()
        {
            return Ok(new DeliveryLoginResult
            {
                Phone = User.Identity.Name
            });
        }
       
        [HttpPost("logout")]
        [Authorize(Policy = "ShouldBeOnlyDelivery")]
        public ActionResult Logout()
        {
            var Phone = User.Identity.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserPhone(Phone);
            //  _logger.LogInformation($"User [{Firstname}] logged out the system.");
            return Ok();
        }

        [HttpPost("refresh-token")]
        [Authorize(Policy = "ShouldBeOnlyDelivery")]
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

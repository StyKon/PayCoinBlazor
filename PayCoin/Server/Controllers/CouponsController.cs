using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayCoin.Server.Data;
using PayCoin.Server.IRepositorys;
using PayCoin.Server.Models;

namespace PayCoin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponsRepository _repository;

        public CouponsController(ICouponsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Coupons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coupon>>> GetCoupon()
        {
            return await _repository.GetCoupon();
        }

        // GET: api/Coupons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coupon>> GetCoupon(long id)
        {
            return await _repository.GetCoupon(id);
        }

        // PUT: api/Coupons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Coupon>> PutCoupon(long id, Coupon coupon)
        {
            return await _repository.PutCoupon(id, coupon);
        }

        // POST: api/Coupons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Coupon>> PostCoupon(Coupon coupon)
        {
            return await _repository.PostCoupon(coupon);
        }

        // DELETE: api/Coupons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Coupon>> DeleteCoupon(long id)
        {
            return await _repository.DeleteCoupon(id);

        }
        // GET: api/Coupons/GetUsedCouponForProvider/5
        [HttpGet("GetUsedCouponForProvider/{providerid}")]
        public async Task<ActionResult<IEnumerable<Coupon>>> GetUsedCouponForProvider(long providerid)
        {
            return await _repository.GetUsedCouponForProvider(providerid);
        }
        // GET: api/Coupons/GetActiveCouponForCommunity/5
        [HttpGet("GetActiveCouponForCommunity/{communityid}")]
        public async Task<ActionResult<IEnumerable<Coupon>>> GetActiveCouponForCommunity(long communityid)
        {
            return await _repository.GetActiveCouponForCommunity(communityid);
        }
    }
}

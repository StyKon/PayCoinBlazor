using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayCoin.Server.Data;
using PayCoin.Server.IRepositorys;
using PayCoin.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCoin.Server.Repositorys
{
    public class CouponsRepository : ICouponsRepository
    {
        private readonly PayCoinContext _context;
        public CouponsRepository(PayCoinContext _context)
        {
            this._context = _context;
        }
        public async Task<ActionResult<IEnumerable<Coupon>>> GetCoupon()
        {
            return await _context.Coupon.ToListAsync();
        }
        public async Task<ActionResult<Coupon>> GetCoupon(long id)
        {
            var coupon = await _context.Coupon.FindAsync(id);

            if (coupon == null)
            {
                return coupon;
            }

            return coupon;
        }
        public async Task<ActionResult<Coupon>> PutCoupon(long id, Coupon coupon)
        {
            if (id != coupon.CouponId)
            {
                return coupon;
            }

            _context.Entry(coupon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouponExists(id))
                {
                    return coupon;
                }
                else
                {
                    throw;
                }
            }

            return coupon;
        }
        public async Task<ActionResult<Coupon>> PostCoupon(Coupon coupon)
        {
            DateTime dateTime = DateTime.Now;
            coupon.Code =  dateTime.ToString() ;
            _context.Coupon.Add(coupon);
            await _context.SaveChangesAsync();

            return coupon;
        }
        public async Task<ActionResult<Coupon>> DeleteCoupon(long id)
        {
            var coupon = await _context.Coupon.FindAsync(id);
            if (coupon == null)
            {
                return coupon;
            }

            _context.Coupon.Remove(coupon);
            await _context.SaveChangesAsync();

            return coupon;
        }

        public bool CouponExists(long id)
        {
            return _context.Coupon.Any(e => e.CouponId == id);
        }

        public async Task<ActionResult<IEnumerable<Coupon>>> GetActiveCouponForCommunity(long communityid)
        {
            var communitycoupons = await _context.Coupon.Where(a => a.CommunityId == communityid).Where(a => a.Status == "active").Where(a => a.Validation == "valid").ToListAsync();

            if (communitycoupons == null)
            {
                return communitycoupons;
            }

            return communitycoupons;
        }

        public async Task<ActionResult<IEnumerable<Coupon>>> GetUsedCouponForProvider(long providerid)
        {
            var providercoupons = await _context.Coupon.Where(a => a.ProviderId == providerid).Where(a => a.Status == "active").Where(a => a.Validation == "invalid").ToListAsync();

            if (providercoupons == null)
            {
                return providercoupons;
            }

            return providercoupons;
        }
    }
}

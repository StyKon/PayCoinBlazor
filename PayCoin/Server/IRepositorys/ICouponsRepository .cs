using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayCoin.Server.Models;

namespace PayCoin.Server.IRepositorys
{
    public interface ICouponsRepository
    {
        Task<ActionResult<IEnumerable<Coupon>>> GetCoupon();
        Task<ActionResult<IEnumerable<Coupon>>> GetActiveCouponForCommunity(long communityid);
        Task<ActionResult<IEnumerable<Coupon>>> GetUsedCouponForProvider(long providerid);
        Task<ActionResult<Coupon>> GetCoupon(long id);
        Task<ActionResult<Coupon>> PutCoupon(long id, Coupon coupon);
        Task<ActionResult<Coupon>> PostCoupon(Coupon coupon);
        Task<ActionResult<Coupon>> DeleteCoupon(long id);
        bool CouponExists(long id);
    }
}

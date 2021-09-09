using System.Collections.Generic;
using System.Threading.Tasks;
using PayCoin.Client.Models;

namespace PayCoin.Client.Services
{
    public interface ICouponService
    {
         Task<IEnumerable<Coupon>> GetAllCoupons();
         Task<IEnumerable<Coupon>> GetActiveCouponForCommunity(long communityid);
         Task<IEnumerable<Coupon>> GetUsedCouponForProvider(long providerid);
         Task<Coupon> GetCoupon(int id);
         Task<Coupon> AddCoupon(Coupon coupon);
         Task UpdateCoupon(Coupon coupon);
         Task DeleteCoupon(int id);
    }
}
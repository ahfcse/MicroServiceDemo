using Discount.API.Models;

namespace Discount.API.Repository
{
    public interface ICouponRepository
    {
       public Task<Coupon> GetCoupon(string productId);
        public Task<bool> CreateCoupon(Coupon coupon);
        public Task<bool> UpdateCoupon(Coupon coupon);
        public Task<bool> DeleteCoupon(string productId);
    }
}

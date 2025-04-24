using Discount.Grpc.Models;

namespace Discount.Grpc.Repository
{
    public interface ICouponRepository
    {
       public Task<Coupon> GetDiscount(string productId);
        public Task<bool> CreateCoupon(Coupon coupon);
        public Task<bool> UpdateCoupon(Coupon coupon);
        public Task<bool> DeleteCoupon(string productId);
    }
}

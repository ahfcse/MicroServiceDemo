using Dapper;
using Discount.API.Models;
using Microsoft.AspNetCore.Localization;
using Npgsql;


namespace Discount.API.Repository
{
    public class CouponRepository: ICouponRepository
    {
        IConfiguration _configuration;
        public CouponRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> CreateCoupon(Coupon coupon)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var affected =await connection.ExecuteAsync("INSERT INTO Coupon (ProductId, ProductName, Description, Amount) VALUES (@ProductId, @ProductName, @Description, @Amount)", new { ProductId =coupon.ProductId, ProductName =coupon.ProductName, Description =coupon.Description, Amount =coupon.Amount});
            if (affected == 0)
            {
                return false;
            }
            return true;

        }
        public async Task<bool> DeleteCoupon(string productId)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var affected = await connection.ExecuteAsync("DELETE FROM Coupon  WHERE ProductId=@Id", new { ProductId = productId });
            if (affected == 0)
            {
                return false;
            }
            return true;
        }
        public async Task<Coupon> GetCoupon(string productId)
        {

            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var  coupon =await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductId = @ProductId", new { ProductId = productId });
            if (coupon == null)
            {
                coupon = new Coupon()
                {
                    ProductId = "No Discount",
                    Amount = 0,
                    Description = "No Discount Desc"
                };
            }
            return coupon;
        }
        public async Task<bool> UpdateCoupon(Coupon coupon)
        {
            var connection = new NpgsqlConnection(_configuration.GetConnectionString("DiscountDB"));
            var affected = await connection.ExecuteAsync("UPDATE Coupon SET ProductId=@ProductId, ProductName=@ProductName, Description=@Description, Amount=@Amount WHERE Id=@Id", new { ProductId = coupon.ProductId, ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount,Id=coupon.Id });
            if (affected == 0)
            {
                return false;
            }
            return true;
        }
    }
   
}

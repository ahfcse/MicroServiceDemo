using System.Net;
using CoreApiResponse;
using Discount.API.Models;
using Discount.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : BaseController
    {
        private readonly ICouponRepository _couponRepository;
        public DiscountController(ICouponRepository couponRepository) 
        {
            _couponRepository = couponRepository;
        }
        [HttpGet]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDiscount(string productId)
        {
            try
            {
                var coupon = await _couponRepository.GetCoupon(productId);
                if (coupon == null)
                {
                    return CustomResult((int)HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult("Discount Get Successfully",coupon);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDiscount([FromBody] Coupon coupon)
        {
            try
            {
                var createdCoupon = await _couponRepository.CreateCoupon(coupon);
                if (createdCoupon == false)
                {
                    return CustomResult((int)HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult("Discount Created Successfully", coupon);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDiscount([FromBody] Coupon coupon)
        {
            try
            {
                var updatedCoupon = await _couponRepository.UpdateCoupon(coupon);
                if (updatedCoupon == false)
                {
                    return CustomResult((int)HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult("Discount Updated Successfully", coupon);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete]
        [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDiscount(string productId)
        {
            try
            {
                var deletedCoupon = await _couponRepository.DeleteCoupon(productId);
                if (deletedCoupon == false)
                {
                    return CustomResult((int)HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult("Discount Deleted Successfully", productId);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }
    }
}

using System.Net;
using Basket.API.GrpcServices;
using Basket.API.Models;
using Basket.API.Repositories;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : BaseController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountGrpcService _discountGrpcService;
        public BasketController(IBasketRepository basketRepository, DiscountGrpcService discountGrpcService)
        {
            _basketRepository = basketRepository;
            _discountGrpcService = discountGrpcService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBasket(string userName)
        {
            try
            {
                var basket =await _basketRepository.GetBasket(userName);
                if (basket == null)
                {
                    return CustomResult((int)HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult("Data Created Successfully",basket);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBasket([FromBody] ShoppingCart basket)
        {
            try
            {
                //UPDATE Discount FROM GRPC
                //Calculate Amount

                foreach (var item in basket.Items)
                {
                    var coupon = await _discountGrpcService.GetDiscount(item.ProductId);
                    item.Price -= coupon.Amount;
                }

                var updatedBasket =await _basketRepository.UpdateBasket(basket);
                if (updatedBasket == null)
                {
                    return CustomResult((int)HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult("Data Updated Successfully",updatedBasket);
                }
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            try
            {
                await _basketRepository.DeleteBasket(userName);
                return CustomResult("Data Deleted Successfully");
            }
            catch (Exception ex)
            {
                return CustomResult((int)HttpStatusCode.BadRequest);
            }
        }
    }
}

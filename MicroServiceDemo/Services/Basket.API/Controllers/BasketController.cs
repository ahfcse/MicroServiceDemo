using System.Net;
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
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
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

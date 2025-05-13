using CoreApiResponse;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CreateOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrderByUserName;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;   
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderVM>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrdersByUserName(string userName)
        {
            try
            {
                var order = await _mediator.Send(new GetOrderByUserQuery(userName));
                return CustomResult("Order Loaded Successfully",order);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> CraeteOrder(CreateOrderCommand orderCommand)
        {
            try
            {
                var isorderPlaced = await _mediator.Send(orderCommand);
                if (isorderPlaced)
                {
                    return CustomResult("Order has been placed Successfully");
                }
                else
                {
                    return CustomResult("Order has not been placed", StatusCodes.Status500InternalServerError);
                }
               
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand orderCommand)
        {
            try
            {
                var isorderUpdate = await _mediator.Send(orderCommand);
                if (isorderUpdate)
                {
                    return CustomResult("Order Updated Successfully");
                }
                else
                {
                    return CustomResult("Order not updated", StatusCodes.Status500InternalServerError);
                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteeOrder(int Id)
        {
            try
            {
                var isorderDelete = await _mediator.Send(new DeleteOrderCommand() { OrderId=Id});
                if (isorderDelete)
                {
                    return CustomResult("Order Deleted Successfully");
                }
                else
                {
                    return CustomResult("Order not Deleted", StatusCodes.Status500InternalServerError);
                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, StatusCodes.Status500InternalServerError);
            }
        }


    }
}

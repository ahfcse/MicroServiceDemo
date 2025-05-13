using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Infrastructure;
using Ordering.Application.Contacts.Persistence;
using Ordering.Application.Models;
using Ordering.Domain.Models;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand, bool>
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        private readonly IEmailService _emailService;   

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper,IEmailService emailService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _emailService = emailService;

        }
        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            bool isOrderPlaced = await _orderRepository.AddAsync(order);
            if (isOrderPlaced)
            {
                await _emailService.SendEmailAsync(new Email()
                {
                    SendTo = request.EmailAddress,
                    Subject = "Order Confirmation",
                    Body = $"Your order with Order Id: {order.Id} has been placed successfully."

                });
                
            }
            return isOrderPlaced;
        }
    }
   
}

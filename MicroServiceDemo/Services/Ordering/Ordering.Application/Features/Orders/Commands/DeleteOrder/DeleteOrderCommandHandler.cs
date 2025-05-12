using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistence;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public DeleteOrderCommandHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            return _orderRepository.DeleteAsync(new Domain.Models.Order() { ProductId=request.ProductId });
        }
    }
    
}

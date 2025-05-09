using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistence;

namespace Ordering.Application.Features.Orders.Queries.GetOrderByUserName
{
    public class GetOrderByUserHandler:IRequestHandler<GetOrderByUserQuery, List<OrderVM>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrderByUserHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;

        }
        public async Task<List<OrderVM>> Handle(GetOrderByUserQuery request, CancellationToken cancellationToken)
        {
           var orders =await _orderRepository.GetOrderByUser(request.UserName);
            return _mapper.Map<List<OrderVM>>(orders);
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace Ordering.Application.Features.Orders.Queries.GetOrderByUserName
{
    public class GetOrderByUserQuery:IRequest<List<OrderVM>>
    {
        public string UserName { get; set; } = string.Empty;
        public GetOrderByUserQuery(string userName)
        {
            UserName = userName;
        }
    }
   
}

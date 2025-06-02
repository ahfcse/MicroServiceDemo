using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contacts.Persistence;
using Ordering.Domain.Models;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repository
{
    public class OrderRepository : CommonRepository<Order>, IOrderRepository
    {
        private readonly OrderDbContext _orderDbContext;
        public OrderRepository(OrderDbContext orderDbContext) : base(orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<IEnumerable<Order>> GetOrderByUser(string user)
        {
           return await _orderDbContext.Orders
                 .Where(o => o.UserName == user)
                 .ToListAsync();
        }
    }
}

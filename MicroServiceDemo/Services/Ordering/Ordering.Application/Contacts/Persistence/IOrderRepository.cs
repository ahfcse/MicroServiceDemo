using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Core.Repository.Interface.Repository;
using Ordering.Domain.Models;

namespace Ordering.Application.Contacts.Persistence
{
    public interface IOrderRepository:ICommonRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrderByUser(string user);
    }
}

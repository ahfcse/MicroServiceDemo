using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Core.Repository.Interface.Repository;
using Ordering.Application.Models;

namespace Ordering.Application.Contacts.Infrastructure
{
    public interface IEmailRepository:ICommonRepository<Email>
    {
        Task<bool> GetEmailAsync();
    }
    
}

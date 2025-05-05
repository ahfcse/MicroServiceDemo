using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering.Domain.Common;

namespace Ordering.Domain.Models
{
    public class Order:EntityBase
    {
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public decimal Total { get; set; }

        //Shippig Information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        //Payment Information
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public int OrderStatus { get; set; } //0 Pending, 1 Shipped, 2 Delivered
    }
}

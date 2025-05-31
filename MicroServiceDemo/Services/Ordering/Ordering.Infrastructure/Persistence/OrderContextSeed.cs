using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Models;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order{ 
                    Id=1,
                    UserName="ahfcse@gmail.com",
                    Total=100,
                    FirstName="Akram Hossain",
                    LastName="Foysal",
                    EmailAddress="ahfcse@gmail.com",
                    AddressLine = "Dhaka",
                    Country = "Bangladesh",
                    State = "Dhaka",
                    ZipCode = "1212",
                    CardName = "Akram Hossain Foysal",
                    CardNumber = "1234567890123456",
                    Expiration = "12/25",
                    CVV = "123",
                    OrderStatus = 0 //Pending
                
                }
                );
        }
    }
}

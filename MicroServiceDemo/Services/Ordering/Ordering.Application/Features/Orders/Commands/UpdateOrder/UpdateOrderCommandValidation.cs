using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ordering.Application.Features.Orders.Commands.CreateOrder;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidation: AbstractValidator<CreateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            RuleFor(x => x.UserName)
           .NotEmpty().WithMessage("{UserName} is required.")
          .EmailAddress().WithMessage("{UserName} is not a valid email address.")
           .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters.");
            RuleFor(x => x.Total)
                .NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("{TotalPrice} must be greater than 0.");
        }
    }
}

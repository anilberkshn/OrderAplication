using System.Xml.Linq;
using FluentValidation;
using FluentValidation.AspNetCore;
using OrderCase.Model.RequestModels;

namespace OrderCase.Validation
{
    public class OrderValidator : AbstractValidator<CreateDto>
    {
        public OrderValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().NotEmpty().WithMessage("cannot be empty");
         // todo    RuleFor(x => x.CustomerId).NotNull().NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(x => x.Quantity).NotNull().NotEmpty().WithMessage("cannot be empty");
            RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("cannot be empty");
            RuleFor(x => x.Product).NotNull().NotEmpty().WithMessage("cannot be empty");
            
        }
    }
}
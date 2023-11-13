using Customer.Model.RequestModels;
using FluentValidation;

namespace Customer.Validation
{
    public class CustomerValidator : AbstractValidator<CreateDto>
    {
        public CustomerValidator()
        {
            
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Country space cannot be empty");
            RuleFor(x => x.Name).MaximumLength(15).WithMessage("Namespace cannot exceed 15 characters");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email space cannot be empty");
            RuleFor(x => x.Email).MinimumLength(5).WithMessage("Mail length cannot be less than 10 characters.");
            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("Address space cannot be empty");
            RuleFor(x => x.Address.Addressline).NotNull().NotEmpty().WithMessage("Adressline space cannot be empty");
            RuleFor(x => x.Address.Country).NotNull().NotEmpty().WithMessage("Country space cannot be empty");
            RuleFor(x => x.Address.City).NotNull().NotEmpty().WithMessage("City space cannot be empty");
            RuleFor(x => x.Address.CityCode).NotNull().NotEmpty().WithMessage("City code field cannot be empty");
        }
    }
}
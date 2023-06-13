using Core.Model.Entities;
using Customer.Model.Entities;
using Domain.Entities;
using FluentValidation;

namespace Customer.Validation
{
    public class AddressValidator: AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Addressline).NotNull().NotEmpty().WithMessage("Adres alanı boş olamaz.");
            RuleFor(x => x.City).MaximumLength(15).WithMessage("Şehir alanı 15 karakteri geçemez");
            RuleFor(x => x.Country).NotNull().NotEmpty().WithMessage("Ülke alanı boş olamaz");
            RuleFor(x => x.Addressline).MinimumLength(10).WithMessage("Mail uzunluğu 10 karakterden az olamaz.");
            RuleFor(x => x.CityCode).NotNull().NotEmpty().WithMessage("cannot be empty"); 
            RuleFor(x => x.Country).MinimumLength(3).WithMessage("Ülke alanı 3 karakterden kısa olamaz. "); 
            
        }
        
    }
}
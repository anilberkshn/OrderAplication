using Customer.Model.RequestModels;
using FluentValidation;

namespace Customer.Validation
{
    public class CustomerValidator : AbstractValidator<CreateDto>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("İsim alanı boş olamaz.");
            RuleFor(x => x.Name).MaximumLength(15).WithMessage("İsim alanı 15 karakteri geçemez");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Eposta alanı boş olamaz");
            RuleFor(x => x.Email).MinimumLength(5).WithMessage("Mail uzunluğu 10 karakterden az olamaz.");
            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("cannot be empty");
            RuleFor(x => x.Address.Addressline).NotNull().NotEmpty().WithMessage("Adres alanı boş olamaz");
            RuleFor(x => x.Address.Country).NotNull().NotEmpty().WithMessage("Ülke alanı boş olamaz");
            RuleFor(x => x.Address.City).NotNull().NotEmpty().WithMessage("Şehir alanı boş olamaz");
            RuleFor(x => x.Address.CityCode).NotNull().NotEmpty().WithMessage("Şehir kodu alanı boş olamaz");
        }
    }
}
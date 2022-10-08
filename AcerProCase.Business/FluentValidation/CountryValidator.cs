using AcerProCase.Entities.Concrete;
using FluentValidation;

namespace AcerProCase.Business.FluentValidation
{
    public class CountryValidator : AbstractValidator<CountryInfo>
    {
        public CountryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ülke adı boş bırakılamaz.");
            RuleFor(x => x.CapitalCity).NotEmpty().WithMessage("Ülke başkent adı boş bırakılamaz.");
            RuleFor(x => x.ShortName).NotEmpty().WithMessage("Ülke kısaltması boş bırakılamaz.");
            RuleFor(x => x.CountryCurrency).NotEmpty().WithMessage("Ülke para birimi boş bırakılamaz.");

        }
    }
}

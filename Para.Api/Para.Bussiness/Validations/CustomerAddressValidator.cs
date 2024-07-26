using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validations;

public class CustomerAddressValidator : AbstractValidator<CustomerAddress>
{
    public CustomerAddressValidator()
    {
        RuleFor(x => x.Country)
            .NotEmpty()
            .Length(2, 50)
            .WithMessage("Country length must be between 2-50 characters !");
        
        RuleFor(x => x.City)
            .NotEmpty()
            .Length(2, 50)
            .WithMessage("City length must be between 2-50 characters !");
        
        RuleFor(x => x.AddressLine)
            .NotEmpty()
            .MaximumLength(250)
            .WithMessage("Address line length must be maximum 250 characters !");
        
        RuleFor(x => x.ZipCode)
            //It is not required based on configurations we made.
            .MaximumLength(6)
            .WithMessage("Zip code length must be maximum 6 characters !");
        
        RuleFor(x => x.IsDefault)
            .NotEmpty()
            .WithMessage("This field is required.");
    }
}
using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validations;

public class CustomerPhoneValidator : AbstractValidator<CustomerPhone>
{
    public CustomerPhoneValidator()
    {
        RuleFor(x => x.CountyCode)
            .NotEmpty()
            .MaximumLength(3)
            .WithMessage("Country code must be maximum 3 characters !");
        
        RuleFor(x => x.Phone)
            .NotEmpty()
            .MaximumLength(10)
            .WithMessage("Phone must be maximum 10 characters !");
        
        RuleFor(x => x.IsDefault)
            .NotEmpty()
            .WithMessage("This field is required !");
    }
}
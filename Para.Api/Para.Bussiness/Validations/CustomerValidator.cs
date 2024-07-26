using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validations;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .Length(3, 50)
            .WithMessage("First name length must be between 3-50 characters !");
        
        RuleFor(x => x.LastName)
            .NotEmpty()
            .Length(3, 50)
            .WithMessage("Last name length must be between 3-50 characters !");
        
        RuleFor(x => x.IdentityNumber)
            .NotEmpty()
            .Length(11)
            .WithMessage("Identity number length must be 11 characters !");
        RuleFor(x => x.Email)
            .NotEmpty()
            .Length(11, 100)
            .WithMessage("Email length must be between 11-100 characters !");
        
        RuleFor(x => x.DateOfBirth)
            .NotEmpty();
        
        RuleFor(x => x.CustomerNumber)
            .NotEmpty()
            .InclusiveBetween(1, 100)
            .WithMessage("Customer number length must be between 1-100 characters !");
    }
}
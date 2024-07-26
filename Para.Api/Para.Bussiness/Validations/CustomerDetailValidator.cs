using FluentValidation;
using Para.Data.Domain;

namespace Para.Bussiness.Validations;

public class CustomerDetailValidator : AbstractValidator<CustomerDetail>
{
    public CustomerDetailValidator()
    {
        RuleFor(x => x.FatherName)
            .NotEmpty()
            .MaximumLength(30)
            .WithMessage("Father name must be maximum 30 characters !");
        RuleFor(x => x.MotherName)
            .NotEmpty()
            .MaximumLength(30)
            .WithMessage("Mother name must be maximum 30 characters !");
        
        RuleFor(x => x.EducationStatus)
            .NotEmpty()
            .MaximumLength(20)
            .WithMessage("Education status must be maximum 20 characters !");
        
        RuleFor(x => x.MontlyIncome)
            .NotEmpty()
            .MaximumLength(10)
            .WithMessage("Monthly income must be maximum 10 characters !");
        
        RuleFor(x => x.Occupation)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Occupation must be maximum 50 characters !");
    }
}
using FluentValidation;
using RealEstate.App.Models;

namespace RealEstate.App.Validators
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordViewModel>
    {
        public ForgotPasswordValidator()
        {
            RuleFor(x => x.email)
                .EmailAddress().WithMessage("Email is not valid!")
                .NotEmpty().WithMessage("Email is required!");
                
        }   
    }
}

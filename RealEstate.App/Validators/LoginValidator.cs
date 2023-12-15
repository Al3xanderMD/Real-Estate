using FluentValidation;
using RealEstate.App.Models;

namespace RealEstate.App.Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator() {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email is not valid!")
                .NotEmpty().WithMessage("Email is required!");
                

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!");
        }
    }
}

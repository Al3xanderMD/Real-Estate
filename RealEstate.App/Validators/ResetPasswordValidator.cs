using FluentValidation;
using RealEstate.App.Models;

namespace RealEstate.App.Validators
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordViewModel>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x => x.email)
           .NotEmpty().WithMessage("Email is required!")
           .EmailAddress().WithMessage("Email is not valid!");

            RuleFor(x => x.password)
                .NotEmpty().WithMessage("Password is required!")
                .Length(6, 100).WithMessage("Password must be between 6 and 100 characters!");

            RuleFor(x => x.confirmPassword)
                .Equal(x => x.password).WithMessage("Passwords do not match!")
                .NotEmpty().WithMessage("Confirm Password is required!");

            RuleFor(x => x.token)
                .NotEmpty().WithMessage("Token is required!");
        }
    }
}

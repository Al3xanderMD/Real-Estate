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
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long!")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter!")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit!")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character!");

            RuleFor(x => x.confirmPassword)
                .Equal(x => x.password).WithMessage("Passwords do not match!")
                .NotEmpty().WithMessage("Confirm Password is required!");

            RuleFor(x => x.token)
                .NotEmpty().WithMessage("Token is required!");
        }
    }
}

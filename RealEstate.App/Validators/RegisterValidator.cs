using FluentValidation;
using RealEstate.App.Models;

namespace RealEstate.App.Validators
{
    using FluentValidation;

    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.email)
                .NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Email is not valid!");
                

            RuleFor(x => x.username).NotEmpty().WithMessage("Username is required!");

            RuleFor(x => x.name).NotEmpty().WithMessage("Name is required!")
                .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

            RuleFor(x => x.phoneNumber)
                .NotEmpty().WithMessage("Phone number is required!")
                .Matches(@"^(\+4)?07\d{8}$").WithMessage("Phone number is not valid!");


            RuleFor(x => x.password)
                .NotEmpty().WithMessage("Password is required!")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long!")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter!")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit!")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character!");

            RuleFor(x => x.confirmPassword)
                .Equal(x => x.password).WithMessage("Passwords do not match!")
                .NotEmpty().WithMessage("Confirm Password is required!");


        }
    }

}

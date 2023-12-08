namespace RealEstate.App.Validators;
using FluentValidation;

public class EmailModelValidator : AbstractValidator<EmailModel>
{
    public EmailModelValidator()
    {
        RuleFor(model => model.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");
    }
}

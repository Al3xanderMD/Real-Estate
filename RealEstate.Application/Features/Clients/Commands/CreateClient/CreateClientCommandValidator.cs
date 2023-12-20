using FluentValidation;

namespace RealEstate.Application.Features.Categories.Commands.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(p => p.UserId)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull();

            RuleFor(p => p.Username)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull();

            RuleFor(p => p.Email)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull();

            RuleFor(p => p.Name)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull();

            RuleFor(p => p.PhoneNumber)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull();
        }
    }
}

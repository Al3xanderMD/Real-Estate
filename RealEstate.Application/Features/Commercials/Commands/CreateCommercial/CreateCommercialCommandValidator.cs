using FluentValidation;

namespace RealEstate.Application.Features.Commercials.Commands.CreateCommercial
{
    public class CreateCommercialCommandValidator : AbstractValidator<CreateCommercialCommand>
    {
        public CreateCommercialCommandValidator() 
        {
            RuleFor(p => p.UserId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.TitlePost)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.AddressId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.OfferType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(2000).WithMessage("{PropertyName} must not exceed 2000 characters.");

            RuleFor(x => x.CommercialSpecificId)
            .NotNull()
            .WithMessage("Commercial specific is required");

            RuleFor(x => x.UsefulSurface)
                .GreaterThan(0)
                .WithMessage("Useful surface must be greater than 0");
        }
    }
}

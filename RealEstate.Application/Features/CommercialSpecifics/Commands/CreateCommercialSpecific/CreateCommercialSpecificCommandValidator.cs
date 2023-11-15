using FluentValidation;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.CreateCommercialSpecific
{
    public class CreateCommercialSpecificCommandValidator : AbstractValidator<CreateCommercialSpecificCommand>
    {
        public CreateCommercialSpecificCommandValidator() 
        {
            RuleFor(x => x.SpecificName)
            .NotEmpty()
            .WithMessage("Specific name is required")
            .NotNull()
            .WithMessage("Specific name is required")
            .Must(specificName => !string.IsNullOrWhiteSpace(specificName))
            .WithMessage("Specific name is required");
        }
    }
}

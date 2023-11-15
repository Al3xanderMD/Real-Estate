using FluentValidation;

namespace RealEstate.Application.Features.Commercials.Commands.CreateCommercial
{
    public class CreateCommercialCommandValidator : AbstractValidator<CreateCommercialCommand>
    {
        public CreateCommercialCommandValidator() 
        {
            RuleFor(x => x.CommercialSpecificId)
            .NotNull()
            .WithMessage("Commercial specific is required");

            RuleFor(x => x.UsefulSurface)
                .GreaterThan(0)
                .WithMessage("Useful surface must be greater than 0");
        }
    }
}

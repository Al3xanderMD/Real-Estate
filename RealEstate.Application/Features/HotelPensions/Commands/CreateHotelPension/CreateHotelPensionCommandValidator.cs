using FluentValidation;

namespace RealEstate.Application.Features.HotelPensions.Commands.CreateHotelPension
{
    public class CreateHotelPensionCommandValidator : AbstractValidator<CreateHotelPensionCommand>
    {
        public CreateHotelPensionCommandValidator() 
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

            RuleFor(x => x.UsefulSurface)
            .GreaterThan(0)
            .WithMessage("Useful area must be larger than 0.");

            RuleFor(x => x.RoomSurface)
                .GreaterThan(0)
                .WithMessage("Room surface must be larger than 0.");

            RuleFor(x => x.RoomCount)
                .GreaterThan(0)
                .WithMessage("Room count must be larger than 0.");
        }
    }
}

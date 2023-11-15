using FluentValidation;

namespace RealEstate.Application.Features.HotelPensions.Commands.CreateHotelPension
{
    public class CreateHotelPensionCommandValidator : AbstractValidator<CreateHotelPensionCommand>
    {
        public CreateHotelPensionCommandValidator() 
        {
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

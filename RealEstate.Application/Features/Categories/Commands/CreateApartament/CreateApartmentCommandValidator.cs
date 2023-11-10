using FluentValidation;

namespace RealEstate.Application.Features.Categories.Commands.CreateApartament
{
    public class CreateApartmentCommandValidator : AbstractValidator<CreateApartmentCommand>
    {
        public CreateApartmentCommandValidator()
        {
            RuleFor(apartment => apartment.TitlePost)
                .NotEmpty()
                .WithMessage("A Title for the Post is required.");

            RuleFor(apartment => apartment.Image)
                .Must(images => images.Count() <= 16)
                .WithMessage("Please add less than 16 images");

            RuleFor(apartment => apartment.Price)
                .GreaterThan(0)
                .WithMessage("Price must be larger than 0.");

            RuleFor(apartment => apartment.RoomCount)
                .GreaterThan(0)
                .WithMessage("Room count must be larger than 0.");

            RuleFor(apartment => apartment.Comfort)
                .InclusiveBetween(1, 4)
                .WithMessage("Comfort must be between 1 and 4.");

            RuleFor(apartment => apartment.Floor)
                .GreaterThan(0)
                .WithMessage("Floor must be larger than 0.");

            RuleFor(apartment => apartment.UsefulSurface)
                .GreaterThan(0)
                .WithMessage("Useful surface must be larger than 0.");

            RuleFor(apartment => apartment.BuildYear)
                .InclusiveBetween(1901, DateTime.Now.Year)
                .WithMessage("The Build Year must be after 1900 and before " + (DateTime.Now.Year + 1));

            RuleFor(apartment => apartment.AddressId)
                .NotEmpty()
                .WithMessage("Address is required.");

            RuleFor(apartment => apartment.UserId)
                .NotEmpty()
                .WithMessage("User is required.");
        }
    }
}

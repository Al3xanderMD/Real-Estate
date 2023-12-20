using FluentValidation;

namespace RealEstate.Application.Features.Apartments.Commands.CreateApartament
{
    public class CreateApartmentCommandValidator : AbstractValidator<CreateApartmentCommand>
    {
        public CreateApartmentCommandValidator()
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

            RuleFor(p => p.RoomCount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.Comfort)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .InclusiveBetween(1, 4).WithMessage("{PropertyName} must be between 1 and 4.");

            RuleFor(p => p.Floor)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.UsefulSurface)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.BuildYear)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .InclusiveBetween(1901, DateTime.Now.Year + 1)
                .WithMessage("{PropertyName} must be between 1901 and Current Year.");

            RuleFor(p => p.PartitioningId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

        }
    }
}

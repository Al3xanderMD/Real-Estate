using FluentValidation;

namespace RealEstate.Application.Features.Houses.Commands.CreateHouse
{
    public class CreateHouseCommandValidator : AbstractValidator<CreateHouseCommand>
    {
        public CreateHouseCommandValidator()
        {
            RuleFor(p => p.RoomCount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.FloorCount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.UsefulSurface)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.LotArea)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.BuildYear)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .InclusiveBetween(1901, DateTime.Now.Year + 1);

            RuleFor(p => p.BasePostId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.HouseTypeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();


        }
    }
}

using FluentValidation;

namespace RealEstate.Application.Features.HouseTypes.Commands.CreateHouseType
{
    public class CreateHouseTypeCommandValidator : AbstractValidator<CreateHouseTypeCommand>
    {
        public CreateHouseTypeCommandValidator()
        {
            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}

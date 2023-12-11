using FluentValidation;

namespace RealEstate.Application.Features.HouseTypes.Commands.UpdateHouseType
{
	public class UpdateHouseTypeCommandValidator: AbstractValidator<UpdateHouseTypeCommand>
	{
		public UpdateHouseTypeCommandValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);
			RuleFor(x => x.Type)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
		}
	}
}

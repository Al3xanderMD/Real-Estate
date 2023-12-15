using FluentValidation;

namespace RealEstate.Application.Features.HotelPensions.Commands.UpdateHotelPension
{
	public class UpdateHotelPensionCommandValidator: AbstractValidator<UpdateHotelPensionCommand>
	{
		public UpdateHotelPensionCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);

			RuleFor(p => p.BasePostId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);

			RuleFor(p => p.UsefulSurface)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

			RuleFor(p => p.RoomSurface)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

			RuleFor(p => p.RoomCount)
				.NotNull().WithMessage("{PropertyName} is required.")
				.NotEmpty()
				.GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
		}
	}
}

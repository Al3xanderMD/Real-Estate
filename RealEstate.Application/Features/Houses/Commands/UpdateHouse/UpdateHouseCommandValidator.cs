using FluentValidation;

namespace RealEstate.Application.Features.Houses.Commands.UpdateHouse
{
	public class UpdateHouseCommandValidator: AbstractValidator<UpdateHouseCommand>
	{
		public UpdateHouseCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);
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
				.GreaterThan(1900).WithMessage("{PropertyName} must be greater than 0.");
			RuleFor(p => p.BasePostId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);
			RuleFor(p => p.HouseTypeId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);
			RuleFor(p => p.Comfort)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull();
		
		}
	}
}

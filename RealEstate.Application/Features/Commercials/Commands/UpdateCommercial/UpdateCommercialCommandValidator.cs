using FluentValidation;

namespace RealEstate.Application.Features.Commercials.Commands.UpdateCommercial
{
	public class UpdateCommercialCommandValidator: AbstractValidator<UpdateCommercialCommand>
	{
		public UpdateCommercialCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);
			RuleFor(p => p.UsefulSurface)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
			RuleFor(p => p.Disponibility)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull();
			RuleFor(p => p.BasePostId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);
			RuleFor(p => p.CommercialSpecificId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);
		
		}
	}
}

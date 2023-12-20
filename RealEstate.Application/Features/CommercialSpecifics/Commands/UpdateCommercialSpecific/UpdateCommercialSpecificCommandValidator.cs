using FluentValidation;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.UpdateCommercialSpecific
{
	public class UpdateCommercialSpecificCommandValidator: AbstractValidator<UpdateCommercialSpecificCommand>
	{
		public UpdateCommercialSpecificCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);

			RuleFor(p => p.SpecificName)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull();

			RuleFor(p => p.CommercialCategoryId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);
		}
	}
}

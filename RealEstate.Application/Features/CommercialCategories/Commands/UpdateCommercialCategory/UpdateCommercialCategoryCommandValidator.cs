using FluentValidation;

namespace RealEstate.Application.Features.CommercialCategories.Commands.UpdateCommercialCategory
{
	public class UpdateCommercialCategoryCommandValidator: AbstractValidator<UpdateCommercialCategoryCommand>
	{
		public UpdateCommercialCategoryCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull().WithMessage("{PropertyName} is required.");
			RuleFor(p => p.CategoryName)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull().WithMessage("{PropertyName} is required.");
		}
	}
}

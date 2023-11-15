using FluentValidation;

namespace RealEstate.Application.Features.CommercialCategories.Commands.CreateCommercialCategory
{
    public class CreateCommercialCategoryCommandValidator : AbstractValidator<CreateCommercialCategoryCommand>
    {
        public CreateCommercialCategoryCommandValidator()
        {
            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(32).WithMessage("{PropertyName} must not exceed 200 characters.");
        }
    }
}

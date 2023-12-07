using FluentValidation;

namespace RealEstate.Application.Features.LotClassifications.CreateLotClassifications
{
	public class CreateLotClassificationCommandValidator : AbstractValidator<CreateLotClassificationCommand>
    {
        public CreateLotClassificationCommandValidator()
        {
            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}

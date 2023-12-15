using FluentValidation;

namespace RealEstate.Application.Features.LotClassifications.Commands.UpdateLotClassification
{
	public class UpdateLotClassificationCommandValidator: AbstractValidator<UpdateLotClassificationCommand>
	{
		public UpdateLotClassificationCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);

			RuleFor(p => p.Type)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull();
		}
	}
}

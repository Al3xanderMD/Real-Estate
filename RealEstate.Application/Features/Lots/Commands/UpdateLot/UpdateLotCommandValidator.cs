using FluentValidation;

namespace RealEstate.Application.Features.Lots.Commands.UpdateLot
{
	public class UpdateLotCommandValidator: AbstractValidator<UpdateLotCommand>
	{
		public UpdateLotCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull().WithMessage("{PropertyName} is required.");

			RuleFor(p => p.BasePostId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull().WithMessage("{PropertyName} is required.");

			RuleFor(p => p.LotClassificationId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull().WithMessage("{PropertyName} is required.");

			RuleFor(p => p.LotArea)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull().WithMessage("{PropertyName} is required.");

			RuleFor(p => p.StreetFrontage)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull().WithMessage("{PropertyName} is required.");
		}
	}
}

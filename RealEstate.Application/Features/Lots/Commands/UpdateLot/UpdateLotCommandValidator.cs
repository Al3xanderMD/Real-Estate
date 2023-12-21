using FluentValidation;

namespace RealEstate.Application.Features.Lots.Commands.UpdateLot
{
	public class UpdateLotCommandValidator: AbstractValidator<UpdateLotCommand>
	{
		public UpdateLotCommandValidator()
		{
            RuleFor(p => p.BasePostId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.TitlePost)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.AddressId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.OfferType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(2000).WithMessage("{PropertyName} must not exceed 2000 characters.");

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

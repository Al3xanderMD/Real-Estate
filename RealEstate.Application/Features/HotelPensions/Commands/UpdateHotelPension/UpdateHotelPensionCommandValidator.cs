using FluentValidation;

namespace RealEstate.Application.Features.HotelPensions.Commands.UpdateHotelPension
{
	public class UpdateHotelPensionCommandValidator: AbstractValidator<UpdateHotelPensionCommand>
	{
		public UpdateHotelPensionCommandValidator()
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

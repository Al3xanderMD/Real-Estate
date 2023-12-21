using FluentValidation;

namespace RealEstate.Application.Features.BasePosts.Commands.UpdateBasePost
{
	public class UpdateBasePostCommandValidator: AbstractValidator<UpdateBasePostCommand>
	{
		public UpdateBasePostCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);

			RuleFor(p => p.TitlePost)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(200)
				.WithMessage("{PropertyName} must not exceed 200 characters.");

			RuleFor(p => p.Images)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull();

			RuleFor(p => p.OfferType)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull();

			RuleFor(p => p.Price)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull();

			RuleFor(p => p.AddressId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);

			RuleFor(p => p.Descripion)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(200)
				.WithMessage("{PropertyName} must not exceed 200 characters.");

			RuleFor(p => p.UserId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull();

		}	
	}
}

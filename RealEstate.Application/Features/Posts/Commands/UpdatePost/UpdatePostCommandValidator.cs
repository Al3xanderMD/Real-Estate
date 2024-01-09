using FluentValidation;

namespace RealEstate.Application.Features.Posts.Commands.UpdatePost
{
	public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommand>
	{
		public UpdatePostCommandValidator()
		{
			RuleFor(p => p.PostId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotEqual(Guid.Empty).WithMessage("{PropertyName} is required.");

			RuleFor(p => p.Type)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
		}
	}	
}

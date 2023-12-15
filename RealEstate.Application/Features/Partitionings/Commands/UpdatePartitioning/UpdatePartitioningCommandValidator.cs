using FluentValidation;

namespace RealEstate.Application.Features.Partitionings.Commands.UpdatePartitioning
{
	public class UpdatePartitioningCommandValidator : AbstractValidator<UpdatePartitioningCommand>
	{
		public UpdatePartitioningCommandValidator()
		{
			RuleFor(p => p.Id)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.NotEqual(Guid.Empty);

			RuleFor(p => p.Type)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(200)
				.WithMessage("{PropertyName} must not exceed 200 characters.");
			

		}

	}
}

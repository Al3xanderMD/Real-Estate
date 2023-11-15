using FluentValidation;

namespace RealEstate.Application.Features.Partitionings.Commands.CreatePartitioning
{
    public class CreatePartitioningCommandValidator : AbstractValidator<CreatePartitioningCommand>
    {
        public CreatePartitioningCommandValidator()
        {
            RuleFor(p => p.Type)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}

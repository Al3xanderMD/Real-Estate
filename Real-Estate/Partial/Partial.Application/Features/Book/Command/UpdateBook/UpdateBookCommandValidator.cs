using FluentValidation;

namespace Partial.Application.Features.Book.Command.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(b => b.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .NotEqual(System.Guid.Empty);

            RuleFor(b => b.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(b => b.Author)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(b => b.YearPublication)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .LessThanOrEqualTo(2023)
                .WithMessage("Year must be less than or equal to 2023.");

        }
    }
}

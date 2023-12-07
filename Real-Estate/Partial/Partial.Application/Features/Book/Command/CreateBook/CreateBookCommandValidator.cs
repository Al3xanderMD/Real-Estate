using FluentValidation;

namespace Partial.Application.Features.Book.Command.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Title is required.");

            RuleFor(b => b.Author)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Author is required.");

            RuleFor(b => b.YearPublication)
                .NotEmpty()
                .WithMessage("Year is required.")
                .LessThanOrEqualTo(2023)
                .WithMessage("Year must be less than or equal to 2023.");
                
        }
    }
}

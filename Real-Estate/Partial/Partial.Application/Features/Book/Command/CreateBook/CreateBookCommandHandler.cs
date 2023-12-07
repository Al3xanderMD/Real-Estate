using MediatR;
using Partial.Application.Persistance;

namespace Partial.Application.Features.Book.Command.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
    {
        private readonly IBookRepository repository;

        public CreateBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {
                return new CreateBookCommandResponse
                {
                    Success = false,
                    ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            var book = Domain.Entities.Book.Create(request.Title, request.Author, request.YearPublication);

            if(!book.IsSuccess)
            {
                return new CreateBookCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { book.Error }
                };
            }

            await repository.AddAsync(book.Value);

            return new CreateBookCommandResponse
            {
                Success = true,
                Book = new CreateBookDto
                {
                    Id = book.Value.Id,
                    Title = book.Value.Title,
                    Author = book.Value.Author,
                    YearPublication = book.Value.YearPublication
                }
            };
        }
    }
}

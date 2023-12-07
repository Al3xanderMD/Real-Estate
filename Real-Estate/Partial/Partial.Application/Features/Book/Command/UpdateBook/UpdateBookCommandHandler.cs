using MediatR;
using Partial.Application.Persistance;

namespace Partial.Application.Features.Book.Command.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdateBookCommandResponse>
    {
        private readonly IBookRepository repository;

        public UpdateBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateBookCommandResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await repository.FindByIdAsync(request.Id);
            var validator = new UpdateBookCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {
               return new UpdateBookCommandResponse
               {
                   Success = false, 
                   ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
               };
            }

            if(!book.IsSuccess)
            {
                return new UpdateBookCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { book.Error }
                };
            }

            book.Value.Update(request.Title, request.Author, request.YearPublication);
            var updatedBook = await repository.UpdateAsync(book.Value);

            if(!updatedBook.IsSuccess)
            {
                return new UpdateBookCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { updatedBook.Error }
                };
            }

            return new UpdateBookCommandResponse
            {
                Success = true,
                Book = new UpdateBookDto
                {
                    Title = updatedBook.Value.Title,
                    Author = updatedBook.Value.Author,
                    YearPublication = updatedBook.Value.YearPublication
                }
            };
        }
    }
}

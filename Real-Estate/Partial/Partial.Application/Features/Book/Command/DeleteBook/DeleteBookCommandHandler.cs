using MediatR;
using Partial.Application.Persistance;

namespace Partial.Application.Features.Book.Command.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, DeleteBookCommandResponse>
    {
        private readonly IBookRepository repository;

        public DeleteBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if(!result.IsSuccess)
            {
                return new DeleteBookCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteBookCommandResponse
            {
                Success = true
            };
        }
    }
}

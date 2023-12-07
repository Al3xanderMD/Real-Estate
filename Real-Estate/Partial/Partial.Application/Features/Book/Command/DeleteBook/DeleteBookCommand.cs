using MediatR;

namespace Partial.Application.Features.Book.Command.DeleteBook
{
    public class DeleteBookCommand : IRequest<DeleteBookCommandResponse>
    {
        public Guid Id { get; set; }
    }
}

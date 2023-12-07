using MediatR;

namespace Partial.Application.Features.Book.Command.UpdateBook
{
    public class UpdateBookCommand : IRequest<UpdateBookCommandResponse>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public int YearPublication { get; set; } = default!;
    }
}

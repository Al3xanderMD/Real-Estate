using MediatR;

namespace Partial.Application.Features.Book.Command.CreateBook
{
    public class CreateBookCommand : IRequest<CreateBookCommandResponse>
    {
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public int YearPublication { get; set; } = default!;
    }
}

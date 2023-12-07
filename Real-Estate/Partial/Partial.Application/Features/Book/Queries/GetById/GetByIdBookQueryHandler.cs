using MediatR;
using Partial.Application.Persistance;

namespace Partial.Application.Features.Book.Queries.GetById
{
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery, BookDto>
    {
        private readonly IBookRepository repository;

        public GetByIdBookQueryHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task<BookDto> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
        {
            var book = await repository.FindByIdAsync(request.Id);

            if(book.IsSuccess)
            {
                return new BookDto
                {
                    Id = book.Value.Id,
                    Title = book.Value.Title,
                    Author = book.Value.Author,
                    YearPublication = book.Value.YearPublication
                };
            }
            return new BookDto();
        }
    }
}

using MediatR;
using Partial.Application.Persistance;

namespace Partial.Application.Features.Book.Queries.GetAll
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, GetAllBooksQueryResponse>
    {
        private readonly IBookRepository repository;

        public GetAllBooksQueryHandler(IBookRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllBooksQueryResponse> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            GetAllBooksQueryResponse response = new();
            var result = await repository.GetAllAsync();

            if(result.IsSuccess)
            {
                response.Books = result.Value.Select(x => new BookDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Author  = x.Author,
                    YearPublication = x.YearPublication
                }).ToList();
            }
            return response;
        }
    }
}

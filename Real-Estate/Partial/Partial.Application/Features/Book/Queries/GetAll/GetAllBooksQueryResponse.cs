namespace Partial.Application.Features.Book.Queries.GetAll
{
    public class GetAllBooksQueryResponse
    {
        public List<BookDto> Books { get; set; } = new List<BookDto>();
    }
}

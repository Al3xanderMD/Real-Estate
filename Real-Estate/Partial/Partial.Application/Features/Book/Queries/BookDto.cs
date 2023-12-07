namespace Partial.Application.Features.Book.Queries
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? YearPublication { get; set; } 
    }
}

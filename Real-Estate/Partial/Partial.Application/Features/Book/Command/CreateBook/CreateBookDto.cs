namespace Partial.Application.Features.Book.Command.CreateBook
{
    public class CreateBookDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? YearPublication { get; set; }
    }
}

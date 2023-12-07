namespace Partial.Application.Features.Book.Command.UpdateBook
{
    public class UpdateBookDto
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int? YearPublication { get; set; }
    }
}

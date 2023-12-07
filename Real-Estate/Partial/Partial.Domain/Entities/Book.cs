using Partial.Domain.Common;

namespace Partial.Domain.Entities
{
    public class Book : AuditableEntity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int YearPublication { get; private set;  }

        public Book (string title, string author, int yearPublication)
        {
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            YearPublication = yearPublication;
        }

        public static Result<Book> Create(string title, string author, int yearPublication)
        {
            if (string.IsNullOrWhiteSpace(title))
                return Result<Book>.Failure("Title cannot be empty");

            if (string.IsNullOrWhiteSpace(author))
                return Result<Book>.Failure("Author cannot be empty");

            if (yearPublication == 0)
                return Result<Book>.Failure("YearPubication cannot be empty");

            return Result<Book>.Success(new Book(title, author, yearPublication));
        }

        public void AttachTitle (string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
              Title = title;
        }

        public void AttachAuthor (string author)
        {
            if (!string.IsNullOrWhiteSpace(author))
              Author = author;
        }

        public void AttachYearPubication (int yearPubication)
        {
            if (yearPubication != 0)
              YearPublication = yearPubication;
        }

        public void Update(string title, string author, int yearPublication)
        {
            if (!string.IsNullOrWhiteSpace(title))
                Title = title;

            if (!string.IsNullOrWhiteSpace(author))
                Author = author;

            if (yearPublication != 0)
                YearPublication = yearPublication;
        }
    }
}

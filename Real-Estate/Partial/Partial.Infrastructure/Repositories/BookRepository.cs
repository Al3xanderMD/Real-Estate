using Partial.Application.Persistance;
using Partial.Domain.Entities;

namespace Partial.Infrastructure.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(PartialContext context) : base(context)
        {
        }
    }
}

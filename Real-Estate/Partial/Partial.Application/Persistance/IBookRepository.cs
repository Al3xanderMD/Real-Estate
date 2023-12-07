using Partial.Domain.Entities;

namespace Partial.Application.Persistance
{
    public interface IBookRepository : IAsyncRepository<Book>
    {
    }
}

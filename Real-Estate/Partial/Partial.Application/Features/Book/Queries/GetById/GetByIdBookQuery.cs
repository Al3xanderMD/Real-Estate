using MediatR;

namespace Partial.Application.Features.Book.Queries.GetById
{
    public record GetByIdBookQuery(Guid Id) : IRequest<BookDto>;

}

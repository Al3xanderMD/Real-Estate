using MediatR;

namespace RealEstate.Application.Features.Clients.Queries.GetById
{
    public record GetByIdClientQuery(Guid ClientId) : IRequest<ClientDto>;
}

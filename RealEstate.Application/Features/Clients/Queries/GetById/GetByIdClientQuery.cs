using MediatR;

namespace RealEstate.Application.Features.Clients.Queries.GetById
{
    public record GetByIdClientQuery(Guid UserId) : IRequest<ClientDto>;
}

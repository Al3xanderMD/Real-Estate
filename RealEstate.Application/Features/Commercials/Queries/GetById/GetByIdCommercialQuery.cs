using MediatR;

namespace RealEstate.Application.Features.Commercials.Queries.GetById
{
    public record GetByIdCommercialQuery(Guid Id) : IRequest<CommercialDto>;
}

using MediatR;

namespace RealEstate.Application.Features.Lots.Queries.GetById
{
    public record GetByIdLotQuery(Guid Id) : IRequest<LotDto>;

}

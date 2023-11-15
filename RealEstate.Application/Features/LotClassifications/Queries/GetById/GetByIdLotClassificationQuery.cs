using MediatR;

namespace RealEstate.Application.Features.LotClassifications.Queries.GetById
{
    public record GetByIdLotClassificationQuery(Guid Id) : IRequest<LotClassificationDto>;

}

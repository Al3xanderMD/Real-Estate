using MediatR;

namespace RealEstate.Application.Features.CommercialSpecifics.Queries.GetById
{
    public record GetByIdCommercialSpecificQuery(Guid CommercialSpecificId) : IRequest<CommercialSpecificDto>;
}

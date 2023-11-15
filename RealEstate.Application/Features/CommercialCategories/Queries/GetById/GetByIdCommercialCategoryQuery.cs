using MediatR;

namespace RealEstate.Application.Features.CommercialCategories.Queries.GetById
{
    public record GetByIdCommercialCategoryQuery(Guid Id) : IRequest<CommercialCategoryDto>;
}

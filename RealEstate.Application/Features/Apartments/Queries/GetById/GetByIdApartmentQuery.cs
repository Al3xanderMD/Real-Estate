using MediatR;

namespace RealEstate.Application.Features.Apartments.Queries.GetById
{
    public record GetByIdApartmentQuery(Guid Id) : IRequest<ApartmentDto>;

}

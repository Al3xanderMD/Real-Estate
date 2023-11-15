using MediatR;

namespace RealEstate.Application.Features.Houses.Queries.GetById
{
    public record GetByIdHouseQuery(Guid Id) : IRequest<HouseDto>;
}

using MediatR;

namespace RealEstate.Application.Features.HouseTypes.Queries.GetById
{
    public record GetByIdHouseTypeQuery(Guid Id) : IRequest<HouseTypeDto>;

}

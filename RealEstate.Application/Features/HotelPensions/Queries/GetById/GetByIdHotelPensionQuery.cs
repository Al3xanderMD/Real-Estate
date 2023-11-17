using MediatR;

namespace RealEstate.Application.Features.HotelPensions.Queries.GetById
{
    public record GetByIdHotelPensionQuery(Guid Id) : IRequest<HotelPensionDto>;
}

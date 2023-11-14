using MediatR;

namespace RealEstate.Application.Features.Addresses.Queries.GetById
{
    public record GetByIdAddressQuery(Guid Id) : IRequest<AddressDto>;
}

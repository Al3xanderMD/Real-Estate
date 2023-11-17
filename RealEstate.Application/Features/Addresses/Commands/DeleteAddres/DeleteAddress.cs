using MediatR;

namespace RealEstate.Application.Features.Addresses.Commands.DeleteAddres
{
    public class DeleteAddress : IRequest<DeleteAddressResponse>
    {
        public Guid Id { get; set; }
    }
}

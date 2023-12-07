using MediatR;

namespace RealEstate.Application.Features.Addresses.Commands.DeleteAddres
{
    public class DeleteAddressCommand : IRequest<DeleteAddressCommandResponse>
    {
        public Guid Id { get; set; }
    }
}

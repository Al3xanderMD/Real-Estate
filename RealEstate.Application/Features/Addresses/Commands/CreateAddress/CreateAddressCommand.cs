using MediatR;

namespace RealEstate.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<CreateAddressCommandResponse>
    {
        public string Url { get; set; } = default!;
        public string AddressName { get; set; } = default!;
    }
}

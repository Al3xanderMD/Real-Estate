using MediatR;

namespace RealEstate.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<UpdateAddressCommandResponse>
    {
        public Guid Id { get; set; } 
        public string Url { get; set; } = default!;
        public string AddressName { get; set; } = default!;
    }
}

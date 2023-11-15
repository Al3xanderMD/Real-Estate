using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandResponse : BaseResponse
    {
        public CreateAddressCommandResponse() : base() { }

        public CreateAddressDto Address { get; set; }
    }
}

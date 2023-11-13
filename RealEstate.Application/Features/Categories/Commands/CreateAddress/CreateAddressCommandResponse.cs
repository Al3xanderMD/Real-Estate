using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Categories.Commands.CreateAddress
{
    public class CreateAddressCommandResponse : BaseResponse
    {
        public CreateAddressCommandResponse() : base() { }

        public CreateAddressDto Address { get; set; }
    }
}

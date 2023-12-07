using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Addresses.Commands.UpdateAddress
{
	public class UpdateAddressCommandResponse : BaseResponse
    {
        public UpdateAddressCommandResponse() : base()
        {
        }

        public UpdateAddressDto Address { get; set; }
    }


}

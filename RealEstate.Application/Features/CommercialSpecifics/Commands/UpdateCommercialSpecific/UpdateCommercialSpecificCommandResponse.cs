using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.UpdateCommercialSpecific
{
	public class UpdateCommercialSpecificCommandResponse: BaseResponse
	{
		public UpdateCommercialSpecificCommandResponse(): base()
		{
		}
		public UpdateCommercialSpecificDto CommercialSpecific { get; set; }
	}
}
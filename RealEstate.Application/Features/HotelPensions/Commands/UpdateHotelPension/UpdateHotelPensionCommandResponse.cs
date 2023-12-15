using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.HotelPensions.Commands.UpdateHotelPension
{
	public class UpdateHotelPensionCommandResponse: BaseResponse
	{
		public UpdateHotelPensionCommandResponse(): base()
		{
		}
		public UpdateHotelPensionDto HotelPension { get; set; }
	}
}
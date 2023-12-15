using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.HouseTypes.Commands.UpdateHouseType
{
	public class UpdateHouseTypeCommandResponse: BaseResponse
	{
		public UpdateHouseTypeCommandResponse(): base()
		{
		}
		public UpdateHouseTypeDto HouseType { get; set; }
	}
}
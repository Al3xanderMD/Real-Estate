using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Houses.Commands.UpdateHouse
{
	public class UpdateHouseCommandResponse: BaseResponse
	{
		public UpdateHouseCommandResponse(): base()
		{	
		}
		public UpdateHouseDto House { get; set; }
	}
}
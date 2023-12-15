using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Lots.Commands.UpdateLot
{
	public class UpdateLotCommandResponse: BaseResponse
	{
		public UpdateLotCommandResponse() : base()
		{
		}
		public UpdateLotDto Lot { get; set; }
	}
}
using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Lots.Commands.CreateLot
{
	public class CreateLotCommandResponse : BaseResponse
    {
        public CreateLotCommandResponse() : base()
        {

        }

        public CreateLotDTO Lot { get; set; }
    }
}

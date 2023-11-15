using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Houses.Commands.CreateHouse
{
    public class CreateHouseCommandResponse : BaseResponse
    {
        public CreateHouseCommandResponse() : base()
        {
        }

        public CreateHouseDTO House { get; set; }
    }
}
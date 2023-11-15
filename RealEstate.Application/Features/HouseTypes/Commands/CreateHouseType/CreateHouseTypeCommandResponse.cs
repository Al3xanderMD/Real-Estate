using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.HouseTypes.Commands.CreateHouseType
{
    public class CreateHouseTypeCommandResponse : BaseResponse
    {
        public CreateHouseTypeCommandResponse() : base()
        {
        }

        public CreateHouseTypeDTO HouseType { get; set; }
    }
}

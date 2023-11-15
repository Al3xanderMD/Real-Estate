using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.HotelPensions.Commands.CreateHotelPension
{
    public class CreateHotelPensionCommandResponse : BaseResponse
    {
        public CreateHotelPensionCommandResponse() : base() { }
        public CreateHotelPensionDto HotelPension { get; set; }
    }
}

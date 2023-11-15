using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.CreateCommercialSpecific
{
    public class CreateCommercialSpecificCommandResponse : BaseResponse
    {
        public CreateCommercialSpecificCommandResponse() 
            : base() 
        { 
        }

        public CreateCommercialSpecificDto CommercialSpecific {  get; set; }
    }
}

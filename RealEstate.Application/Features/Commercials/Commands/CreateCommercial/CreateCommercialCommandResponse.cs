using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Commercials.Commands.CreateCommercial
{
    public class CreateCommercialCommandResponse : BaseResponse
    {
        public CreateCommercialCommandResponse() : base() { }
        public CreateCommercialDto Commercial { get; set;}
    }
}

using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Categories.Commands.CreateClient
{
    public class CreateClientCommandResponse : BaseResponse
    {
        public CreateClientCommandResponse() 
            : base()
        {
        }

        public CreateClientDto Client { get; set; }
    }
}

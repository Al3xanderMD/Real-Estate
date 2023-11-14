using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Categories.Commands.CreateBasePost
{
    public class CreateBasePostCommandResponse : BaseResponse
    {
        public CreateBasePostCommandResponse() : base()
        {
        }

        public CreateBasePostDto BasePost { get; set; }
    }
}

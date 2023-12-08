using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.BasePosts.Commands.UpdateBasePost
{
	public class UpdateBasePostCommandResponse: BaseResponse
	{
		public UpdateBasePostCommandResponse(): base()
		{
		}
		public UpdateBasePostDto BasePost { get; set; }
	}
}
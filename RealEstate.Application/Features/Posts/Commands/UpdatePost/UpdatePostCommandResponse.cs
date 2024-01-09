using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Posts.Commands.UpdatePost
{
	public class UpdatePostCommandResponse : BaseResponse
	{
		public UpdatePostCommandResponse() : base()
		{
		}

		public UpdatePostDto Post { get; set; }
	}
}

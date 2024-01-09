using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Posts.Commands.CreatePost
{
	public class CreatePostCommandResponse : BaseResponse
	{
		public CreatePostCommandResponse() : base()
		{
		}

		public CreatePostDto Post { get; set; }
	}
}

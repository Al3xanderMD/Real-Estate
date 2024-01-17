using MediatR;

namespace RealEstate.Application.Features.Posts.Commands.CreatePost
{
	public class CreatePostCommand : IRequest<CreatePostCommandResponse>
	{
		public Guid BasePostId { get; set; } = default!;
		public string Type { get; set; } = default!;
	}
}

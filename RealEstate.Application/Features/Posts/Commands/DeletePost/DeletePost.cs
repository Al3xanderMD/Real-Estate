using MediatR;

namespace RealEstate.Application.Features.Posts.Commands.DeletePost
{
	public class DeletePost : IRequest<DeletePostResponse>
	{
		public Guid PostId { get; set; }
	}
}

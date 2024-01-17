using MediatR;

namespace RealEstate.Application.Features.Posts.Commands.UpdatePost
{
	public class UpdatePostCommand : IRequest<UpdatePostCommandResponse>
	{
		public int Id { get; set; }
		public Guid PostId { get; set; }
		public string Type { get; set; } = default!;
	}
}

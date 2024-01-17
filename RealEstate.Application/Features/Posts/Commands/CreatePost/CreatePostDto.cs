using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Posts.Commands.CreatePost
{
	public class CreatePostDto
	{
		public Guid BasePostId { get; set; }
		public string? Type { get; set; }
	}
}

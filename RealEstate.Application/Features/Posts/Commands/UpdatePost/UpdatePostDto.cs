namespace RealEstate.Application.Features.Posts.Commands.UpdatePost
{
	public class UpdatePostDto
	{
		public Guid PostId { get; set; }
		public string? Type { get; set; }
	}
}

using RealEstate.Application.Features.BasePosts.Queries;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Posts.Queries
{
	public class PostsDto
	{
		public int Id { get; set; }
		public Guid BasePostId { get; set; }
		public BasePost BasePost { get; set; }
		public string Type { get; set; }
	}
}

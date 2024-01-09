using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
	public class PostRepository : BaseRepository<Post>, IPostRepository
	{
		public PostRepository(RealEstateContext dbContext) : base(dbContext)
		{
		}
	}
}

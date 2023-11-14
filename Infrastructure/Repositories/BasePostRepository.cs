using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class BasePostRepository : BaseRepository<BasePost>, IBasePostRepository
    {
        public BasePostRepository(RealEstateContext context) : base(context)
        {
        }
    }
}

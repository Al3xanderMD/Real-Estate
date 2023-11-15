using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class PartitioningRepository : BaseRepository<Partitioning>, IPartitioningRepository
    {
        public PartitioningRepository(RealEstateContext context) : base(context)
        { }
    }
}

using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class CommercialCategoryRepository : BaseRepository<CommercialCategory>, ICommercialCategoryRepository
    {
        public CommercialCategoryRepository(RealEstateContext context) : base(context)
        {
        }
    }
}

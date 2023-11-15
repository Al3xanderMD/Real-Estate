using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class CommercialSpecificRepository : BaseRepository<CommercialSpecific>, ICommercialSpecificRepository
    {
        public CommercialSpecificRepository(RealEstateContext context) : base(context)
        {
        }
    }
}

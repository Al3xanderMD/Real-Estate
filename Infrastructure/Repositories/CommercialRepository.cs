using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class CommercialRepository : BaseRepository<Commercial>, ICommercialRepository
    {
        public CommercialRepository(RealEstateContext context) : base(context)
        {
        }
    }
}

using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class LotRepository : BaseRepository<Lot>, ILotRepository
    {
        public LotRepository(RealEstateContext context) : base(context)
        {
        }
    }
}

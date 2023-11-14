using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class HouseRepository : BaseRepository<House>, IHouseRepository
    {
        public HouseRepository(RealEstateContext context) : base(context)
        {
        }
    }
}

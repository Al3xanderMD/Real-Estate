using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class HouseTypeRepository : BaseRepository<HouseType>, IHouseTypeRepository
    {
        public HouseTypeRepository(RealEstateContext context) : base(context)
        {
        }
    }
}

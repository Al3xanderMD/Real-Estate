using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class HotelPensionRepository : BaseRepository<HotelPension>, IHotelPensionRepository
    {
        public HotelPensionRepository(RealEstateContext context) : base(context)
        {
        }
    }
}

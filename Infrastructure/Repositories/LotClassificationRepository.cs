using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
	public class LotClassificationRepository : BaseRepository<LotClassification>, ILotClassificationRepository
    {
        public LotClassificationRepository(RealEstateContext context) : base(context)
        {
        }
    }
}

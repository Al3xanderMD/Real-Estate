using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace Infrastructure.Repositories
{
    public class FavouritesRepository : BaseRepository<Favourite>, IFavouritesRepository
    {
        public FavouritesRepository(RealEstateContext context) : base(context)
        {
        }
    }
}

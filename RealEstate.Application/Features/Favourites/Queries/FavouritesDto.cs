using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Favourites.Queries
{
    public class FavouritesDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BasePostId { get; set; }
        public BasePost BasePost { get; set; } 
    }
}

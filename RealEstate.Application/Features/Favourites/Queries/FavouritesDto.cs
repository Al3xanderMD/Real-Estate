namespace RealEstate.Application.Features.Favourites.Queries
{
    public class FavouritesDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BasePostId { get; set; }
    }
}

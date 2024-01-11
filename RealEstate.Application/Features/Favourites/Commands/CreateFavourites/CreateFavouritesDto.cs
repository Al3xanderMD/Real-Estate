namespace RealEstate.Application.Features.Favourites.Commands.CreateFavourites
{
    public class CreateFavouritesDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BasePostId { get; set; }
    }
}

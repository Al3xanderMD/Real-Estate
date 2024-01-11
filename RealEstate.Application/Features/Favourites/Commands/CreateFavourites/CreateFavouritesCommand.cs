using MediatR;

namespace RealEstate.Application.Features.Favourites.Commands.CreateFavourites
{
    public class CreateFavouritesCommand : IRequest<CreateFavouritesCommandResponse>
    {
        public Guid UserId { get; set; }
        public Guid BasePostId { get; set; }
    }
}

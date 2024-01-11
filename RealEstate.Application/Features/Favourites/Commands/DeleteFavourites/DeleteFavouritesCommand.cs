using MediatR;

namespace RealEstate.Application.Features.Favourites.Commands.DeleteFavourites
{
    public class DeleteFavouritesCommand : IRequest<DeleteFavouritesCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
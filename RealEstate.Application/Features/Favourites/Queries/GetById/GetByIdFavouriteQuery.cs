using MediatR;

namespace RealEstate.Application.Features.Favourites.Queries.GetById
{
    public record GetByIdFavouriteQuery(Guid Id) : IRequest<FavouritesDto>;
}

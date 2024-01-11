using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Favourites.Queries.GetById
{
    public class GetByIdFavouriteQueryHandler : IRequestHandler<GetByIdFavouriteQuery, FavouritesDto>
    {
        private readonly IFavouritesRepository repository;

        public GetByIdFavouriteQueryHandler(IFavouritesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<FavouritesDto> Handle(GetByIdFavouriteQuery request, CancellationToken cancellationToken)
        {
            var favourite = await repository.FindByIdAsync(request.Id);

            if (favourite.IsSuccess)
            {
                return new FavouritesDto
                {
                    Id = favourite.Value.Id,
                    UserId = favourite.Value.UserId,
                    BasePostId = favourite.Value.BasePostId
                };
            }
            return new FavouritesDto();
        }
    }
}

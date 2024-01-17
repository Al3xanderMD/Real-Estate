using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Favourites.Queries.GetAll
{
    public class GetAllFavouritesQueryHandler : IRequestHandler<GetAllFavouritesQuery, GetAllFavouritesResponse>
    {
        private readonly IFavouritesRepository repository;

        public GetAllFavouritesQueryHandler(IFavouritesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllFavouritesResponse> Handle(GetAllFavouritesQuery request, CancellationToken cancellationToken)
        {
            GetAllFavouritesResponse response = new();
            var result = await repository.GetAllAsync();

            if (result.IsSuccess)
            {
                response.Favourites = result.Value.Select(favourites => new FavouritesDto
                {
                    Id = favourites.Id,
                    UserId = favourites.UserId,
                    BasePostId = favourites.BasePostId
                }).ToList();
            }
            return response;
        }
    }
}

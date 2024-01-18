using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Favourites.Queries.GetAll
{
    public class GetAllFavouritesQueryHandler : IRequestHandler<GetAllFavouritesQuery, GetAllFavouritesResponse>
    {
        private readonly IFavouritesRepository repository;
        private readonly IBasePostRepository basePostRepository;

        public GetAllFavouritesQueryHandler(IFavouritesRepository repository, IBasePostRepository basePostRepository)
        {
            this.repository = repository;
            this.basePostRepository = basePostRepository;
        }

        public async Task<GetAllFavouritesResponse> Handle(GetAllFavouritesQuery request, CancellationToken cancellationToken)
        {
            GetAllFavouritesResponse response = new();
            var result = await repository.GetAllAsync();
            var result2 = await basePostRepository.GetAllAsync();

            if (result.IsSuccess)
            {
                response.Favourites = result.Value.Select(favourites => new FavouritesDto
                {
                    Id = favourites.Id,
                    UserId = favourites.UserId,
                    BasePostId = favourites.BasePostId,
                    BasePost = favourites.BasePost,
                }).ToList();
            }
            return response;
        }
    }
}

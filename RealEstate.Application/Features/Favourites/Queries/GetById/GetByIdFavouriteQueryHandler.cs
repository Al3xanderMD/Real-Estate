using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Favourites.Queries.GetById
{
    public class GetByIdFavouriteQueryHandler : IRequestHandler<GetByIdFavouriteQuery, FavouritesDto>
    {
        private readonly IFavouritesRepository repository;
        private readonly IBasePostRepository basePostRepository;

        public GetByIdFavouriteQueryHandler(IFavouritesRepository repository, IBasePostRepository basePostRepository)
        {
            this.repository = repository;
            this.basePostRepository = basePostRepository;
        }

        public async Task<FavouritesDto> Handle(GetByIdFavouriteQuery request, CancellationToken cancellationToken)
        {
            var favourite = await repository.FindByIdAsync(request.Id);
            var result2 = await basePostRepository.GetAllAsync();

            if (favourite.IsSuccess)
            {
                return new FavouritesDto
                {
                    Id = favourite.Value.Id,
                    UserId = favourite.Value.UserId,
                    BasePostId = favourite.Value.BasePostId,
                    BasePost = favourite.Value.BasePost,
                };
            }
            return new FavouritesDto();
        }
    }
}

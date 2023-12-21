using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.BasePosts.Queries.GetAll
{
    public class GetAllBasePostsQueryHandler : IRequestHandler<GetAllBasePostsQuery, GetAllBasePostsResponse>
    {
        private readonly IBasePostRepository repository;

        public GetAllBasePostsQueryHandler(IBasePostRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllBasePostsResponse> Handle(GetAllBasePostsQuery request, CancellationToken cancellationToken)
        {
            GetAllBasePostsResponse response = new();
            var result = await repository.GetAllAsync();

            if(result.IsSuccess)
            {
                response.BasePosts = result.Value.Select(basePost => new BasePostDto
                {
                    BasePostId = basePost.BasePostId,
                    TitlePost = basePost.TitlePost,
                    Price = basePost.Price,
                    AddressId = basePost.AddressId,
                    OfferType = basePost.OfferType,
                    UserId = basePost.UserId,
                    Description = basePost.Description
                }).ToList();
            }
            return response;
        }
    }
}

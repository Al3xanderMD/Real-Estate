using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.BasePosts.Queries.GetById
{
    public class GetByIdBasePostQueryHandler : IRequestHandler<GetByIdBasePostQuery, BasePostDto>
    {
        private readonly IBasePostRepository repository;

        public GetByIdBasePostQueryHandler(IBasePostRepository repository)
        {
            this.repository = repository;
        }

        public async Task<BasePostDto> Handle(GetByIdBasePostQuery request, CancellationToken cancellationToken)
        {
            var basePost = await repository.FindByIdAsync(request.BasePostId);

            if(basePost.IsSuccess)
            {
                return new BasePostDto
                {
                    BasePostId = basePost.Value.BasePostId,
                    TitlePost = basePost.Value.TitlePost,
                    Price = basePost.Value.Price,
                    AddressId = basePost.Value.AddressId,
                    OfferType = basePost.Value.OfferType,
                    UserId = basePost.Value.UserId
                };
            }
            return new BasePostDto();
        }
    }
}

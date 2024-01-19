using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Posts.Queries.GetById
{
    public class GetByUserIdQueryHandler : IRequestHandler<GetByUserIdQuery, List<PostsDto>>
    {
        private readonly IPostRepository repository;
        private readonly IBasePostRepository basePostRepository;
        private readonly IAddressRepository addressRepository;

        public GetByUserIdQueryHandler(IPostRepository repository, IBasePostRepository basePostRepository, IAddressRepository addressRepository)
        {
            this.repository = repository;
            this.basePostRepository = basePostRepository;
            this.addressRepository = addressRepository;
        }

        public async Task<List<PostsDto>> Handle(GetByUserIdQuery request, CancellationToken cancellationToken)
        {
            List<PostsDto> posts = new List<PostsDto>();
            var post = await repository.FindByUserIdAsync(request.userId);
            var result2 = await basePostRepository.GetAllAsync();
            var result3 = await addressRepository.GetAllAsync();

            if (post.IsSuccess)
            {

                foreach (var p in post.Value)
                {
                    posts.Add(new PostsDto
                    {
                        Id = p.Id,
                        BasePostId = p.BasePostId,
                        BasePost = p.BasePost,
                        Type = p.Type
                    });


                }
                return posts;
            }

            return posts;
        }
    }
}

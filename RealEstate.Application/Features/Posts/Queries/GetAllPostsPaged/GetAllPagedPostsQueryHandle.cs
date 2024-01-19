//using MediatR;
//using RealEstate.Application.Persistence;

//namespace RealEstate.Application.Features.Posts.Queries.GetAllPostsPaged
//{
//    public class GetAllPagedPostsQueryHandle : IRequestHandler<GetAllPagedPostsQuery, GetAllPagedPostsQueryResponse>
//    {
//        private readonly IPostRepository repository;
//        private readonly IBasePostRepository basePostRepository;
//        private readonly IAddressRepository addressRepository;

//        public GetAllPagedPostsQueryHandle(IPostRepository repository, IAddressRepository addressRepository, IBasePostRepository basePostRepository)
//        {
//            this.repository = repository;
//            this.addressRepository = addressRepository;
//            this.basePostRepository = basePostRepository;
//        }

//        public Task<GetAllPagedPostsQueryResponse> Handle(GetAllPagedPostsQuery request, CancellationToken cancellationToken)
//        {
//            GetAllPagedPostsQueryResponse response = new();
//            var result = repository.GetPagedReponseAsync(request.Page, request.Size);

//            if (result.IsSuccess)
//            {
//                response.Posts = result.Value.Select(p => new PostsDto
//                {
//                    Id = p.Id,
//                    BasePostId = p.BasePostId,
//                    BasePost = p.BasePost,
//                    Type = p.Type
//                }).ToList();
//            }

//            return response;
//        }
//    }
//}

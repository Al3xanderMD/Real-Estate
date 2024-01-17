using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Posts.Queries.GetAll
{
	public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, GetAllPostsResponse>
	{
		private readonly IPostRepository repository;
		private readonly IBasePostRepository basePostRepository;
		private readonly IAddressRepository addressRepository;
		
		public GetAllPostsQueryHandler(IPostRepository repository, IBasePostRepository basePostRepository, IAddressRepository addressRepository)
		{
			this.repository = repository;
			this.basePostRepository = basePostRepository;
			this.addressRepository = addressRepository;
		}

		public async Task<GetAllPostsResponse> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
		{
			GetAllPostsResponse response = new();
			var result = await repository.GetAllAsync();
			var result2 = await basePostRepository.GetAllAsync();
			var result3 = await addressRepository.GetAllAsync();
			

			if (result.IsSuccess)
			{
				response.Posts = result.Value.Select(p => new PostsDto
				{
					Id = p.Id,
                    BasePostId = p.BasePostId,
					BasePost = p.BasePost,
					Type = p.Type
				}).ToList();
			}

			return response;
		}
	}
}

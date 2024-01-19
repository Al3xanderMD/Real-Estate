using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Posts.Queries.GetById
{
	public class GetByBasePostIdQueryHandler : IRequestHandler<GetByBasePostIdPostQuery, PostsDto>
	{
		private readonly IPostRepository repository;
		private readonly IBasePostRepository basePostRepository;
		private readonly IAddressRepository addressRepository;

		public GetByBasePostIdQueryHandler(IPostRepository repository, IBasePostRepository basePostRepository, IAddressRepository addressRepository)
			{
			this.repository = repository;
			this.basePostRepository = basePostRepository;
			this.addressRepository = addressRepository;
		}

		public async Task<PostsDto> Handle(GetByBasePostIdPostQuery request, CancellationToken cancellationToken)
		{
			var post = await repository.FindByBasePostIdAsync(request.Id);
			var result2 = await basePostRepository.GetAllAsync();
			var result3 = await addressRepository.GetAllAsync();

			if (post.IsSuccess)
			{
				return new PostsDto
				{
					Id = post.Value.Id,
					BasePostId = post.Value.BasePostId,
					BasePost = post.Value.BasePost,
					Type = post.Value.Type
				};
			}

			return new PostsDto();
		}
	}
}

using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Posts.Queries.GetById
{
	public class GetByIdPostQueryHandler : IRequestHandler<GetByIdPostQuery, PostsDto>
	{
		private readonly IPostRepository repository;

		public GetByIdPostQueryHandler(IPostRepository repository)
		{
			this.repository = repository;
		}

		public async Task<PostsDto> Handle(GetByIdPostQuery request, CancellationToken cancellationToken)
		{
			var post = await repository.FindByIntIdAsync(request.Id);
			if (post.IsSuccess) 
			{
				return new PostsDto
				{
					BasePostId = post.Value.BasePostId,
					BasePost = post.Value.BasePost,
					Type = post.Value.Type
				};
			}

			return new PostsDto();
		}
	}
}

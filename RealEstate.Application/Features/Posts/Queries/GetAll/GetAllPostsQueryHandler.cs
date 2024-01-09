using MediatR;
using RealEstate.Application.Features.Partitionings.Queries.GetAll;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Posts.Queries.GetAll
{
	public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, GetAllPostsResponse>
	{
		private readonly IPostRepository repository;
		
		public GetAllPostsQueryHandler(IPostRepository repository)
		{
			this.repository = repository;
		}

		public async Task<GetAllPostsResponse> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
		{
			GetAllPostsResponse response = new();
			var result = await repository.GetAllAsync();

			if (result.IsSuccess)
			{
				response.Posts = result.Value.Select(p => new PostsDto
				{
					Id = p.Id,
					PostId = p.PostId,
					Type = p.Type
				}).ToList();
			}

			return response;
		}
	}
}

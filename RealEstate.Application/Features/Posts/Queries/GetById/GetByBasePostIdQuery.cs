using MediatR;

namespace RealEstate.Application.Features.Posts.Queries.GetById
{
	public record GetByBasePostIdPostQuery(Guid Id) : IRequest<PostsDto>;
}

using MediatR;

namespace RealEstate.Application.Features.Posts.Queries.GetById
{
	public record GetByIdPostQuery(Guid PostId) : IRequest<PostsDto>;
}

using MediatR;

namespace RealEstate.Application.Features.Posts.Queries.GetById
{
	public record GetByIdPostQuery(int Id) : IRequest<PostsDto>;
}

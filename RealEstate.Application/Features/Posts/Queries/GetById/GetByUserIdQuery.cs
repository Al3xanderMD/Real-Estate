using MediatR;

namespace RealEstate.Application.Features.Posts.Queries.GetById
{
    public record GetByUserIdQuery(Guid userId) : IRequest<List<PostsDto>>;
}

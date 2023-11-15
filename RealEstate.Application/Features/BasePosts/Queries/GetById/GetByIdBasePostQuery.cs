using MediatR;

namespace RealEstate.Application.Features.BasePosts.Queries.GetById
{
    public record GetByIdBasePostQuery(Guid BasePostId) : IRequest<BasePostDto>;
}

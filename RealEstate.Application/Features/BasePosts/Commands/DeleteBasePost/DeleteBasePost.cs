using MediatR;

namespace RealEstate.Application.Features.BasePosts.Commands.DeleteBasePost
{
    public class DeleteBasePost : IRequest<DeleteBasePostResponse>
    {
        public Guid BasePostId { get; set; }
    }
}

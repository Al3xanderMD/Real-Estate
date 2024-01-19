using MediatR;

namespace RealEstate.Application.Features.Posts.Queries.GetAllPostsPaged
{
    public class GetAllPagedPostsQuery : IRequest<GetAllPagedPostsQueryResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}

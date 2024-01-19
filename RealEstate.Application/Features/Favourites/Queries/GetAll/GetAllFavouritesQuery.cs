using MediatR;

namespace RealEstate.Application.Features.Favourites.Queries.GetAll
{
    public class GetAllFavouritesQuery : IRequest<GetAllFavouritesResponse>
    {
        public Guid? UserId { get; set; }
		public Guid? BasePostId { get; set; }
    }
}

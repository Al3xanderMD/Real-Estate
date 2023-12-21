using MediatR;

namespace RealEstate.Application.Features.Houses.Commands.DeleteHouse
{
    public class DeleteHouse : IRequest<DeleteHouseResponse>
    {
        public Guid BasePostId { get; set; }
    }
}

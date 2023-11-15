using MediatR;

namespace RealEstate.Application.Features.Lots.Commands.DeleteLot
{
    public class DeleteLot : IRequest<DeleteLotResponse>
    {
        public Guid Id { get; set; }
    }
}

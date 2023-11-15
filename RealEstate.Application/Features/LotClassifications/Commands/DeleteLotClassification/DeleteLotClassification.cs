using MediatR;

namespace RealEstate.Application.Features.LotClassifications.Command.DeleteLotClassification
{
    public class DeleteLotClassification : IRequest<DeleteLotClassificationResponse>
    {
        public Guid Id { get; set; }
    }
}

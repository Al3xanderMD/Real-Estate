using MediatR;

namespace RealEstate.Application.Features.LotClassifications.CreateLotClassifications
{
    public class CreateLotClassificationCommand : IRequest<CreateLotClassificationCommandResponse>
    {
        public string Type { get; set; } = default!;
    }

}

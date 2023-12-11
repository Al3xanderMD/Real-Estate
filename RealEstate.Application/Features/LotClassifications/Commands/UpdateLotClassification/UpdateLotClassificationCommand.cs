using MediatR;

namespace RealEstate.Application.Features.LotClassifications.Commands.UpdateLotClassification
{
	public class UpdateLotClassificationCommand: IRequest<UpdateLotClassificationCommandResponse>
	{
		public Guid Id { get; set; }
		public string Type { get; set; } = default!;
	}
}

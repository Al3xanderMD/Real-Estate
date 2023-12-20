using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.LotClassifications.Commands.UpdateLotClassification
{
	public class UpdateLotClassificationCommandResponse: BaseResponse
	{
		public UpdateLotClassificationCommandResponse(): base()
		{
		}
		public UpdateLotClassificationDto LotClassification { get; set; }
	}
}
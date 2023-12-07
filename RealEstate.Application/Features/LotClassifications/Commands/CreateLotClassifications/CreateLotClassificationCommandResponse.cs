using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.LotClassifications.CreateLotClassifications
{
	public class CreateLotClassificationCommandResponse : BaseResponse
    {
        public CreateLotClassificationCommandResponse() : base()
        {
        }

        public CreateLotClassificationDTO LotClassification { get; set; }
    }
}

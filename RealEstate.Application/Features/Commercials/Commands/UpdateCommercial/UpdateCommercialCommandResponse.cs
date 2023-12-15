using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.Commercials.Commands.UpdateCommercial
{
	public class UpdateCommercialCommandResponse: BaseResponse
	{
		public UpdateCommercialCommandResponse(): base()
		{
		}
		public UpdateCommercialDto Commercial { get; set; }
	}
}
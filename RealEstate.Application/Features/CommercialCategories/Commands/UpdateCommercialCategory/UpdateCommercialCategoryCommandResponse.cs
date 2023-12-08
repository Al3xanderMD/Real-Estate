using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.CommercialCategories.Commands.UpdateCommercialCategory
{
	public class UpdateCommercialCategoryCommandResponse: BaseResponse
	{
		public UpdateCommercialCategoryCommandResponse(): base()
		{
		}
		public UpdateCommercialCategoryDto CommercialCategory { get; set; }
	}
}
using RealEstate.Application.Responses;

namespace RealEstate.Application.Features.CommercialCategories.Commands.CreateCommercialCategory
{
    public class CreateCommercialCategoryCommandResponse : BaseResponse
    {
        public CreateCommercialCategoryCommandResponse() 
            : base() 
        {
        }

        public CreateCommercialCategoryDto CommercialCategory { get; set; }
    }
}

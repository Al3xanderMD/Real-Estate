using MediatR;

namespace RealEstate.Application.Features.CommercialCategories.Commands.CreateCommercialCategory
{
    public class CreateCommercialCategoryCommand : IRequest<CreateCommercialCategoryCommandResponse>
    {
        public string CategoryName { get; set; } = default!;
    }
}

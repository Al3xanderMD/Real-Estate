using MediatR;

namespace RealEstate.Application.Features.CommercialCategories.Commands.DeleteCommercialCategory
{
    public class DeleteCommercialCategory : IRequest<DeleteCommercialCategoryResponse>
    {
        public Guid Id { get; set; }
    }
}

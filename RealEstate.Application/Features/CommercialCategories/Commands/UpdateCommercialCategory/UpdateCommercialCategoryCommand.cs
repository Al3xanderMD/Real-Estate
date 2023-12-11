using MediatR;

namespace RealEstate.Application.Features.CommercialCategories.Commands.UpdateCommercialCategory
{
	public class UpdateCommercialCategoryCommand: IRequest<UpdateCommercialCategoryCommandResponse>
	{
		public Guid Id { get; set; }
		public string CategoryName { get; set; } = default!;
	}
}

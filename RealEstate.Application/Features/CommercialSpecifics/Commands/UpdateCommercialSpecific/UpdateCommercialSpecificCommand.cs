using MediatR;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.UpdateCommercialSpecific
{
	public class UpdateCommercialSpecificCommand: IRequest<UpdateCommercialSpecificCommandResponse>
	{
		public Guid Id { get; set; }
		public string SpecificName { get; set; } = default!;
		public Guid CommercialCategoryId { get; set; }
	}
}

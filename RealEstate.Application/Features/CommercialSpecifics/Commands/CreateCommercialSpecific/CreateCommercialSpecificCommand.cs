using MediatR;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.CreateCommercialSpecific
{
	public class CreateCommercialSpecificCommand : IRequest<CreateCommercialSpecificCommandResponse>
    {
        public string SpecificName { get; set; } = default!;
        public Guid CommercialCategoryId { get; set; } 
    }
}

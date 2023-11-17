using MediatR;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.DeleteCommercialSpecific
{
    public class DeleteCommercialSpecific : IRequest<DeleteCommercialSpecificResponse>
    {
        public Guid CommercialSpecificId { get; set; }
    }
}

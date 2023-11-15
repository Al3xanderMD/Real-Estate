using MediatR;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.CommercialSpecifics.Commands.CreateCommercialSpecific
{
    public class CreateCommercialSpecificCommand : IRequest<CreateCommercialSpecificCommandResponse>
    {
        public string SpecificName { get; set; } = default!;
        public Guid CommercialCategoryId { get; set; } 
    }
}

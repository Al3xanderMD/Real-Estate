using MediatR;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Commercials.Commands.CreateCommercial
{
    public class CreateCommercialCommand : IRequest<CreateCommercialCommandResponse>
    {
        public BasePost BasePost { get; set; } = default!;
        public Guid BasePostId { get; set; } = default!;
        public Guid CommercialSpecificId { get; set; } = default!;
        public double UsefulSurface { get; set; } = default!;
        public DateTime? Disponibility { get; set; } = default!;
    }
}

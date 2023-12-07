using MediatR;

namespace RealEstate.Application.Features.Commercials.Commands.CreateCommercial
{
	public class CreateCommercialCommand : IRequest<CreateCommercialCommandResponse>
    {
        public Guid BasePostId { get; set; } 
        public Guid CommercialSpecificId { get; set; } 
        public double UsefulSurface { get; set; } = default!;
        public DateTime? Disponibility { get; set; } = default!;
    }
}

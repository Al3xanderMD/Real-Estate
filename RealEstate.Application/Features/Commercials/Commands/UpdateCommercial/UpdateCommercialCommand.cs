using MediatR;

namespace RealEstate.Application.Features.Commercials.Commands.UpdateCommercial
{
	public class UpdateCommercialCommand: IRequest<UpdateCommercialCommandResponse>
	{
		public Guid Id { get; set; }
		public double UsefulSurface { get; set; } = default!;
		public DateTime Disponibility { get; set; } = default!;
		public Guid BasePostId { get; set; }
		public Guid CommercialSpecificId { get; set; }
	}
}

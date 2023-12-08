using MediatR;

namespace RealEstate.Application.Features.Apartments.Commands.UpdateApartment
{
	public class UpdateApartmentCommand : IRequest<UpdateApartmentCommandResponse>
	{
		public Guid Id { get; set; }
		public int RoomCount { get; set; } = default!;
		public int Comfort { get; set; } = default!;
		public int Floor { get; set; } = default!;
		public double UsefulSurface { get; set; } = default!;
		public int BuildYear { get; set; } = default!;
		public Guid BasePostId { get; set; }
		public Guid PartitioningId { get; set; }
	}
}

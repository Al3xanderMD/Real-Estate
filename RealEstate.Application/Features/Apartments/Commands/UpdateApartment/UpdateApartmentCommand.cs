using MediatR;

namespace RealEstate.Application.Features.Apartments.Commands.UpdateApartment
{
	public class UpdateApartmentCommand : IRequest<UpdateApartmentCommandResponse>
	{
        public Guid BasePostId { get; set; }
        public string UserId { get; set; } = default!;
		public string TitlePost { get; set; } = default!;
		public double Price { get; set; } = default!;
		public Guid AddressId { get; set; } = default!;
		public bool OfferType { get; set; } = default!;
		public string Description { get; set; } = default!;
		public int RoomCount { get; set; } = default!;
		public int Comfort { get; set; } = default!;
		public int Floor { get; set; } = default!;
		public double UsefulSurface { get; set; } = default!;
		public int BuildYear { get; set; } = default!;
		public Guid PartitioningId { get; set; }
	}
}

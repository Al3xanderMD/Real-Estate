namespace RealEstate.Application.Features.Apartments.Commands.UpdateApartament
{
	public class UpdateApartmentDto
	{
		public int? RoomCount { get; set; }
		public int? Comfort { get; set; }
		public int? Floor { get; set; }
		public double? UsefulSurface { get; set; }
		public int? BuildYear { get; set; }
		public Guid BasePostId { get; set; }
		public Guid PartitioningId { get; set; }
	}
}

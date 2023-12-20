namespace RealEstate.Application.Features.HotelPensions.Commands.UpdateHotelPension
{
	public class UpdateHotelPensionDto
	{
		public Guid BasePostId { get; set; }
		public string UserId { get; set; } = default!;
		public string TitlePost { get; set; } = default!;
		public double Price { get; set; }
		public Guid AddressId { get; set; }
		public bool OfferType { get; set; }
		public string Description { get; set; } = default!;
		public double? UsefulSurface { get; set; }
		public double? RoomSurface { get; set; }
		public int? RoomCount { get; set; }
	}
}

namespace RealEstate.Application.Features.HotelPensions.Commands.UpdateHotelPension
{
	public class UpdateHotelPensionDto
	{
		public Guid BasePostId { get; set; }
		public double? UsefulSurface { get; set; }
		public double? RoomSurface { get; set; }
		public int? RoomCount { get; set; }
	}
}

namespace RealEstate.Application.Features.Houses.Commands.UpdateHouse
{
	public class UpdateHouseDto
	{
		public Guid BasePostId { get; set; }
		public int? RoomCount { get; set; }
		public Guid HouseTypeId { get; set; }
		public int? Comfort { get; set; }
		public int? FloorCount { get; set; }
		public double? UsefulSurface { get; set; }
		public double? LotArea { get; set; }
		public int? BuildYear { get; set; }
	}
}

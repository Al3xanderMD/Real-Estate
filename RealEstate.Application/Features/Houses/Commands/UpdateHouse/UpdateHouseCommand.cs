using MediatR;

namespace RealEstate.Application.Features.Houses.Commands.UpdateHouse
{
	public class UpdateHouseCommand: IRequest<UpdateHouseCommandResponse>
	{
		public Guid Id { get; set; }
		public Guid BasePostId { get; set; }
		public int RoomCount { get; set; } = default!;
		public Guid HouseTypeId { get; set; }
		public int Comfort { get; set; } = default!;
		public int FloorCount { get; set; } = default!;
		public double UsefulSurface { get; set; } = default!;
		public double LotArea { get; set; } = default!;
		public int BuildYear { get; set; } = default!;
	}
}

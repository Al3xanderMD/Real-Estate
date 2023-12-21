using MediatR;

namespace RealEstate.Application.Features.Houses.Commands.UpdateHouse
{
	public class UpdateHouseCommand: IRequest<UpdateHouseCommandResponse>
	{
        public Guid BasePostId { get; set; }
        public string UserId { get; set; } = default!;
        public string TitlePost { get; set; } = default!;
        public double Price { get; set; } = default!;
        public Guid AddressId { get; set; } = default!;
        public bool OfferType { get; set; } = default!;
		public string Description { get; set; } = default!;
        public int RoomCount { get; set; } = default!;
		public Guid HouseTypeId { get; set; }
		public int Comfort { get; set; } = default!;
		public int FloorCount { get; set; } = default!;
		public double UsefulSurface { get; set; } = default!;
		public double LotArea { get; set; } = default!;
		public int BuildYear { get; set; } = default!;
	}
}

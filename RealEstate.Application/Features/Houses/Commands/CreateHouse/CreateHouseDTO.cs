namespace RealEstate.Application.Features.Houses.Commands.CreateHouse
{
    public class CreateHouseDTO
    {
        public Guid BasePostId { get; set; }
        public string UserId { get; set; } = default!;
        public string TitlePost { get; set; } = default!;
        public double Price { get; set; }
        public Guid AddressId { get; set; }
        public bool OfferType { get; set; }
        public string Description { get; set; } = default!;
        public int? RoomCount { get; set; }
        public int? FloorCount { get; set; }
        public double? UsefulSurface { get; set; }
        public double? LotArea { get; set; }
        public int? BuildYear { get; set; }
        public Guid HouseTypeId { get; set; }

    }
}

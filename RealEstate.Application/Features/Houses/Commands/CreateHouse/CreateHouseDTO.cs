namespace RealEstate.Application.Features.Houses.Commands.CreateHouse
{
    public class CreateHouseDTO
    {
        public Guid Id { get; set; }
        public int? RoomCount { get; set; }
        public int? FloorCount { get; set; }
        public double? UsefulSurface { get; set; }
        public double? LotArea { get; set; }
        public int? BuildYear { get; set; }
        public Guid BasePostId { get; set; }
        public Guid HouseTypeId { get; set; }

    }
}

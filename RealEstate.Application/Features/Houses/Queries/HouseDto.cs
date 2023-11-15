namespace RealEstate.Application.Features.Houses.Queries
{
    public class HouseDto
    {
        public Guid Id { get; set; }
        public int RoomCount { get; set; } = default!;
        public int FloorCount { get; set; } = default!;
        public double UsefulSurface { get; set; } = default!;
        public double LotArea { get; set; } = default!;
        public int BuildYear { get; set; } = default!;
        public Guid BasePostId { get; set; }
        public Guid HouseTypeId { get; set; }
    }
}

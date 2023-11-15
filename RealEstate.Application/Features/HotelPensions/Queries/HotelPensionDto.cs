using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.HotelPensions.Queries
{
    public class HotelPensionDto
    {
        public Guid Id { get; set; }
        public Guid BasePostId { get; set; }
        public double UsefulSurface { get; set; } = default!;
        public double RoomSurface { get; set; } = default!;
        public int RoomCount { get; set; } = default!;
    }
}

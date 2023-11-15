namespace RealEstate.Application.Features.Apartments.Commands.CreateApartament
{
    public class CreateApartmentDTO
    {
        public Guid Id { get; set; }
        public int? RoomCount { get; set; }
        public int? Comfort { get; set; }
        public int? Floor { get; set; }
        public double? UsefulSurface { get; set; }
        public int? BuildYear { get; set; }
        public Guid BasePostId { get; set; }
        public Guid PartitioningId { get; set; }
    }
}

namespace RealEstate.Application.Features.Apartments.Commands.CreateApartament
{
    public class CreateApartmentDTO
    {
        public Guid BasePostId { get; set; }
        public string UserId { get; set; } = default!;
        public string TitlePost { get; set; } = default!;
        public double Price { get; set; }
        public Guid AddressId { get; set; }
        public bool OfferType { get; set; }
        public string Description { get; set; } = default!;
        public int? RoomCount { get; set; }
        public int? Comfort { get; set; }
        public int? Floor { get; set; }
        public double? UsefulSurface { get; set; }
        public int? BuildYear { get; set; }
        public Guid PartitioningId { get; set; }
    }
}

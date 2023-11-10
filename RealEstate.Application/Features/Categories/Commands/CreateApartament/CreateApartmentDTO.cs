namespace RealEstate.Application.Features.Categories.Commands.CreateApartament
{
    public class CreateApartmentDTO
    {
        public Guid PostId { get; set; }
        public string? TitlePost { get; set; }
        public bool? OfferType { get; set; }
        public List<string>? Image { get; set; }
        public double? Price { get; set; }
        public string? Descripion { get; set; }
        public int? RoomCount { get; set; }
        public Guid PartitioningId { get; set; }
        public int? Comfort { get; set; }
        public int? Floor { get; set; }
        public double? UsefulSurface { get; set; }
        public int? BuildYear { get; set; }
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }


    }
}

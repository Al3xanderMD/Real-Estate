namespace RealEstate.Application.Features.Commercials.Queries
{
    public class CommercialDto
    {
        public Guid BasePostId { get; set; }
        public string UserId { get; set; } = default!;
        public string TitlePost { get; set; } = default!;
        public double Price { get; set; } = default!;
        public Guid AddressId { get; set; } = default!;
        public bool OfferType { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Guid CommercialSpecificId { get; set; }
        public double UsefulSurface { get; set; } = default!;
        public DateTime Disponibility { get; set; } = default!;
    }
}

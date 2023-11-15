namespace RealEstate.Application.Features.BasePosts.Queries
{
    public class BasePostDto
    {
        public Guid BasePostId { get; set; }
        public string TitlePost { get; set; } = default!;
        public double Price { get; set; } = default!;
        public Guid AddressId { get; set; }
        public bool OfferType { get; set; } = default!;
        public Guid UserId { get; set; }
    }
}

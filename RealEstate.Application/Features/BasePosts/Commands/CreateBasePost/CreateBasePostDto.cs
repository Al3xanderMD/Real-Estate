namespace RealEstate.Application.Features.Categories.Commands.CreateBasePost
{
    public class CreateBasePostDto
    {
        public Guid BasePostId { get; set; }
        public string? TitlePost { get; set; }
        public double? Price { get; set; }
        public Guid AddressId { get; set; }
        public bool? OfferType { get; set; }
        public string? UserId { get; set; }
        public string? Description { get; set; }
    }
}

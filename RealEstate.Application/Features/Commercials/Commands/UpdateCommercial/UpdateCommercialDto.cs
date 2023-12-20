namespace RealEstate.Application.Features.Commercials.Commands.UpdateCommercial
{
	public class UpdateCommercialDto
	{
        public Guid BasePostId { get; set; }
        public string UserId { get; set; } = default!;
        public string TitlePost { get; set; } = default!;
        public double Price { get; set; }
        public Guid AddressId { get; set; }
        public bool OfferType { get; set; }
        public string Description { get; set; } = default!;
        public double? UsefulSurface { get; set; }
		public DateTime? Disponibility { get; set; }
		public Guid CommercialSpecificId { get; set; }
	}
}

using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Lots.Commands.UpdateLot
{
	public class UpdateLotDto
	{
        public Guid BasePostId { get; set; }
        public string UserId { get; set; } = default!;
        public string TitlePost { get; set; } = default!;
        public double Price { get; set; }
        public Guid AddressId { get; set; }
        public bool OfferType { get; set; }
        public string Description { get; set; } = default!;
		public double? LotArea { get; set; }
		public double? StreetFrontage { get; set; }
        public Guid LotClassificationId { get; set; }
    }
}

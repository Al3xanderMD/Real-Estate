using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Lots.Commands.UpdateLot
{
	public class UpdateLotDto
	{
		public Guid BasePostId { get; set; }
		public BasePost? BasePost { get; set; }
		public Guid LotClassificationId { get; set; }
		public LotClassification? LotClassification { get; set; }
		public double? LotArea { get; set; }
		public double? StreetFrontage { get; set; }
	}
}

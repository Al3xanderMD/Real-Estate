namespace RealEstate.Application.Features.Lots.Commands.CreateLot
{
	public class CreateLotDTO
    {
        public Guid Id { get; set; }
        public Guid BasePostId { get; set; }
        public double? LotArea { get; set; }
        public double? StreetFrontage { get; set; }
        public Guid LotClassificationId { get; set; }
    }
}

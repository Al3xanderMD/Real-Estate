namespace RealEstate.Application.Features.Lots.Queries
{
    public class LotDto
    {
        public Guid Id { get; set; }
        public Guid BasePostId { get; set; }
        public double LotArea { get; set; } = default!;
        public double StreetFrontage { get; set; } = default!;
        public Guid LotClassificationId { get; set; }
    }
}

namespace RealEstate.Application.Features.Commercials.Queries
{
    public class CommercialDto
    {
        public Guid Id { get; set; }
        public Guid BasePostId { get; set; }
        public Guid CommercialSpecificId { get; set; }
        public double UsefulSurface { get; set; } = default!;
        public DateTime? Disponibility { get; set; } = default!;
    }
}

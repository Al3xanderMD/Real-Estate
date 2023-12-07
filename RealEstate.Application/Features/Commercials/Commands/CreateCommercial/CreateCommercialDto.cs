namespace RealEstate.Application.Features.Commercials.Commands.CreateCommercial
{
	public class CreateCommercialDto
    {
        public Guid Id { get; set; }
        public Guid BasePostId { get; set; }
        public Guid CommercialSpecificId { get; set; }
        public double? UsefulSurface { get; set; }
        public DateTime? Disponibility { get; set; }
    }
}

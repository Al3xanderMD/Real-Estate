namespace RealEstate.Application.Features.Commercials.Commands.UpdateCommercial
{
	public class UpdateCommercialDto
	{
		public double? UsefulSurface { get; set; }
		public DateTime? Disponibility { get; set; }
		public Guid BasePostId { get; set; }
		public Guid CommercialSpecificId { get; set; }
	}
}

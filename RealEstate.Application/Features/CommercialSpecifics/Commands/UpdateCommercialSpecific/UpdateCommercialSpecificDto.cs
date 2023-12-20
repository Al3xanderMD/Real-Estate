namespace RealEstate.Application.Features.CommercialSpecifics.Commands.UpdateCommercialSpecific
{
	public class UpdateCommercialSpecificDto
	{
		public string? SpecificName { get; set; }
		public Guid CommercialCategoryId { get; set; }
	}
}

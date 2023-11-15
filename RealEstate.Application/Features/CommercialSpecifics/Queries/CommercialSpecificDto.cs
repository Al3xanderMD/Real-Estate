namespace RealEstate.Application.Features.CommercialSpecifics.Queries
{
    public class CommercialSpecificDto
    {
        public Guid CommercialSpecificId { get; set; }
        public string SpecificName { get; set; } = default!;
        public Guid CommercialCategoryId { get; set; }
    }
}

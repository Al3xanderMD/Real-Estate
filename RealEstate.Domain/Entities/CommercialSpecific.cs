using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class CommercialSpecific
    {
        public Guid CommercialSpecificId { get; private set; }
        public string SpecificName { get; private set; }
        public CommercialCategory CommercialCategoryId { get; private set; }

        public CommercialSpecific(string specificName, CommercialCategory commercialCategoryId)
        {
            CommercialSpecificId = Guid.NewGuid();
            SpecificName = specificName;
            CommercialCategoryId = commercialCategoryId;
        }

        public static Result<CommercialSpecific> CreateCommercialSpecific(string specificName, CommercialCategory commercialCategoryId)
        {
            if (string.IsNullOrWhiteSpace(specificName))
                return Result<CommercialSpecific>.Failure("Specific name is required");

            return Result<CommercialSpecific>.Success(new CommercialSpecific(specificName, commercialCategoryId));
        }

        
    }
}

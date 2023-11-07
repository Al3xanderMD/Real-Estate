using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class CommercialSpecific
    {
        public Guid IdCommercialSpecific { get; private set; }
        public string SpecificName { get; private set; }
        public CommercialCategory IdCommercialCategory { get; private set; }

        public CommercialSpecific(string specificName, CommercialCategory idCommercialCategory)
        {
            IdCommercialSpecific = Guid.NewGuid();
            SpecificName = specificName;
            IdCommercialCategory = idCommercialCategory;
        }

        public static Result<CommercialSpecific> CreateCommercialSpecific(string specificName, CommercialCategory idCommercialCategory)
        {
            if (string.IsNullOrWhiteSpace(specificName))
                return Result<CommercialSpecific>.Failure("Specific name is required");

            return Result<CommercialSpecific>.Success(new CommercialSpecific(specificName, idCommercialCategory));
        }

        
    }
}

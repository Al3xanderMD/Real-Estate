using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class CommercialSpecific : AuditableEntity
    {
        public Guid CommercialSpecificId { get; private set; }
        public string SpecificName { get; private set; }
        public Guid CommercialCategoryId { get; private set; }
        public CommercialCategory CommercialCategory { get; private set; } = null!;

        private CommercialSpecific(string specificName, Guid commercialCategoryId)
        {
            CommercialSpecificId = Guid.NewGuid();
            SpecificName = specificName;
            CommercialCategoryId = commercialCategoryId;
        }

        private CommercialSpecific(CommercialCategory commercialCategory, Guid commercialCategoryId, string specificName) : this(specificName, commercialCategoryId)
        {
            CommercialCategory = commercialCategory;
        }

        public static Result<CommercialSpecific> Create(string specificName, Guid commercialCategoryId)
        {
            if (string.IsNullOrWhiteSpace(specificName))
                return Result<CommercialSpecific>.Failure("Specific name is required");

            return Result<CommercialSpecific>.Success(new CommercialSpecific(specificName, commercialCategoryId));
        }

        
    }
}

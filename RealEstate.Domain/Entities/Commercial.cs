using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Commercial : AuditableEntity
    {
       
        public CommercialSpecific CommercialSpecificId { get; private set; }
        public double UsefulSurface { get; private set; }
        public DateTime? Disponibility { get; private set; }

        public Commercial(CommercialSpecific idCommercialSpecific, double usefulSurface, DateTime? disponibility)
        {
            CommercialSpecificId = idCommercialSpecific;
            UsefulSurface = usefulSurface;
            Disponibility = disponibility;
        }

        public static Result<Commercial> CreateCommercial(CommercialSpecific commercialSpecificId, double usefulSurface, DateTime? disponibility)
        {
            if (commercialSpecificId == null)
                return Result<Commercial>.Failure("Commercial specific is required");

            if (usefulSurface <= 0)
                return Result<Commercial>.Failure("Useful surface must be greater than 0");

            return Result<Commercial>.Success(new Commercial(commercialSpecificId, usefulSurface, disponibility));
        }
    }
}

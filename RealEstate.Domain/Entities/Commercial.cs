using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Commercial : AuditableEntity
    {
        public Guid Id { get; private set; }
        public Guid BasePostId { get; private set; }
        public BasePost BasePost { get; private set; } = null!;
        public Guid CommercialSpecificId { get; private set; }
        public CommercialSpecific CommercialSpecific { get; private set; } = null!;
        public double UsefulSurface { get; private set; }
        public DateTime? Disponibility { get; private set; }

        

        private Commercial(Guid basePostId ,Guid commercialSpecificId, double usefulSurface)
        {
            Id = Guid.NewGuid();
            BasePostId = basePostId;
            CommercialSpecificId = commercialSpecificId;
            UsefulSurface = usefulSurface;
        }

        private Commercial(BasePost basePost, CommercialSpecific commercialSpecific, Guid basePostId, Guid commercialSpecificId, double usefulSurface) : this(basePostId, commercialSpecificId, usefulSurface)
        {
            BasePost = basePost;
            CommercialSpecific = commercialSpecific;
        }

        public static Result<Commercial> Create(Guid basePostId, Guid commercialSpecificId, double usefulSurface)
        {
            if (commercialSpecificId == null)
            {
                return Result<Commercial>.Failure("Commercial specific is required");
            }

            if (usefulSurface <= 0)
                return Result<Commercial>.Failure("Useful surface must be greater than 0");

            return Result<Commercial>.Success(new Commercial(basePostId, commercialSpecificId, usefulSurface));
        }

        public void AttachDisponibility(DateTime? disponibility)
        {
            if(disponibility != null)
            {
                Disponibility = disponibility;
            }
        }
    }
}

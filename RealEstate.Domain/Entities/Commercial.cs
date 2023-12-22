using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table("Commercials")]
    public class Commercial : BasePost
    {
        public Guid CommercialSpecificId { get; private set; }
        public CommercialSpecific CommercialSpecific { get; private set; } = null!;
        public double UsefulSurface { get; private set; }
        public DateTime Disponibility { get; private set; }

        private Commercial(string userId, string titlePost, double price, Guid addressId, bool offerType, string description,
            Guid commercialSpecificId, double usefulSurface, DateTime disponibility)
            : base(userId, titlePost, price, addressId, offerType, description)
        {
            CommercialSpecificId = commercialSpecificId;
            UsefulSurface = usefulSurface;
            Disponibility = disponibility;
        }

        public Commercial(CommercialSpecific commercialSpecific, Guid commercialSpecificId, double usefulSurface, DateTime disponibility,
            string userId, string titlePost, double price, Guid addressId, bool offerType, string description) 
            : this(userId, titlePost, price, addressId, offerType,description, commercialSpecificId, usefulSurface, disponibility)
        {
            CommercialSpecific = commercialSpecific;
        }

        public static Result<Commercial> Create(string userId, string titlePost, double price, Guid addressId, bool offerType, string description,
            Guid commercialSpecificId, double usefulSurface, DateTime disponibility)
        {
            if (string.IsNullOrWhiteSpace(titlePost))
                return Result<Commercial>.Failure("'TitlePost' must not be empty");
            if (price <= 0)
                return Result<Commercial>.Failure("'Price' must be greater than 0");
            if (addressId == Guid.Empty)
                return Result<Commercial>.Failure("'AddressId' must not be empty");
            if (commercialSpecificId == Guid.Empty)
                return Result<Commercial>.Failure("'CommercialSpecificId' must not be empty"); 
            if (usefulSurface <= 0)
                return Result<Commercial>.Failure("Useful surface must be greater than 0");
            if (disponibility < DateTime.Now)
                return Result<Commercial>.Failure("Disponibility must be greater than today");
            if (string.IsNullOrWhiteSpace(description))
                return Result<Commercial>.Failure("'Description' must not be empty");

            return Result<Commercial>.Success(new Commercial(userId, titlePost, price, addressId, offerType, description,
                commercialSpecificId, usefulSurface, disponibility));
        }

        public void AttachDisponibility(DateTime disponibility)
        {
            if (disponibility > DateTime.Now)
            {
                Disponibility = disponibility;
            }
        }

        public void AttachCommercialSpecificId(Guid commercialSpecificId)
        {
            if(commercialSpecificId != Guid.Empty)
            {
				CommercialSpecificId = commercialSpecificId;
			}
        }

        public void AttachUsefulSurface(double usefulSurface)
        {
			if(usefulSurface > 0)
            {
                UsefulSurface = usefulSurface;
            }
        }

        public void AttachUserId(string userId)
        {
            if (!string.IsNullOrWhiteSpace(userId))
            {
                UserId = userId;
            }
        }

        public new void AttachTitlePost(string titlePost)
        {
            if (!string.IsNullOrWhiteSpace(titlePost))
            {
                TitlePost = titlePost;
            }
        }

        public new void AttachPrice(double price)
        {
            if (price > 0)
            {
                Price = price;
            }
        }

        public new void AttachAddressId(Guid addressId)
        {
            if (addressId != Guid.Empty)
            {
                AddressId = addressId;
            }
        }

        public new void AttachOfferType(bool offerType)
        {
            OfferType = offerType;
        }

        public new void AttachDescription(string description)
        {
            Description = description;
        }
    }
}

using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table("Lots")]
    public class Lot : BasePost
    {
        private Lot(string userId, string titlePost, double price, Guid addressId, bool offerType, string description,
            double lotArea, double streetFrontage, Guid lotClassificationId)
            : base(userId, titlePost, price, addressId, offerType, description)
        {
            LotArea = lotArea;
            StreetFrontage = streetFrontage;
            LotClassificationId = lotClassificationId;
        }

        private Lot(LotClassification lotClassification, double lotArea,double streetFrontage, Guid lotClassificationId,
            string userId, string titlePost, double price, Guid addressId, bool offerType, string description) 
            : this (userId, titlePost, price, addressId, offerType,description, lotArea, streetFrontage, lotClassificationId)
        {
            LotClassification = lotClassification;
        }

        public Guid LotClassificationId { get; private set; }
        public LotClassification LotClassification { get; private set; } = null!;
        public double LotArea { get; private set; }
        public double StreetFrontage { get; private set; }

        public static Result<Lot> Create(string userId, string titlePost, double price, Guid addressId, bool offerType, string description,
            double lotArea, double streetFrontage, Guid lotClassificationId)
        {
            if (string.IsNullOrWhiteSpace(titlePost))
                return Result<Lot>.Failure("'TitlePost' must not be empty");
            if (price <= 0)
                return Result<Lot>.Failure("'Price' must be greater than 0");
            if (addressId == Guid.Empty)
                return Result<Lot>.Failure("'AddressId' must not be empty");
            if (lotArea <= 0)
                return Result<Lot>.Failure("'LotArea' must be greater than 0");
            if (streetFrontage <= 0)
                return Result<Lot>.Failure("'StreetFrontage' must be greater than 0");
            if (string.IsNullOrWhiteSpace(description))
                return Result<Lot>.Failure("'Description' must not be empty");


            return Result<Lot>.Success(new Lot(userId, titlePost, price, addressId, offerType,description, lotArea, streetFrontage, lotClassificationId));
        }

        public void AttachLotClassificationId(Guid lotClassificationId)
        {
                LotClassificationId = lotClassificationId;
        }

        public void AttachLotArea(double lotArea)
        {
            LotArea = lotArea;
        }

        public void AttachStreetFrontage(double streetFrontage)
        {
			StreetFrontage = streetFrontage;
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
            if (!string.IsNullOrWhiteSpace(description))
            {
                Description = description;
            }
        }

    }
}

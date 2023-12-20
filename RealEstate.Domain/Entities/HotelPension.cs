using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table("HotelPensions")]
    public class HotelPension : BasePost
    {
        private HotelPension(string userId, string titlePost, double price, Guid addressId, bool offerType, string description,
             double usefulSurface, double roomSurface, int roomCount)
            : base(userId, titlePost, price, addressId, offerType, description)
        {
            RoomCount = roomCount;
            RoomSurface = roomSurface;
            UsefulSurface = usefulSurface;
        }

        public double UsefulSurface { get; private set; }
        public double RoomSurface { get; private set; }
        public int RoomCount { get; private set; }

        public static Result<HotelPension> Create(string userId, string titlePost, double price, Guid addressId, bool offerType, string description,
            double usefulSurface, double roomSurface, int roomCount)
        {
            if (string.IsNullOrWhiteSpace(titlePost))
            {
                return Result<HotelPension>.Failure("Title post must not be empty.");
            }

            if (price <= 0)
            {
                return Result<HotelPension>.Failure("Price must be larger than 0.");
            }

            if (addressId == Guid.Empty)
            {
                return Result<HotelPension>.Failure("Address id must not be empty.");
            }

            if (offerType == false)
            {
                return Result<HotelPension>.Failure("Offer type must be true.");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                return Result<HotelPension>.Failure("Description must not be empty.");
            }

            if (usefulSurface <= 0)
            {
                return Result<HotelPension>.Failure("Useful area must be larger than 0.");
            }

            if (roomSurface <= 0)
            {
                return Result<HotelPension>.Failure("Room surface must be larger than 0.");
            }

            if (roomCount <= 0)
            {
                return Result<HotelPension>.Failure("Room count must be larger than 0.");
            }


            return Result<HotelPension>.Success(new HotelPension(userId, titlePost, price, addressId, offerType,description, usefulSurface, roomSurface, roomCount));
        }

        public void AttachBasePostId(Guid basePostId)
        {
			if (basePostId != Guid.Empty)
            {
				BasePostId = basePostId;
			}
		}

        public void AttachUsefulSurface(double usefulSurface)
        {
			if (usefulSurface > 0)
            {
				UsefulSurface = usefulSurface;
			}
		}

		public void AttachRoomSurface(double roomSurface)
        {
			if (roomSurface > 0)
            {
				RoomSurface = roomSurface;
			}
		}

		public void AttachRoomCount(int roomCount)
        {
			if (roomCount > 0)
            {
				RoomCount = roomCount;
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
            if (!string.IsNullOrWhiteSpace(description))
            {
                Description = description;
            }
        }
    }
}

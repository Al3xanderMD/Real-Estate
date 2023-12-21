using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table("Houses")]
    public class House : BasePost
    {
        private House(string userId, string titlePost, double price, Guid addressId, bool offerType, string description,
            int roomCount, int floorCount, double usefulSurface, double lotArea, int buildYear , Guid houseTypeId)
            : base(userId, titlePost, price, addressId, offerType, description)
        {
            RoomCount = roomCount;
            FloorCount = floorCount;
            UsefulSurface = usefulSurface;
            LotArea = lotArea;
            BuildYear = buildYear;
            HouseTypeId = houseTypeId;
        }

        private House(HouseType houseType, int roomCount, int floorCount, double usefulSurface, double lotArea, int buildYear, Guid houseTypeId,
            string userId, string titlePost, double price, Guid addressId, bool offerType, string description) 
            : this(userId, titlePost, price, addressId, offerType,description, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId)
        {
            HouseType = houseType;
        }

        public int RoomCount { get; private set; }
		public Guid HouseTypeId { get; private set; }
		public HouseType HouseType { get; private set; } = null!;
        public int Comfort { get; private set; }
		public int FloorCount { get; private set; }
		public double UsefulSurface { get; private set; }
		public double LotArea { get; private set; }
		public int BuildYear { get; private set; }


		public static Result<House> Create(string userId, string titlePost, double price, Guid addressId, bool offerType, string description,
            int roomCount, int floorCount, double usefulSurface, double lotArea, int buildYear , Guid houseTypeId)
        {
            if (string.IsNullOrWhiteSpace(titlePost))
                return Result<House>.Failure("'TitlePost' must not be empty");
            if (price <= 0)
                return Result<House>.Failure("'Price' must be greater than 0");
            if (addressId == Guid.Empty)
                return Result<House>.Failure("'AddressId' must not be empty");
            if (roomCount <= 0)
                return Result<House>.Failure("'RoomCount' must be greater than 0");
            if (floorCount <= 0)
                return Result<House>.Failure("'FloorCount' must be greater than 0");
            if (usefulSurface <= 0)
                return Result<House>.Failure("'UsefulSurface' must be greater than 0");
            if (lotArea <= 0)
                return Result<House>.Failure("'LotArea' must be greater than 0");
            if (buildYear <= 1900 || buildYear > DateTime.Now.Year)
                return Result<House>.Failure("The Build Year must be after 1900 and before " + DateTime.Now.Year + 1);
            

            return Result<House>.Success(new House(userId, titlePost, price, addressId, offerType, description,
                roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId));
        }

        public void AttachRoomCount(int roomCount)
        {
            RoomCount = roomCount;
        }

        public void AttachHouseTypeId(Guid houseTypeId)
        {
            if(houseTypeId != Guid.Empty)
            {
                HouseTypeId = houseTypeId;
            }
        }
        public void AttachComfort(int comfort)
        {
			Comfort = comfort;
		}

        public void AttachFloorCount(int floorCount)
        {
            FloorCount = floorCount;
        }

        public void AttachUsefulSurface(double usefulSurface)
        {
			UsefulSurface = usefulSurface;
		}

        public void AttachLotArea(double lotArea)
        {
            LotArea = lotArea;
        }

        public void AttachBuildYear(int buildYear)
        {
            BuildYear = buildYear;
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

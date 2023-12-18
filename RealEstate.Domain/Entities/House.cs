using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class House : AuditableEntity
    {
        private House(Guid basePostId, int roomCount, int floorCount, double usefulSurface, double lotArea, int buildYear , Guid houseTypeId)
        {
            Id = Guid.NewGuid();
            BasePostId = basePostId;
            RoomCount = roomCount;
            FloorCount = floorCount;
            UsefulSurface = usefulSurface;
            LotArea = lotArea;
            BuildYear = buildYear;
            HouseTypeId = houseTypeId;
        }

        private House(BasePost basePost, HouseType houseType, Guid basePostId, int roomCount, int floorCount, double usefulSurface, double lotArea, int buildYear, Guid houseTypeId) : this(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId)
        {
            BasePost = basePost;
            HouseType = houseType;
        }

        public Guid Id { get; private set; }
        public Guid BasePostId { get; private set; }
        public BasePost BasePost { get; private set; } = null!;
        public int RoomCount { get; private set; }
		public Guid HouseTypeId { get; private set; }
		public HouseType HouseType { get; private set; } = null!;
        public int Comfort { get; private set; }
		public int FloorCount { get; private set; } 
		public double UsefulSurface { get; private set; } 
		public double LotArea { get; private set; } 
		public int BuildYear { get; private set; } 


		public static Result<House> Create(Guid basePostId, int roomCount, int floorCount, double usefulSurface, double lotArea, int buildYear , Guid houseTypeId)
        {

            if (roomCount <= 0)
            {
                return Result<House>.Failure("Room count must be larger than 0.");
            }

            if (floorCount <= 0)
            {
                return Result<House>.Failure("Floor count must be larger than 0.");
            }

            if (usefulSurface <= 0)
            {
                return Result<House>.Failure("Useful surface must be larger than 0.");
            }

            if (lotArea <= 0)
            {
                return Result<House>.Failure("Lot area must be larger than 0.");
            }

            if (buildYear <= 1900 || buildYear > DateTime.Now.Year)
            {
                string str = "The Build Year must be after 1900 and before " + DateTime.Now.Year + 1;
                return Result<House>.Failure(str);
            }

            return Result<House>.Success(new House(basePostId, roomCount, floorCount, usefulSurface, lotArea, buildYear, houseTypeId));
        }

        public Result<BasePost> Delete()
        {
            throw new NotImplementedException();
        }

        public Result<BasePost> ReadPost()
        {
            throw new NotImplementedException();
        }

        public Result<BasePost> Update()
        {
            throw new NotImplementedException();
        }

        public void AttachBasePostId(Guid basePostId)
        {
			if(basePostId != Guid.Empty)
            {
				BasePostId = basePostId;
			}
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

    }
}

using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class HotelPension : AuditableEntity
    {
        private HotelPension(double usefulSurface, double roomSurface, int roomCount , Guid basePostId)
        {
            Id = Guid.NewGuid();
            BasePostId = basePostId;
            RoomCount = roomCount;
            RoomSurface = roomSurface;
            UsefulSurface = usefulSurface;
        }

        private HotelPension(BasePost basePost, double usefulSurface, double roomSurface, int roomCount, Guid basePostId) : this(usefulSurface, roomSurface, roomCount, basePostId)
        {
            BasePost = basePost;
        }

        public Guid Id { get; private set; }
        public Guid BasePostId { get; private set; } //attach
        public BasePost BasePost { get; private set; } = null!;
        public double UsefulSurface { get; private set; }
        public double RoomSurface { get; private set; }
        public int RoomCount { get; private set; }

        public Result<HotelPension> Create(Guid basePostId, double usefulSurface, double roomSurface, int roomCount)
        {
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


            return Result<HotelPension>.Success(new HotelPension(usefulSurface, roomSurface, roomCount, basePostId));
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
    }
}

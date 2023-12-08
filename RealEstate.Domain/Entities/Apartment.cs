using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Apartment : AuditableEntity
    {
        private Apartment(int roomCount, int comfort, int floor, double usefulSurface, int buildYear, Guid basePostId, Guid partitioningId)
        {
            Id = Guid.NewGuid();
            RoomCount = roomCount;
            Comfort = comfort;
            Floor = floor;
            UsefulSurface = usefulSurface;
            BuildYear = buildYear;
            BasePostId = basePostId;
            PartitioningId = partitioningId;
        }

        private Apartment(BasePost basePost, Partitioning partitioning, int roomCount, int comfort, int floor, double usefulSurface, int buildYear, Guid basePostId, Guid partitioningId) : this( roomCount, comfort, floor, usefulSurface, buildYear, basePostId, partitioningId)
        {
            BasePost = basePost;
            Partitioning = partitioning;
        }

        public Guid Id { get; private set; }
        public Guid BasePostId { get; private set; } 
        public BasePost BasePost { get; private set; } = null!;
        public int RoomCount { get; private set; }
        public Guid PartitioningId { get; private set; }
        public Partitioning Partitioning { get; private set; } = null!;
        public int Comfort { get; private set; }
        public int Floor { get; private set; }
        public double UsefulSurface { get; private set; }
        public int BuildYear { get; private set; }


        public static Result<Apartment> Create( int roomCount, int comfort, int floor, double usefulSurface, int buildYear, Guid basepostId, Guid partitioningId)
        {

            if (roomCount <= 0)
            {
                return Result<Apartment>.Failure("Room count must be larger than 0.");
            }

            if (comfort <= 0 || comfort > 4) 
            {
                return Result<Apartment>.Failure("Comfort must be larger than 0 and less than 5.");
            }

            if (floor <= 0)
            {
                return Result<Apartment>.Failure("Room count must be larger than 0.");
            }

            if (usefulSurface <= 0)
            {
                return Result<Apartment>.Failure("Useful surface must be larger than 0.");
            }

            if (buildYear <= 1900 && buildYear > DateTime.Now.Year)
            {
                string str = "The Build Year must be after 1900 and before " + DateTime.Now.Year + 1;
                return Result<Apartment>.Failure(str);
            }

            return Result<Apartment>.Success(new Apartment(roomCount, comfort, floor, usefulSurface, buildYear, basepostId, partitioningId));
        }

        public void AttachPartitioning(Partitioning partitioning)
        {
            Partitioning = partitioning;
        }

        public void AttachRoomCount(int roomCount)
        {
            if (roomCount > 0)
            {
                RoomCount = roomCount;
            }
        }

        public void AttachComfort(int comfort)
        {
            if (comfort > 0 && comfort < 5)
            {
                Comfort = comfort;
            }
        }

        public void AttachFloor(int floor)
        {
            if (floor > 0)
            {
                Floor = floor;
            }
        }

        public void AttachUsefulSurface(double usefulSurface)
        {
            if (usefulSurface > 0)
            {
                UsefulSurface = usefulSurface;
            }
        }

        public void AttachBuildYear(int buildYear)
        {
            if (buildYear > 1900 && buildYear < DateTime.Now.Year + 1)
            {
                BuildYear = buildYear;
            }
        }

        public void AttachBasePostId(Guid basePostId)
        {
            if (basePostId != Guid.Empty)
            {
                BasePostId = basePostId;
            }
        }

        public void AttachPartitioningId(Guid partitioningId)
        {
            if (partitioningId != Guid.Empty)
            {
                PartitioningId = partitioningId;
            }
        }
    }
}

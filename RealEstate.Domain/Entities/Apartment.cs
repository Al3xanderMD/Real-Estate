using MediatR;
using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table("Apartments")]
    public class Apartment : BasePost
    {
        private Apartment(string userId, string titlePost, double price, Guid addressId, bool offerType, string description,
            int roomCount, int comfort, int floor, double usefulSurface, int buildYear, Guid partitioningId)
            : base(userId, titlePost, price, addressId, offerType, description)
        {
            RoomCount = roomCount;
            Comfort = comfort;
            Floor = floor;
            UsefulSurface = usefulSurface;
            BuildYear = buildYear;
            PartitioningId = partitioningId;
        }
         
        public Apartment(Partitioning partitioning, int roomCount, int comfort, int floor, double usefulSurface, int buildYear, Guid partitioningId, 
            string userId, string titlePost, double price, Guid addressId, bool offerType, string description)
            : this(userId, titlePost, price, addressId, offerType,description, roomCount, comfort, floor, usefulSurface, buildYear, partitioningId)
        {
            Partitioning = partitioning;
        }

        public int RoomCount { get; private set; }
        public Guid PartitioningId { get; private set; }
        public Partitioning Partitioning { get; private set; } = null!;
        public int Comfort { get; private set; }
        public int Floor { get; private set; }
        public double UsefulSurface { get; private set; }
        public int BuildYear { get; private set; }


        public static Result<Apartment> Create(string userId, string titlePost, double price, Guid addressId, bool offerType, string description,
                        int roomCount, int comfort, int floor, double usefulSurface, int buildYear, Guid partitioningId)
        {
            if (string.IsNullOrWhiteSpace(titlePost))
                return Result<Apartment>.Failure("'TitlePost' must not be empty");
            if (price <= 0)
                return Result<Apartment>.Failure("'Price' must be greater than 0");
            if (addressId == Guid.Empty)
                return Result<Apartment>.Failure("'AddressId' must not be empty");
            if (roomCount <= 0)
                return Result<Apartment>.Failure("'RoomCount' must be greater than 0");
            if (comfort <= 0 || comfort > 5)
                return Result<Apartment>.Failure("'Comfort' must be greater than 0 and less than 5");
            if (floor <= 0)
                return Result<Apartment>.Failure("'Floor' must be greater than 0");
            if (usefulSurface <= 0)
                return Result<Apartment>.Failure("'UsefulSurface' must be greater than 0");
            if (buildYear <= 1900 || buildYear > DateTime.Now.Year)
                return Result<Apartment>.Failure("'BuildYear' must be after 1900 and before " + DateTime.Now.Year + 1);
            if (partitioningId == Guid.Empty)
                return Result<Apartment>.Failure("'PartitioningId' must not be empty");
            if (string.IsNullOrWhiteSpace(description))
                return Result<Apartment>.Failure("'Description' must not be empty");

            return Result<Apartment>.Success(new Apartment(userId, titlePost, price, addressId, offerType, description,
                roomCount, comfort, floor, usefulSurface, buildYear, partitioningId));
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

        public void AttachPartitioningId(Guid partitioningId)
        {
            if (partitioningId != Guid.Empty)
            {
                PartitioningId = partitioningId;
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
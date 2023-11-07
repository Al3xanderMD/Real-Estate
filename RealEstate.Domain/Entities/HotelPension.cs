using RealEstate.Domain.Common;
using System.Net.Sockets;

namespace RealEstate.Domain.Entities
{
    public class HotelPension : AuditableEntity
    {
        private HotelPension(RegAuth regAuth, string addressUrl, string addressName, string titlePost, bool offerType, List<string> image, double price, string description, double usefulSurface, double roomSurface, int roomCount)
        {
            Address Address = new Address
            {
                Url = addressUrl,
                AddressName = addressName
            };

            PostId = new BasePost
            {
                UserId = regAuth.Id,
                TitlePost = titlePost,
                OfferType = offerType,
                Image = image,
                Price = price,
                Descripion = description,
                AddressId = Address
            };

            RoomCount = roomCount;
            RoomSurface = roomSurface;
            UsefulSurface = usefulSurface;
        }

        public BasePost PostId { get; private set; } //attach
        public double UsefulSurface { get; private set; }
        public double RoomSurface { get; private set; }
        public int RoomCount { get; private set; }

        public Result<HotelPension> Create(RegAuth regAuth, string addressUrl, string addressName, string titlePost, bool offerType, List<string> image, double price, string description, double usefulSurface, double roomSurface, int roomCount)
        {
            if (string.IsNullOrWhiteSpace(titlePost))
            {
                return Result<HotelPension>.Failure("A Title for the Post is required.");
            }

            if (image.Count() > 16)
            {
                return Result<HotelPension>.Failure("Please add less than 16 images");
            }

            if (price <= 0)
            {
                return Result<HotelPension>.Failure("Price must be larger than 0.");
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

            if (string.IsNullOrEmpty(addressUrl))
            {
                return Result<HotelPension>.Failure("Address URL is required.");
            }

            if (string.IsNullOrEmpty(addressName))
            {
                return Result<HotelPension>.Failure("Address is required.");
            }


            return Result<HotelPension>.Success(new HotelPension(regAuth, addressUrl, addressName, titlePost, offerType, image, price, description, usefulSurface, roomSurface, roomCount));
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
}

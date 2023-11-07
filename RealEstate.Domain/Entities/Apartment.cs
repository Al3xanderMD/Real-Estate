using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Apartment : AuditableEntity
    {
        private Apartment(RegAuth regAuth, string addressUrl, string addressName, string titlePost, bool offerType, List<string> image, double price, string description, int roomCount, int comfort, int floor, double usefulSurface, int buildYear) 
        {
            Address Address = new Address
            {
                Url = addressUrl,
                AddressName = addressName
            };

            IdPost = new BasePost
            {
                IdUser = regAuth.IdUser,
                TitlePost = titlePost,
                OfferType = offerType,
                Image = image,
                Price = price,
                Descripion = description,
                IdAddress = Address
            };

            RoomCount = roomCount;
            Comfort = comfort;
            Floor = floor;
            UsefulSurface = usefulSurface;
            BuildYear = buildYear;
        }

        public BasePost IdPost { get; private set; } //attach
        public int RoomCount { get; private set; }
        public Partitioning IdPartitioning { get; private set; }
        public int Comfort { get; private set; }
        public int Floor { get; private set; }
        public double UsefulSurface { get; private set; }
        public int BuildYear { get; private set; }


        public Result<Apartment> Create(RegAuth regAuth, string addressUrl, string addressName, string titlePost, bool offerType, List<string> image, double price, string description, int roomCount, int comfort, int floor, double usefulSurface, int buildYear)
        {
            if (string.IsNullOrWhiteSpace(titlePost))
            {
                return Result<Apartment>.Failure("A Title for the Post is required.");
            }

            if (image.Count() > 16)
            {
                return Result<Apartment>.Failure("Please add less than 16 images");
            }

            if (price <=0)
            {
                return Result<Apartment>.Failure("Price must be larger than 0.");
            }

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

            if (string.IsNullOrEmpty(addressUrl)) 
            {
                return Result<Apartment>.Failure("Address URL is required.");
            }

            if (string.IsNullOrEmpty(addressName))
            {
                return Result<Apartment>.Failure("Address is required.");
            }

            return Result<Apartment>.Success(new Apartment(regAuth, addressUrl, addressName, titlePost, offerType, image, price, description, roomCount, comfort, floor, usefulSurface, buildYear));
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

using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class House : AuditableEntity
    {
        private House(RegAuth regAuth, string addressUrl, string addressName, string titlePost, bool offerType, List<string> image, double price, string description, int roomCount, int floorCount, double usefulSurface, double lotArea, int buildYear)
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
            FloorCount = floorCount;
            UsefulSurface = usefulSurface;
            LotArea = lotArea;
            BuildYear = buildYear;
        }

        public BasePost PostId { get; private set; } //attach
        public int RoomCount { get; private set; }
        public HouseType HouseTypeId { get; private set; }
        public int Comfort { get; private set; }
        public int FloorCount { get; private set; }
        public double UsefulSurface { get; private set; }
        public double LotArea { get; private set; }
        public int BuildYear { get; private set; }


        public Result<House> Create(RegAuth regAuth, string addressUrl, string addressName, string titlePost, bool offerType, List<string> image, double price, string description, int roomCount, int floorCount, double usefulSurface, double lotArea, int buildYear)
        {
            if (string.IsNullOrWhiteSpace(titlePost))
            {
                return Result<House>.Failure("A Title for the Post is required.");
            }

            if (image.Count() > 16)
            {
                return Result<House>.Failure("Please add less than 16 images");
            }

            if (price <= 0)
            {
                return Result<House>.Failure("Price must be larger than 0.");
            }

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

            if (buildYear <= 1900 && buildYear > DateTime.Now.Year)
            {
                string str = "The Build Year must be after 1900 and before " + DateTime.Now.Year + 1;
                return Result<House>.Failure(str);
            }

            if (string.IsNullOrEmpty(addressUrl))
            {
                return Result<House>.Failure("Address URL is required.");
            }

            if (string.IsNullOrEmpty(addressName))
            {
                return Result<House>.Failure("Address is required.");
            }


            return Result<House>.Success(new House(regAuth, addressUrl, addressName, titlePost, offerType, image, price, description, roomCount, floorCount, usefulSurface, lotArea, buildYear));
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

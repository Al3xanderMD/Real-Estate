using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Lot : AuditableEntity
    {
        private Lot(RegAuth regAuth, string addressUrl, string addressName, string titlePost, bool offerType, List<string> image, double price, string description, double streetFrontage, double lotArea)
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
            LotArea = lotArea;
        }

        public BasePost PostId { get; private set; } //attach
        public LotClassification LotClassificationId { get; private set; }
        public double LotArea { get; private set; }


        public Result<Lot> Create(RegAuth regAuth, string addressUrl, string addressName, string titlePost, bool offerType, List<string> image, double price, string description, double streetFrontage, double lotArea)
        {
            if (string.IsNullOrWhiteSpace(titlePost))
            {
                return Result<Lot>.Failure("A Title for the Post is required.");
            }

            if (image.Count() > 16)
            {
                return Result<Lot>.Failure("Please add less than 16 images");
            }

            if (price <= 0)
            {
                return Result<Lot>.Failure("Price must be larger than 0.");
            }

            if (lotArea <= 0)
            {
                return Result<Lot>.Failure("Lot area must be larger than 0.");
            }

            if (streetFrontage <= 0) 
            {
                return Result<Lot>.Failure("Street frontage must be larger than 0.");
            }

            if (string.IsNullOrEmpty(addressUrl))
            {
                return Result<Lot>.Failure("Address URL is required.");
            }

            if (string.IsNullOrEmpty(addressName))
            {
                return Result<Lot>.Failure("Address is required.");
            }


            return Result<Lot>.Success(new Lot(regAuth, addressUrl, addressName, titlePost, offerType, image, price, description, streetFrontage, lotArea));
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

using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class BasePost
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set;}
        public string TitlePost { get; set; }
        public bool OfferType { get; set; }
        public List<string> Image { get; set; }
        public double Price { get; set; }
        public Address AddressId { get; set; }

        public string Descripion { get; set; }

        public BasePost()
        {
            Id = Guid.NewGuid();
        }
    }
}

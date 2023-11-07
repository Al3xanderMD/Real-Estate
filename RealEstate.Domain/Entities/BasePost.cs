using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class BasePost
    {
        public Guid IdPost { get; set; }
        public Guid IdUser { get; set;}
        public string TitlePost { get; set; }
        public bool OfferType { get; set; }
        public List<string> Image { get; set; }
        public double Price { get; set; }
        public Address IdAddress { get; set; }

        public string Descripion { get; set; }

        public BasePost()
        {
            IdPost = Guid.NewGuid();
        }
    }
}

namespace RealEstate.Domain.Entities
{
    public class Address
    {
        public Guid IdAddress { get; set; }
        public string Url { get; set; }
        public string AddressName { get; set; }

        public Address()
        {
            IdAddress = Guid.NewGuid();
        }
    }
}

namespace RealEstate.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string AddressName { get; set; }

        public Address()
        {
            Id = Guid.NewGuid();
        }
    }
}
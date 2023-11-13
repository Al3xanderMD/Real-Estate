using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public Guid Id { get; private set; }
        public string Url { get; private set; }
        public string AddressName { get; private set; }

        public Address(string url, string addressName)
        {
            Id = Guid.NewGuid();
            Url = url;
            AddressName = addressName;
        }

        public Result<Address> CreateAddress(string url, string addressName)
        {
            if (string.IsNullOrWhiteSpace(url))
                return Result<Address>.Failure("Url is required");

            if (string.IsNullOrWhiteSpace(addressName))
                return Result<Address>.Failure("Address name is required");

            return Result<Address>.Success(new Address(url, addressName));
        }
    }
}
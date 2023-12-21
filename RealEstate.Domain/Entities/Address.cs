using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table("Addresses")]
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

        public static Result<Address> Create(string url, string addressName)
        {
            if (string.IsNullOrWhiteSpace(url))
                return Result<Address>.Failure("Url is required");

            if (string.IsNullOrWhiteSpace(addressName))
                return Result<Address>.Failure("Address name is required");

            return Result<Address>.Success(new Address(url, addressName));
        }

        public void AttachAddressName(string addressName)
        {
            if(!string.IsNullOrWhiteSpace(addressName))
                AddressName = addressName;
        }

        public void AttachUrl(string url)
        {
            if(!string.IsNullOrWhiteSpace(url))
                     Url = url;
        }
    }
}
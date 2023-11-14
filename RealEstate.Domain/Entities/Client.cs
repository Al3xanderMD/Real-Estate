using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Client : AuditableEntity
    {
        public Guid ClientId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Phone { get; private set; }
        public string? Region { get; private set; }

        private Client(string firstName, string lastName)
        {
            ClientId = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
        }

        public static Result<Client> Create(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return Result<Client>.Failure("First name is required");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return Result<Client>.Failure("Last name is required");
            }

            var client = new Client(firstName, lastName);

            return Result<Client>.Success(client);
        }

        public void AttachPhone(string phone)
        {
             if(phone.Length == 10)
            {
                Phone = phone;
            }
             
        }
        public void AttachRegion(string region)
        {
               if(!string.IsNullOrWhiteSpace(region))
            {
                Region = region;
            }
               
        }
    }
}

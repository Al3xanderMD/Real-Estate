using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class Client : AuditableEntity
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Phone { get; private set; }
        public string? Region { get; private set; }
        public RegAuth RegAuthId { get; private set; }

        private Client(string email, string password, string firstName, string lastName)
        {
            RegAuthId = new RegAuth
            {
                Email = email,
                Password = password
            };
            FirstName = firstName;
            LastName = lastName;
        }

        public static Result<Client> Create(string email, string password, string firstName, string lastName, string phone, string region)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result<Client>.Failure("Email is required");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                return Result<Client>.Failure("Password is required");
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return Result<Client>.Failure("First name is required");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return Result<Client>.Failure("Last name is required");
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                return Result<Client>.Failure("Phone is required");
            }
            if (string.IsNullOrWhiteSpace(region))
            {
                return Result<Client>.Failure("Region is required");
            }

            var client = new Client(email, password, firstName, lastName);

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

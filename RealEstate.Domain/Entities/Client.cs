using RealEstate.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstate.Domain.Entities
{
    [Table("Clients")]
    public class Client : AuditableEntity
    {
        [Key]
        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string? ImageUrl { get; private set; }

        private Client(Guid userId, string username, string email, string name, string phoneNumber)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public static Result<Client> Create(Guid userId, string username, string email, string name, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(username))
                return Result<Client>.Failure("Username is required");
            if (string.IsNullOrWhiteSpace(email))
                return Result<Client>.Failure("Email is required");
            if (string.IsNullOrWhiteSpace(name))
                return Result<Client>.Failure("Name is required");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return Result<Client>.Failure("Phone number is required");
            if (userId == Guid.Empty)
                return Result<Client>.Failure("UserId is required");

            return Result<Client>.Success(new Client(userId, username, email, name, phoneNumber));
        }

        public void AttachName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;
        }

        public void AttachPhoneNumber(string phoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(phoneNumber))
                PhoneNumber = phoneNumber;
        }

        public void AttachImageUrl(string imageUrl)
        {
            if (!string.IsNullOrWhiteSpace(imageUrl))
                ImageUrl = imageUrl;
        }
    }
}

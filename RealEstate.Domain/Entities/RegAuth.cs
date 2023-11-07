using RealEstate.Domain.Common;

namespace RealEstate.Domain.Entities
{
    public class RegAuth : AuditableEntity
    {

        public RegAuth()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "User";
        public string? VerificationCode { get; set; }
        public bool IsVerified { get; set; } = false;

    }
}

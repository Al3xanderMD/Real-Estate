namespace RealEstate.Application.Features.Categories.Commands.CreateClient
{
    public class CreateClientDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

    }
}

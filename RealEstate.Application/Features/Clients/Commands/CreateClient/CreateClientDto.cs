namespace RealEstate.Application.Features.Categories.Commands.CreateClient
{
    public class CreateClientDto
    {
        public Guid ClientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}

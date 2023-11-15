namespace RealEstate.Application.Features.Clients.Queries
{
    public class ClientDto
    {
        public Guid ClientId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}

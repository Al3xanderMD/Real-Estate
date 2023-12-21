namespace RealEstate.Application.Features.Clients.Queries
{
    public class ClientDto
    {
        public Guid UserId { get; set; } 
        public string? Username { get; set; } 
        public string? Email { get; set; } 
        public string? Name { get; set; } 
        public string? PhoneNumber { get; set; } 
        public string? ImageUrl { get; set; } 
        
    }
}

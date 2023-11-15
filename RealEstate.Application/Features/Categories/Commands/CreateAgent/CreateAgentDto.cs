using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Categories.Commands.CreateAgent
{
    public class CreateAgentDto
    {
        public string? AgentName { get; set; }
        public string? Logolink { get; set; }
        public string? Phone { get; set; }
        public Address AddressId { get;set; }
        public string? Url { get; set; }
        public RegAuth RegAuth { get; set; }
    }
}

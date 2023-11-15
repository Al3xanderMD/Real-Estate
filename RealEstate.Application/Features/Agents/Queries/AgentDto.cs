namespace RealEstate.Application.Features.Agents.Queries
{
    public class AgentDto
    {
        public Guid AgentId { get; set; }
        public string AgentName { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public Guid AddressId { get; set; } 
    }
}

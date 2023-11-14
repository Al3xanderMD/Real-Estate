namespace RealEstate.Application.Features.Agents.Commands.CreateAgent
{
    public class CreateAgentDto
    {
        public Guid AgentId { get; set; }
        public string? AgentName { get; set; }
        public string? Phone { get; set; }
        public Guid AddressId { get; set; }
    }
}

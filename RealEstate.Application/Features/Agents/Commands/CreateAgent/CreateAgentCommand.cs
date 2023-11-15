using MediatR;

namespace RealEstate.Application.Features.Agents.Commands.CreateAgent
{
    public class CreateAgentCommand : IRequest<CreateAgentCommandResponse>
    {
        public string AgentName { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public Guid AddressId { get; set; } = default!;
    }
}

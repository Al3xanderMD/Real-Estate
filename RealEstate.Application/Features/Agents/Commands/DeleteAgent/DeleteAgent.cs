using MediatR;

namespace RealEstate.Application.Features.Agents.Commands.DeleteAgent
{
    public class DeleteAgent : IRequest<DeleteAgentResponse>
    {
        public Guid Id { get; set; }
    }
}

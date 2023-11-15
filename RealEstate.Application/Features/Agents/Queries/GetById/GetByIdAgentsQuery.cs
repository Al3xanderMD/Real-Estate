using MediatR;

namespace RealEstate.Application.Features.Agents.Queries.GetById
{
    public record GetByIdAgentsQuery(Guid AgentId) : IRequest<AgentDto>;
}

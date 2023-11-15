using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Agents.Queries.GetById
{
    public class GetByIdAgentsQueryHandler : IRequestHandler<GetByIdAgentsQuery, AgentDto>
    {
        private readonly IAgentRepository repository;

        public GetByIdAgentsQueryHandler(IAgentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AgentDto> Handle(GetByIdAgentsQuery request, CancellationToken cancellationToken)
        {
            var agent = await repository.FindByIdAsync(request.AgentId);

            if(agent.IsSuccess)
            {
                return new AgentDto
                {
                    AgentId = agent.Value.AgentId,
                    AgentName = agent.Value.AgentName,
                    Phone = agent.Value.Phone,
                    AddressId = agent.Value.AddressId
                };
            }
            return new AgentDto();
        }

    }
}

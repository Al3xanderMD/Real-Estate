using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Agents.Queries.GetAll
{
    public class GetAllAgentsQueryHandler : IRequestHandler<GetAllAgentsQuery, GetAllAgentsResponse>
    {
        private readonly IAgentRepository repository;

        public GetAllAgentsQueryHandler(IAgentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<GetAllAgentsResponse> Handle(GetAllAgentsQuery request, CancellationToken cancellationToken)
        {
            GetAllAgentsResponse response = new();
            var result = await repository.GetAllAsync();

            if(result.IsSuccess)
            {
                response.Agents = result.Value.Select(agent => new AgentDto
                {
                    AgentId = agent.AgentId,
                    AgentName = agent.AgentName,
                    Phone = agent.Phone,
                    AddressId = agent.AddressId
                }).ToList();
            }
            return response;
        }
    }
}

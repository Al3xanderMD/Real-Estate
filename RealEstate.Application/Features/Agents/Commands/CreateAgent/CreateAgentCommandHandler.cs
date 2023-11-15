using MediatR;
using RealEstate.Application.Persistence;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Features.Agents.Commands.CreateAgent
{
    public class CreateAgentCommandHandler : IRequestHandler<CreateAgentCommand, CreateAgentCommandResponse>
    {
        private readonly IAgentRepository repository;

        public CreateAgentCommandHandler(IAgentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateAgentCommandResponse> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAgentCommandValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                return new CreateAgentCommandResponse
                {
                    Success = false,
                    ValidationErrors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var agent = Agent.Create(request.AddressId, request.AgentName, request.Phone);
            if (!agent.IsSuccess)
            {
                return new CreateAgentCommandResponse
                {
                    Success = false,
                    ValidationErrors = new List<string>() { agent.Error }
                };
            }

            await repository.AddAsync(agent.Value);

            return new CreateAgentCommandResponse
            {
                Success = true,
                Agent = new CreateAgentDto
                {
                    AgentId = agent.Value.AgentId,
                    AgentName = agent.Value.AgentName,
                    Phone = agent.Value.Phone,
                    AddressId = agent.Value.AddressId
                }
            };
        }
    }
}

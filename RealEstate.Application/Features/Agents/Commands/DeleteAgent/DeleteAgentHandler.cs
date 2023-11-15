using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Agents.Commands.DeleteAgent
{
    public class DeleteAgentHandler : IRequestHandler<DeleteAgent, DeleteAgentResponse>
    {
        private readonly IAgentRepository repository;

        public DeleteAgentHandler(IAgentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteAgentResponse> Handle(DeleteAgent request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new DeleteAgentResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteAgentResponse
            {
                Success = true
            };
        }
    }
}

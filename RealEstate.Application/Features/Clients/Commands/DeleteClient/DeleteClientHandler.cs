using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientHandler : IRequestHandler<DeleteClient, DeleteClientResponse>
    {
        private readonly IClientRepository repository;

        public DeleteClientHandler(IClientRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteClientResponse> Handle(DeleteClient request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.ClientId);

            if (!result.IsSuccess)
            {
                return new DeleteClientResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeleteClientResponse
            {
                Success = true
            };
        }
    }
}

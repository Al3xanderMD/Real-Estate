using MediatR;
using RealEstate.Application.Persistence;

namespace RealEstate.Application.Features.Partitionings.Commands.DeletePartitioning
{
    public class DeletePartitioningHandler : IRequestHandler<DeletePartitioning, DeletePartitioningResponse>
    {
        private readonly IPartitioningRepository repository;

        public DeletePartitioningHandler(IPartitioningRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeletePartitioningResponse> Handle(DeletePartitioning request, CancellationToken cancellationToken)
        {
            var result = await repository.DeleteAsync(request.Id);

            if (!result.IsSuccess)
            {
                return new DeletePartitioningResponse
                {
                    Success = false,
                    ValidationErrors = new List<string> { result.Error }
                };
            }
            return new DeletePartitioningResponse
            {
                Success = true
            };
        }
    }
}

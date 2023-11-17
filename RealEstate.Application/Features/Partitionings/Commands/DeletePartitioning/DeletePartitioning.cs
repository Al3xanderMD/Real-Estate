using MediatR;

namespace RealEstate.Application.Features.Partitionings.Commands.DeletePartitioning
{
    public class DeletePartitioning : IRequest<DeletePartitioningResponse>
    {
        public Guid Id { get; set; }
    }
}
